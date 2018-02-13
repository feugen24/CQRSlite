using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Domain;
using CQRSlite.Events;

namespace CQRSlite.Tests.Substitutes
{
    public class TestEventStoreWithBugs : IEventStore
    {
        public Task Save<T>(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            return Task.CompletedTask;
        }

        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int version, DateTimeOffset? toDate = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (aggregateId == Guid.Empty)
            {
                return Task.FromResult((IEnumerable<IEvent>)new List<IEvent>());
            }

            return Task.FromResult((IEnumerable<IEvent>) new List<IEvent>
            {
                new TestAggregateDidSomething {AggregateId = aggregateId, Version = 3},
                new TestAggregateDidSomething {AggregateId = aggregateId, Version = 2},
                new TestAggregateDidSomethingElse {AggregateId = aggregateId, Version = 1}
            });
        }
    }
}