using System;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class ItemsRemovedFromInventory : EventBase
    {
        public readonly int Count;
 
        public ItemsRemovedFromInventory(Guid aggregateId, int count) :base(aggregateId)
        {
            AggregateId = aggregateId;
            Count = count;
        }

//        public Guid AggregateId { get; set; }
//        public int Version { get; set; }
//        public DateTimeOffset TimeStamp { get; set; }
    }
}