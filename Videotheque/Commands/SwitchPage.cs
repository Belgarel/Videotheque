using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Videotheque.Commands
{
    class SwitchPage : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(SwitchPageParameter))
                return;
            SwitchPageParameter param = (SwitchPageParameter)parameter;

            param.MainWindow.CurrentPage = param.DestinationPage;
            param.MainWindow.CurrentPage.DataContext = param.DestinationModel;
        }
    }
}
