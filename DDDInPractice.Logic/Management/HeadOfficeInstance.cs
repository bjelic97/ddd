﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.Management
{
    public static class HeadOfficeInstance // singleton pattern
    {
        private const long HeadOfficeId = 1;

        public static HeadOffice Instance { get; private set; }

        public static void Init()
        {
            var repository = new HeadOfficeRepository();
            Instance = repository.GetById(HeadOfficeId);
        }
    }
}
