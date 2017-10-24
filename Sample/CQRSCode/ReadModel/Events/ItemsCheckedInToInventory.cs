using System;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class ItemsCheckedInToInventory : EventBase
    {
        public readonly int Count;
 
        public ItemsCheckedInToInventory(Guid aggregateId, int count) : base(aggregateId)
        {
            AggregateId = aggregateId;
            Count = count;
        }
    }
}