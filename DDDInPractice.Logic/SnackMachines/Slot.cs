using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPractice.Logic
{
    public class Slot : Entity
    {
        //public virtual Snack Snack { get; set; } // always together => extract into value object
        //public virtual int Quantity { get; set; } // always together => extract into value object
        //public virtual decimal Price { get; set; } // always together => extract into value object

        public virtual SnackPile SnackPile { get; set; }
        public virtual SnackMachine SnackMachine { get; set; }
        public virtual int Position { get; set; }

        protected Slot()
        {

        }

        public Slot(SnackMachine snackMachine, int position) : this()
        {
            //  SnackPile = new SnackPile(null, 0, 0m); // => should go for null value design pattern => decreases chance of negative behavior that can appear because of nulls
            // SnackPile = new SnackPile(Snack.None, 0, 0m);
            SnackPile = SnackPile.Empty;
            SnackMachine = snackMachine;
            Position = position;
        }
    }
}
