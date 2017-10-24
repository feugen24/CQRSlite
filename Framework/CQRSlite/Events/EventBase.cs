using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSlite.Events
{
    public abstract class EventBase : IEvent
    {
        public Guid AggregateId { get; set; }
        public string HumanReadableId { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public string IssuedBy { get; set; }
        public string CorrelationId { get; set; }

        protected EventBase(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
