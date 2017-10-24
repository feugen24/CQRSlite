using System;
using CQRSlite.Events;

namespace CQRSCode.ReadModel.Events
{
    public class InventoryItemDeactivated : IEvent 
	{
        public InventoryItemDeactivated(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

	    public string IssuedBy { get; set; }
	    public string CorrelationId { get; set; }
    }
}