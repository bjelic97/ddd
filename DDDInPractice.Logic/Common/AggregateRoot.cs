using DDDInPractice.Logic.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public abstract class AggregateRoot : Entity
    {
        // better approach to handling domain events - create & dispatch

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
