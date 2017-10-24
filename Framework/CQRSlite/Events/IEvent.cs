﻿using CQRSlite.Messages;
using System;

namespace CQRSlite.Events
{
    /// <summary>
    /// Defines an event with required fields.
    /// </summary>
    public interface IEvent : IMessage
    {
        Guid AggregateId { get; set; }
        int Version { get; set; }
        DateTimeOffset TimeStamp { get; set; }

        string IssuedBy { get; set; }
        string CorrelationId { get; set; }
    }
}
