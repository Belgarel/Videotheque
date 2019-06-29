using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Commands;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.Views;

namespace Videotheque.ViewModels
{
    class ListPersonsModel : ListFriendsModel
    {
        public PersonMediaFunction? WithFunction
        {
            get { return (PersonMediaFunction?)GetProperty() ?? PersonMediaFunction.Unknown; }
            set { if (SetProperty(value)) Filter.OnCanExecuteChanged(); }
        }
        public override void Refresh()
        {
            this.NewPerson = new Person();
            this.NewPerson.Type = TypePerson.Other;
            this.ListPersons = new ObservableCollection<Person>(PersonService.GetInstance().GetPersonsNotFriends());
            this.WithNameLike = "";
        }

        public override void FilterExecute()
        {
            this.ListPersons = new ObservableCollection<Person>(
                PersonService.GetInstance().findPersonByNameAndFunction(WithNameLike, WithFunction));
        }

        public ListPersonsModel(MainWindowModel MainWindow) : base(MainWindow)
        {
            this.EditPerson = new EditPerson(MainWindow, new ListPersonsPage(), this);
            this.DeletePerson = new DeletePerson(MainWindow, new ListPersonsPage(), this);
        }
    }
}
