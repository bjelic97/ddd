using DDDInPractice.Logic;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDInPracticeUI3
{
    public class SnackMachineViewModel // : ViewModel
    {
        private readonly SnackMachine _snackMachine;

        private readonly SnackMachineRepository _repository;

        // public override string Caption => "Snack Machine";

        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString(); // label
        public Money MoneyInside => _snackMachine.MoneyInside;

        public IReadOnlyList<SnackPileViewModel> Piles // MVVM Hierarchical view models
        {
            get
            {
                return _snackMachine.GetAllSnackPiles().Select(x => new SnackPileViewModel(x)).ToList();
            }
        }

        private string _message = "";

        public string Message
        {
            get { return _message; }
            private set
            {
                _message = value;
                // Notify();
            }
        }

        //  public Command InsertCentCommand { get; private set; }
        //  public Command InsertTenCentCommand { get; private set; }
        //  public Command InsertQuarterCommand { get; private set; }
        //  public Command InsertDollarCommand { get; private set; }
        //  public Command InsertFiveDollarCommand { get; private set; }
        //  public Command InsertTwentyDollarCommand { get; private set; }
        // public Command ReturnMoneyCommand {get; private set; }
        // public Command<string> BuySnackCommand {get; private set; }

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;
            _repository = new SnackMachineRepository();
            //    InsertCentCommand = new Command(() => InsertMoney(Money.Cent));
            //    InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
            //    InsertQuarterCommand = new Command(() => InsertMoney(Money.Quarter));
            //    InsertDollarCommand = new Command(() => InsertMoney(Money.Dollar));
            //    InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
            //    InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
            //    ReturnMoneyCommand = new Command(()=> ReturnMoney());
            //    BuySnackCommand = new Command<string>(BuySnack);
        }


        private void BuySnack(string positionString) // handling client exception -> could return value and then by value serving client correct one
                                                     // but it violates CQRS pattern
        {
            int position = int.Parse(positionString);

            string error = _snackMachine.CanBuySnack(position);
            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            _snackMachine.BuySnack(position);
            _repository.Save(_snackMachine);
            //using (ISession session = SessionFactory.OpenSession())
            //using (ITransaction transaction = session.BeginTransaction())
            //{
            //    session.SaveOrUpdate(_snackMachine);
            //    transaction.Commit();
            //}
            NotifyClient("You have bought a snack");
        }

        private void ReturnMoney()
        {
            _snackMachine.ReturnMoney();
            NotifyClient("Money was returned");
        }
        private void InsertMoney(Money coinOrNote)
        {
            _snackMachine.InsertMoney(coinOrNote);
            NotifyClient("You have inserted: " + coinOrNote);
        }

        private void NotifyClient(string message)
        {
            Message = message;
            // Notify(nameof(MoneyInTransaction));
            // Notify(nameof(MoneyInside));
            // Notify(nameof(Piles));
        }
    }
}
