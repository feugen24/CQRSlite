using System;
using CQRSCode.WriteModel.Domain;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class InventoryItemRenamed : EventBase
    {
        public readonly string NewName;
 
        public InventoryItemRenamed(Guid aggregateId, string newName):base(aggregateId, typeof(InventoryItem))
        {
            AggregateId = aggregateId;
            NewName = newName;
        }

//        public Guid AggregateId { get; set; }
//        public int Version { get; set; }
//        public DateTimeOffset TimeStamp { get; set; }
//        public string IssuedBy { get; set; }
//        public string CorrelationId { get; set; }
    }
}