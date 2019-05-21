using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Videotheque.ViewModels;

namespace Videotheque.Commands
{
    class SwitchPageParameter
    {
        public MainWindowModel MainWindow { get; set; }
        public Page DestinationPage { get; set; }
        public BaseNotifyPropertyChanged DestinationModel { get; set; }

        public SwitchPageParameter(MainWindowModel mainWindow, Page destinationPage, BaseNotifyPropertyChanged destinationModel)
        {
            this.MainWindow = mainWindow;
            this.DestinationPage = destinationPage;
            this.DestinationModel = destinationModel;
        }
    }
}
