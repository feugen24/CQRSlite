using System;
using CQRSCode.WriteModel.Domain;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class ItemsCheckedInToInventory : EventBase
    {
        public readonly int Count;
 
        public ItemsCheckedInToInventory(Guid aggregateId, int count) : base(aggregateId, typeof(InventoryItem))
        {
            AggregateId = aggregateId;
            Count = count;
        }
    }
}