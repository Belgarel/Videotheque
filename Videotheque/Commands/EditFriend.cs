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
    class EditFriend : EditPerson
    {

        public override void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(Person))
                return;
            Person person = (Person) parameter;

            this.MainWindow.CurrentPage = new EditFriendPage();
            this.MainWindow.CurrentPage.DataContext = new EditFriendViewModel(person, this.GoToNextPage);

            //Refresh the list of persons
            ((ListFriendsModel)this.GoToNextPage.DestinationModel).Refresh();
            ((MainWindowModel)this.GoToNextPage.MainWindow).Refresh();
        }
        public EditFriend(MainWindowModel mainWindowModel, Page destinationPage, BaseNotifyPropertyChanged destinationModel) :
            base(mainWindowModel, destinationPage, destinationModel)
        {
        }
    }
}
