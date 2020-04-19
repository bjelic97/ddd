using DDDInPractice.Logic;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPracticeUI3.Common
{
    public class MainViewModel // : ViewModel
    {
        public MainViewModel()
        {
            // var viewModel = new SnackMachineViewModel(new SnackMachine());
            // _dialogService.ShowDialog(viewModel);


            SnackMachine snackMachine = new SnackMachineRepository().GetById(1);
            
            //SnackMachine snackMachine;
            //using (ISession session = SessionFactory.OpenSession())
            //{
            //    snackMachine = session.Get<SnackMachine>(1L);
            //}
            var viewModel = new SnackMachineViewModel(snackMachine);
            // _dialogService.ShowDialog(viewModel);
        }
    }
}
