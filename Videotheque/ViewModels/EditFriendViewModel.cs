using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videotheque.Commands;
using Videotheque.Model;
using Videotheque.Service;

namespace Videotheque.ViewModels
{
    class EditFriendViewModel : BaseNotifyPropertyChanged
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
        public BaseCommand Save { get; set; }

        public string Title
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string FirstName
        {
            get { return (string)GetProperty(); }
            set { if (SetProperty(value)) Save.OnCanExecuteChanged(); }
        }
        public string LastName
        {
            get { return (string)GetProperty(); }
            set { if (SetProperty(value)) Save.OnCanExecuteChanged(); }
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

            ObservableCollection<PersonMedia> roles = new ObservableCollection<PersonMedia>();
            if (this.Person.PersonMedias != null)
                foreach (PersonMedia pm in this.Person.PersonMedias)
                    roles.Add(pm);
        }

        private bool CanSave()
        {
            return (this.FirstName != null && this.LastName != null
                && !"".Equals(this.FirstName) && !"".Equals(this.LastName));
        }
        protected virtual async void SaveObject()
        {
            this.Person.FirstName = this.FirstName;
            this.Person.LastName = this.LastName;
            this.Person.Nationality = this.Nationality;
            this.Person.BirthDate = new DateTime();
//            this.Person.BirthDate = this.BirthDate;

            PersonTitle Parsed;
            PersonTitle.TryParse(this.Title, out Parsed);
            this.Person.Title = Parsed;

            await PersonService.GetInstance().Save(this.Person, this.Loading);

            ((MainWindowModel)this.GoToNextPage.MainWindow).Friends();
        }
        public void Loading()
        {

            ((MainWindowModel)this.GoToNextPage.MainWindow).Loading();
        }

        public EditFriendViewModel(Person person, SwitchPageParameter goToNextPage)
        {
            this.Save = new BaseCommand(this.SaveObject, this.CanSave);
            this.Person = person;
            this.GoToNextPage = goToNextPage;
        }
        protected EditFriendViewModel(SwitchPageParameter goToNextPage)
        {
            this.Save = new BaseCommand(this.SaveObject, this.CanSave);
            this.GoToNextPage = goToNextPage;
        }
    }
}
