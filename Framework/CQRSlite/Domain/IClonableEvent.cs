using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSlite.Domain
{
    public interface IClonableEvent
    {
        Guid SourceTrackingSheetId { get; set; }

        Guid AggregateId { get; set; }
    }
}
