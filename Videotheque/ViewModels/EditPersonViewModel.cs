using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videotheque.Commands;
using Videotheque.Model;
using Videotheque.Service;

namespace Videotheque.ViewModels
{
    class EditPersonViewModel : BaseNotifyPropertyChanged
    {
        public Person Person
        {
            get { return (Person)GetProperty(); }
            set
            {
                SetProperty(value);
                InitValues();
            }
        }
        public SwitchPageParameter GoToNextPage { get; set; }
        public BaseCommand Save
        {
            get
            {
                return new BaseCommand(this.SaveObject, this.CanSave);
            }
        }

        public string Title
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string FirstName
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string LastName
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string Nationality
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public DateTime BirthDate
        {
            get { return (DateTime)GetProperty(); }
            set { SetProperty(value); }
        }

        protected virtual void InitValues()
        {
            this.Title = this.Person.Title.ToString();
            this.FirstName = this.Person.FirstName ?? "";
            this.LastName = this.Person.LastName ?? "";
            this.Nationality = this.Person.Nationality ?? "";
//            this.BirthDate = this.Person.BirthDate;
        }
        private bool CanSave()
        {
            return true;
//            return (!"".Equals(this.FirstName) && !"".Equals(this.LastName));
        }
        protected virtual void SaveObject()
        {
            this.Person.FirstName = this.FirstName;
            this.Person.LastName = this.LastName;
            this.Person.Nationality = this.Nationality;
            this.Person.BirthDate = new DateTime();
            //TODO Birthdate
//            this.Person.BirthDate = this.BirthDate;

            PersonTitle Parsed;
            PersonTitle.TryParse(this.Title, out Parsed);
            this.Person.Title = Parsed;

            PersonService.GetInstance().Save(this.Person);

            ((MainWindowModel)this.GoToNextPage.MainWindow).Refresh();
            ((ListPersonsModel)this.GoToNextPage.DestinationModel).Refresh(); // refresh the list to include the new person (if a new person was created)
            new SwitchPage().Execute(this.GoToNextPage);
        }

        public EditPersonViewModel(Person person, SwitchPageParameter goToNextPage)
        {
            this.Person = person;
            this.GoToNextPage = goToNextPage;
        }
    }
}
