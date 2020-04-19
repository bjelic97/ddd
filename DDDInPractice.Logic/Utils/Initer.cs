using DDDInPractice.Logic.Common;
using DDDInPractice.Logic.Management;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public static class Initer
    {
        // invoked on the application startup 
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);
            HeadOfficeInstance.Init();
            DomainEvents.Init();
        }
    }
}
