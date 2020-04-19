using DDDInPractice.Logic.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.Atms
{
    public class BalanceChangedEventHandler : IHandler<BalanceChangedEvent>
    {
        public void Handle(BalanceChangedEvent domainEvent)
        {
           // EsbGateway.Instance.SendBalanceChangedMessage(domainEvent.Delta);
        }
    }
}
