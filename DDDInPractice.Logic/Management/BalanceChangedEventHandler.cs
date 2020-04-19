using DDDInPractice.Logic.Atms;
using DDDInPractice.Logic.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.Management
{
    public class BalanceChangedEventHandler : IHandler<BalanceChangedEvent>
    {
        public void Handle(BalanceChangedEvent domainEvent)
        {
            var repository = new HeadOfficeRepository();
            HeadOffice headOffice = HeadOfficeInstance.Instance;
            headOffice.ChangeBalance(domainEvent.Delta);
            repository.Save(headOffice);
        }
    }
}
