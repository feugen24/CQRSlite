﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CQRSlite.Events
{
    public abstract class EventBase : IEvent
    {
        public Guid AggregateId { get; set; }
        public string HumanReadableId { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
        public Type AggregateType { get; set; }
        public string AggregateTypeName { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Data { get; set; }

        public string IssuedBy { get; set; }
        public string CorrelationId { get; set; }

        public bool IsCloned { get; private set; }

        protected EventBase(Guid aggregateId, Type aggregateType)
        {
            AggregateId = aggregateId;
            AggregateType = aggregateType;
            AggregateTypeName = aggregateType.Name;
            if (typeof(IEvent).IsAssignableFrom(aggregateType))
            {
                throw new ArgumentException("aggregateType can't be an event");
            }
        }

        public void SetAsClonedEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            IsCloned = true;
        }
}
}
