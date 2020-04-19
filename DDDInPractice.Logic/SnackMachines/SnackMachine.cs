using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static DDDInPractice.Logic.Money;

namespace DDDInPractice.Logic
{
    // 1. hibernates requires not to be sealed
    // 2. mark all non-private members as virtual
    // 3. setters cannot be private
    // 4. all entities and value objects should have parameterless constructor -> hibernate creates entities via reflection -> doenst have to be public -> compiler adds automaticly if don't have
    // reason for this -> hibernate creates proxy classes on top of entities and overrides all non private members in them
    public class SnackMachine : AggregateRoot
    {

        public virtual Money MoneyInside { get; protected set; } = None;
        //public virtual Money MoneyInTransaction { get; protected set; } = None;
        public virtual decimal MoneyInTransaction { get; protected set; }
        protected virtual IList<Slot> Slots { get; set; }


        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = 0;
            Slots = new List<Slot>
            {
            //    new Slot(null,0,0m,this,1),
            //    new Slot(null,0,0m,this,2),
            //    new Slot(null,0,0m,this,3)
                new Slot(this,1),
                new Slot(this,2),
                new Slot(this,3)
             };
        }

        public virtual SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        public virtual IReadOnlyList<SnackPile> GetAllSnackPiles()
        {
            return Slots
                .OrderBy(x => x.Position)
                .Select(x => x.SnackPile)
                .ToList();
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();
            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public virtual void ReturnMoney()
        {
            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0; // keeping it immutable
        }


        // solution for client errors display

        public virtual string CanBuySnack(int position)
        {
            SnackPile snackPile = GetSnackPile(position);

            if(snackPile.Quantity == 0)      
                return "The snack pile is empty";

            if (MoneyInTransaction < snackPile.Price)
                return "Not enough money";

            if (!MoneyInside.CanAllocate(MoneyInTransaction - snackPile.Price))
                return "Not enough change";

            return string.Empty;
 
        }


        public virtual void BuySnack(int position)
        {
            if (CanBuySnack(position) != string.Empty)
                throw new InvalidOperationException();

            Slot slot = GetSlot(position);
            // slot.Quantity--;
            //if (slot.SnackPile.Price > MoneyInTransaction) now we don't need these checks
            //    throw new InvalidOperationException();
            slot.SnackPile = slot.SnackPile.SubstractOne();
            // MoneyInside += MoneyInTransaction;
            // MoneyInTransaction = None;
            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            //if (change.Amount < MoneyInTransaction - slot.SnackPile.Price)  now we don't need these checks
            //    throw new InvalidOperationException();
            MoneyInside -= change;
            MoneyInTransaction = 0;
        }

        public virtual void LoadSnacks(int position, SnackPile snackPile)
        {
            Slot slot = Slots.Single(x => x.Position == position);
            //slot.Snack = snack;
            //slot.Quantity = quantity;
            //slot.Price = price;
            slot.SnackPile = snackPile;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}
