using DDDInPractice.Logic.SnackMachines;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDInPractice.Logic
{
    public class SnackMachineRepository : Repository<SnackMachine>
    {
        public IReadOnlyList<SnackMachineDto> GetSnackMachineList()
        {
            using ISession session = SessionFactory.OpenSession();
            return session.Query<SnackMachine>()
                            .ToList()
                            .Select(x => new SnackMachineDto(x.Id, x.MoneyInside.Amount))
                            .ToList();
        }
    }
}
