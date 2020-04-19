using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDInPractice.Logic.Atms
{
    public class AtmRepository : Repository<Atm>
    {
        public IReadOnlyList<AtmDto> GetAtmList()
        {
            using ISession session = SessionFactory.OpenSession(); // better done with lightweight Dapper ORM if more data
            return session.Query<Atm>()
                            .ToList()
                            .Select(x => new AtmDto(x.Id, x.MoneyInside.Amount))
                            .ToList();
        }
    }
}
