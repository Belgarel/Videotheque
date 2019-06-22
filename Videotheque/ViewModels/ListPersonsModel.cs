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
    class ListPersonsModel : BaseNotifyPropertyChanged
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

        public ListPersonsModel(MainWindowModel MainWindow)
        {
            this.MainWindow = MainWindow;
            this.EditPerson = new EditPerson(MainWindow, new ListPersonsPage(), this);
            this.DeletePerson = new DeletePerson(MainWindow, new ListPersonsPage(), this);
            this.Refresh(); // populate the list of medias by reading from the database
        }
    }
}
