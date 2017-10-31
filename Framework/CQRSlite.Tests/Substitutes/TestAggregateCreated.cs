using System;
using CQRSlite.Events;

namespace CQRSlite.Tests.Substitutes
{
    public class TestAggregateCreated : EventBase
    {
        public TestAggregateCreated() : base(Guid.Empty, typeof(Object))
        {
        }
    }
}