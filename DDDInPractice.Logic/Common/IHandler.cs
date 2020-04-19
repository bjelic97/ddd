using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.Common
{
    interface IHandler<T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
