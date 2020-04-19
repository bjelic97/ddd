using FluentNHibernate;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public class SnackMachineMap : ClassMap<SnackMachine>
    {
        public SnackMachineMap() // not big leak but breaks isolation of domain -> worth trade
        {
            Id(x => x.Id);

            Component(x => x.MoneyInside, y => // inline value objects fields into the parent entity table
            {
                y.Map(x => x.OneCentCount);
                y.Map(x => x.TenCentCount);
                y.Map(x => x.QuarterCount);
                y.Map(x => x.OneDollarCount);
                y.Map(x => x.FiveDollarCount);
                y.Map(x => x.TwentyDollarCount);
            });
            // Reveal cuz Slots are protected and map cannot access dem directly 
            HasMany<Slot>(Reveal.Member<SnackMachine>("Slots")).Cascade.SaveUpdate().Not.LazyLoad();
        }
    }
}
