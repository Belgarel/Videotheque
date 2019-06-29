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
    class ListFriendsModel : AbstractSortableViewModel
    {
        public MainWindowModel MainWindow { get; set; }
        public ObservableCollection<Person> ListPersons
        {
            get { return (ObservableCollection<Person>)GetProperty(); }
            set { SetProperty(value); }
        }
        public string WithNameLike
        {
            get { return (string)GetProperty(); }
            set { if (SetProperty(value)) Filter.OnCanExecuteChanged(); }
        }

        public EditPerson EditPerson { get; set; }
        public Person NewPerson { get; set; } // NewPerson is an empty person that will be taken to the EditPerson page if button "Créer" is used
        public DeletePerson DeletePerson { get; set; }
        public BaseCommand Filter { get; set; }

        public virtual void Refresh()
        {
            this.NewPerson = new Person();
            this.NewPerson.Type = TypePerson.Friend;
            this.ListPersons = new ObservableCollection<Person>(PersonService.GetInstance().GetFriends());
            this.WithNameLike = "";
        }

        public virtual void FilterExecute()
        {
            this.ListPersons = new ObservableCollection<Person>(
                PersonService.GetInstance().findFriendWithName(WithNameLike));
        }

        public override void SortByTitleAscExecute()
        {
            this.ListPersons = new ObservableCollection<Person>(
                this.ListPersons.OrderBy(p => p.LastName).ThenBy(p => p.FirstName));
        }
        public override void SortByTitleDescExecute()
        {
            this.ListPersons = new ObservableCollection<Person>(
                this.ListPersons.OrderByDescending(p => p.LastName).ThenByDescending(p => p.FirstName));
        }
        public override void SortByDateAscExecute()
        {
            this.ListPersons = new ObservableCollection<Person>(this.ListPersons.OrderBy(p => p.BirthDate));
        }
        public override void SortByDateDescExecute()
        {
            this.ListPersons = new ObservableCollection<Person>(this.ListPersons.OrderByDescending(p => p.BirthDate));
        }
        public override void SortByRatingAscExecute()
        {
            throw new NotImplementedException();
        }
        public override void SortByRatingDescExecute()
        {
            throw new NotImplementedException();
        }

        public ListFriendsModel(MainWindowModel MainWindow)
        {
            this.MainWindow = MainWindow;
            this.Filter = new BaseCommand(this.FilterExecute);
            this.EditPerson = new EditFriend(MainWindow, new ListFriendsPage(), this);
            this.DeletePerson = new DeletePerson(MainWindow, new ListFriendsPage(), this);
            this.Refresh(); // populate the list of medias by reading from the database
        }
    }
}
