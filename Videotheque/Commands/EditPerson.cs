using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Videotheque.Model;
using Videotheque.ViewModels;
using Videotheque.Views;

namespace Videotheque.Commands
{
    class EditPerson : ICommand
    {
        public MainWindowModel MainWindow { get; set; }
        public SwitchPageParameter GoToNextPage { get;set;}
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(Person))
                return;
            Person person = (Person) parameter;

            this.MainWindow.CurrentPage = new EditPersonPage();
            this.MainWindow.CurrentPage.DataContext = new EditPersonViewModel(person, this.GoToNextPage);

            //Refresh the list of persons
            ((ListPersonsModel)this.GoToNextPage.DestinationModel).Refresh();
            ((MainWindowModel)this.GoToNextPage.MainWindow).Refresh();
        }
        public EditPerson(MainWindowModel mainWindowModel, Page destinationPage, BaseNotifyPropertyChanged destinationModel)
        {
            this.MainWindow = mainWindowModel;
            this.GoToNextPage = new SwitchPageParameter(mainWindowModel, destinationPage, destinationModel);
        }
    }
}
