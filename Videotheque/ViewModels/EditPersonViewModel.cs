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
        public ObservableCollection<PersonMedia> Roles
        {
            get { return (ObservableCollection<PersonMedia>)GetProperty(); }
            set { SetProperty(value); }
        }
        public List<Media> Medias { get; set; }
        public Media SelectedMedia
        {
            get { return (Media)GetProperty(); }
            set { if (SetProperty(value)) AddRole.OnCanExecuteChanged(); }
        }
        public PersonMedia SelectedRole
        {
            get { return (PersonMedia)GetProperty(); }
            set { if (SetProperty(value)) RemoveRole.OnCanExecuteChanged(); }
        }
        public BaseCommand RemoveRole { get; }
        public BaseCommand AddRole { get; }

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
            this.Roles = roles;
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

            this.Person.PersonMedias = this.Roles.ToList();

            PersonService.GetInstance().Save(this.Person);

            ((MainWindowModel)this.GoToNextPage.MainWindow).Refresh();
            ((ListPersonsModel)this.GoToNextPage.DestinationModel).Refresh(); // refresh the list to include the new person (if a new person was created)
            new SwitchPage().Execute(this.GoToNextPage);
        }

        private bool CanRemoveRole() { return this.SelectedRole != null; }
        private void RemoveRoleExecute()
        {
            if (this.Roles == null)
                return;
            this.Roles.Remove(this.SelectedRole);
        }
        private bool CanAddRole() { return this.SelectedMedia != null; }
        private void AddRoleExecute()
        {
            if (this.SelectedMedia == null)
                return;
            if (this.Roles == null)
                this.Roles = new ObservableCollection<PersonMedia>();
            PersonMedia newRole = new PersonMedia();
            newRole.Media = this.SelectedMedia;
            this.Roles.Add(newRole);
            this.SelectedMedia = null;
        }

        public EditPersonViewModel(Person person, SwitchPageParameter goToNextPage)
        {
            this.Person = person;
            this.Medias = MediaService.GetInstance().GetMedias();
            this.RemoveRole = new BaseCommand(this.RemoveRoleExecute, this.CanRemoveRole);
            this.AddRole = new BaseCommand(this.AddRoleExecute, this.CanAddRole);
            this.GoToNextPage = goToNextPage;
        }
    }
}
