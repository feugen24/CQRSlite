using System;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class InventoryItemCreated : IEvent 
	{
        public readonly string Name;
        public InventoryItemCreated(Guid id, string name) 
        {
            AggregateId = id;
            Name = name;
        }

        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
	}
}