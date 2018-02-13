using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Domain;
using CQRSlite.Events;

namespace CQRSlite.Tests.Substitutes
{
    public class TestInMemoryEventStore : IEventStore 
    {
        public readonly List<IEvent> Events = new List<IEvent>();
        public CancellationToken Token { get; set; }

        public Task Save<T>(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken)) where T: AggregateRoot
        {
            lock (Events)
            {
                Events.AddRange(events);
            }
            Token = cancellationToken;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, DateTimeOffset? toDate = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Token = cancellationToken;
            lock(Events)
            {
                return Task.FromResult((IEnumerable<IEvent>)Events
                    .Where(x => x.Version > fromVersion && x.AggregateId == aggregateId)
                    .OrderBy(x => x.Version)
                    .ToList());
            }
        }
    }
}