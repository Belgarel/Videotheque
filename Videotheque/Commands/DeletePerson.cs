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

        public void Execute(object parameter)
        {
            Console.WriteLine("Delete person");
            if (parameter.GetType() != typeof(Person))
                return;
            Console.WriteLine("Delete person entered");
            PersonService.GetInstance().Delete((Person)parameter);
            Console.WriteLine("Delete person done");

            //Refresh the list of Persons
            if (this.GoToNextPage.DestinationModel is ListPersonsModel)
                ((ListPersonsModel)this.GoToNextPage.DestinationModel).Refresh();
            else if (this.GoToNextPage.DestinationModel is ListFriendsModel)
                ((ListFriendsModel)this.GoToNextPage.DestinationModel).Refresh();
            ((MainWindowModel)this.GoToNextPage.MainWindow).Refresh();
        }
        public DeletePerson(MainWindowModel mainWindowModel, Page destinationPage, BaseNotifyPropertyChanged destinationModel)
        {
            this.MainWindow = mainWindowModel;
            this.GoToNextPage = new SwitchPageParameter(mainWindowModel, destinationPage, destinationModel);
        }
    }
}
