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
    class ListPersonsModel : AbstractSortableViewModel
    {
        public MainWindowModel MainWindow { get; set; }
        public ObservableCollection<Person> ListPersons
        {
            get { return (ObservableCollection<Person>)GetProperty(); }
            set { SetProperty(value); }
        }

        public EditPerson EditPerson { get; set; }
        public Person NewPerson { get; set; } // NewPerson is an empty person that will be taken to the EditPerson page if button "Créer" is used

        public DeletePerson DeletePerson { get; set; }

        public virtual void Refresh()
        {
            this.NewPerson = new Person();
            this.ListPersons = new ObservableCollection<Person>(PersonService.GetInstance().GetPersons());
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

        public ListPersonsModel(MainWindowModel MainWindow)
        {
            this.MainWindow = MainWindow;
            this.EditPerson = new EditPerson(MainWindow, new ListPersonsPage(), this);
            this.DeletePerson = new DeletePerson(MainWindow, new ListPersonsPage(), this);
            this.Refresh(); // populate the list of medias by reading from the database
        }
    }
}
