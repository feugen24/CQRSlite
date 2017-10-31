using System;
using CQRSCode.WriteModel.Domain;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class InventoryItemCreated : EventBase 
	{
        public readonly string Name;
        public InventoryItemCreated(Guid id, string name) :base(id, typeof(InventoryItem))
        {
            AggregateId = id;
            Name = name;
        }
	}
}