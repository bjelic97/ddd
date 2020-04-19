using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic.SnackMachines
{
    public class SnackMachineDto
    {
        public long Id { get; private set; }
        public decimal MoneyInside { get; private set; }

        public SnackMachineDto(long id, decimal moneyInside)
        {
            Id = id;
            MoneyInside = moneyInside;
        }
    }
}
