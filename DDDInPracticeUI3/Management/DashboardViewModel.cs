using DDDInPractice.Logic;
using DDDInPractice.Logic.Atms;
using DDDInPractice.Logic.Management;
using DDDInPractice.Logic.SnackMachines;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DDDInPracticeUI3.Management
{
    public class DashboardViewModel // : ViewModel
    {
        private readonly SnackMachineRepository _snackMachineRepository;
        private readonly AtmRepository _atmRepository;
        private readonly HeadOfficeRepository _headOfficeRepository;

        public HeadOffice HeadOffice { get; }
        public IReadOnlyList<SnackMachineDto> SnackMachines { get; private set; }
        public IReadOnlyList<AtmDto> Atms { get; private set; }

        public Command<SnackMachineDto> ShowSnackMachineCommand { get; private set; }
        public Command<SnackMachineDto> UnloadCashCommand { get; private set; }
        public Command<AtmDto> ShowAtmCommand { get; private set; }
        public Command<AtmDto> LoadCashToAtmCommand { get; private set; }

        public DashboardViewModel()
        {
            HeadOffice = HeadOfficeInstance.Instance;
            _snackMachineRepository = new SnackMachineRepository();
            _atmRepository = new AtmRepository();
            _headOfficeRepository = new HeadOfficeRepository();

            RefreshAll();

            ShowSnackMachineCommand = new Command<SnackMachineDto>(x => x != null, ShowSnackMachine);
            UnloadCashCommand = new Command<SnackMachineDto>(CanUnloadCash, UnloadCash);
            ShowAtmCommand = new Command<AtmDto>(x => x != null, ShowAtm);
            LoadCashToAtmCommand = new Command<AtmDto>(CanLoadCashToAtm, LoadCashToAtm);


        }


        private void RefreshAll()
        {
            SnackMachines = _snackMachineRepository.GetSnackMachineList();
            Atms = _atmRepository.GetAtmList();

           // Notify(nameof(Atms));
           // Notify(nameof(SnackMachines));
           // Notify(nameof(HeadOffice))
        }
    }
}
