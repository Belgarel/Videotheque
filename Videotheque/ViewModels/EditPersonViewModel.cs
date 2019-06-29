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
    class EditPersonViewModel : EditFriendViewModel
    {
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
        public PersonMediaFunction? SelectedFunction
        {
            get { return (PersonMediaFunction?)GetProperty(); }
            set { if (SetProperty(value)) AddRole.OnCanExecuteChanged(); }
        }
        public string NewRole
        {
            get { return (string)GetProperty(); }
            set { if (SetProperty(value)) AddRole.OnCanExecuteChanged(); }
        }
        public PersonMedia SelectedRole
        {
            get { return (PersonMedia)GetProperty(); }
            set { if (SetProperty(value)) RemoveRole.OnCanExecuteChanged(); }
        }
        public BaseCommand RemoveRole { get; }
        public BaseCommand AddRole { get; }

        protected override void InitValues()
        {
            base.InitValues();
            ObservableCollection<PersonMedia> roles = new ObservableCollection<PersonMedia>();
            if (this.Person.PersonMedias != null)
                foreach (PersonMedia pm in this.Person.PersonMedias)
                    roles.Add(pm);
            this.Roles = roles;
            this.NewRole = "";
        }
        protected override void SaveObject()
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
            newRole.Function = this.SelectedFunction ?? PersonMediaFunction.Unknown;
            newRole.Role = this.NewRole;
            this.Roles.Add(newRole);
            this.SelectedMedia = null;
            this.SelectedFunction = null;
            this.NewRole = "";
        }

        public EditPersonViewModel(Person person, SwitchPageParameter goToNextPage) :
            base(goToNextPage)
        {
            this.RemoveRole = new BaseCommand(this.RemoveRoleExecute, this.CanRemoveRole);
            this.AddRole = new BaseCommand(this.AddRoleExecute, this.CanAddRole);
            this.Medias = MediaService.GetInstance().GetMedias();
            this.Person = person;
        }
    }
}
