using DDDInPractice.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DDDInPracticeUI3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // implement sessions closest to the startup

        public App()
        {
            Initer.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true"); // better way get it from config file
        }
    }
}
