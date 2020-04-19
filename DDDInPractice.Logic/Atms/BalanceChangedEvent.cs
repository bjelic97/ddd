using DDDInPractice.Logic.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.Atms
{
    public class BalanceChangedEvent : IDomainEvent
    {
        public decimal Delta { get; private set; }

        public BalanceChangedEvent(decimal delta)
        {
            Delta = delta;
        }
    }
}
