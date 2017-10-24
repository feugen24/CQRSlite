using System;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class InventoryItemCreated : EventBase 
	{
        public readonly string Name;
        public InventoryItemCreated(Guid id, string name) :base(id)
        {
            AggregateId = id;
            Name = name;
        }
	}
}