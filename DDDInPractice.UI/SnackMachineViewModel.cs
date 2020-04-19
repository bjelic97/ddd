using DDDInPractice.Logic;
using System;

namespace DDDInPractice.UI
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine snackMachine;

        public override string Caption => "Snack Machine";

        public SnackMachineViewModel(SnackMachine snackMachine)
        {

        }
    }
}
