using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSlite.Domain
{
    public interface IClonableEvent
    {
        Guid SourceAggregateId { get; set; }

        Guid AggregateId { get; set; }

        DateTimeOffset TimeStamp { get; set; }
    }
}
