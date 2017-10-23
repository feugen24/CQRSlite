using System;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class ItemsRemovedFromInventory : IEvent
    {
        public readonly int Count;
 
        public ItemsRemovedFromInventory(Guid aggregateId, int count) 
        {
            AggregateId = aggregateId;
            Count = count;
        }

        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}