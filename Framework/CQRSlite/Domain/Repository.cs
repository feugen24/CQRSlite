using CQRSlite.Domain.Exception;
using CQRSlite.Domain.Factories;
using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSlite.Domain
{
    /// <summary>
    /// Repository gets and saves aggregates from event store.
    /// </summary>
    public class Repository : IRepository
    {
        private readonly IEventStore _eventStore;
        private readonly IEventPublisher _publisher;

        /// <summary>
        /// Initialize Repository
        /// </summary>
        /// <param name="eventStore">EventStore to get events from</param>
        public Repository(IEventStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public async Task Save<T>(T aggregate, int? expectedVersion = null, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            if (expectedVersion != null && (await _eventStore.Get(aggregate.Id, expectedVersion.Value, null, cancellationToken)).Any())
            {
                throw new ConcurrencyException(aggregate.Id);
            }

            var changes = aggregate.FlushUncommitedChanges();
            await _eventStore.Save<T>(changes, cancellationToken);

            if (_publisher != null)
            {
                foreach (var @event in changes)
                {
                    await _publisher.Publish(@event, cancellationToken);
                }
            }
        }

        public Task<T> Get<T>(Guid aggregateId, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            return LoadAggregate<T>(aggregateId, cancellationToken);
        }

        private async Task<T> LoadAggregate<T>(Guid id, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            var events = await _eventStore.Get(id, -1, null, cancellationToken);
            if (!events.Any(e => e.AggregateTypeName == typeof(T).Name))
            {
                return null;//throw new AggregateNotFoundException(typeof(T), id);
            }

            events = await CheckAndProcessClone<T>(events, cancellationToken);

            var aggregate = AggregateFactory.CreateAggregate<T>();
            aggregate.LoadFromHistory(events);
            return aggregate;
        }

        private async Task<IEnumerable<IEvent>> CheckAndProcessClone<T>(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken))
            where T : AggregateRoot
        {
            if (events.First() is IClonableEvent firstEvent)
            {
                var cloneSourceEvents = (await _eventStore.Get(firstEvent.SourceAggregateId, -1, firstEvent.TimeStamp, cancellationToken)).ToList();
                cloneSourceEvents = (await CheckAndProcessClone<T>(cloneSourceEvents, cancellationToken)).ToList();

                foreach (var cloneSourceEvent in cloneSourceEvents)
                {
                    cloneSourceEvent.SetAsClonedEvent(firstEvent.AggregateId);
                }
                cloneSourceEvents.ToList().AddRange(events);
                return cloneSourceEvents;
            }

            return events;
        }
    }
}
