using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.ViewModels;
using Videotheque.Views;

namespace Videotheque.Commands
{
    class DeletePerson : ICommand
    {
        public MainWindowModel MainWindow { get; set; }
        public SwitchPageParameter GoToNextPage { get;set;}
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(Person))
                return;
            await PersonService.GetInstance().Delete((Person)parameter, Loading);

            //Refresh the list of Persons
            if (this.GoToNextPage.DestinationModel is ListPersonsModel)
                ((MainWindowModel)this.GoToNextPage.MainWindow).Actors();
            else if (this.GoToNextPage.DestinationModel is ListFriendsModel)
                ((MainWindowModel)this.GoToNextPage.MainWindow).Friends();
        }
        public void Loading()
        {
            ((MainWindowModel)this.GoToNextPage.MainWindow).Loading();
        }
        public DeletePerson(MainWindowModel mainWindowModel, Page destinationPage, BaseNotifyPropertyChanged destinationModel)
        {
            this.MainWindow = mainWindowModel;
            this.GoToNextPage = new SwitchPageParameter(mainWindowModel, destinationPage, destinationModel);
        }
    }
}
