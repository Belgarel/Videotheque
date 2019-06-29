using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Videotheque.Commands;
using Videotheque.Model;
using Videotheque.Views;

namespace Videotheque.ViewModels
{
    class MainWindowModel : BaseNotifyPropertyChanged
    {
        public Page CurrentPage
        {
            get { return (Page)GetProperty(); }
            set { SetProperty(value); }
        }

        public SwitchPage SwitchPage { get; }
        public SwitchPageParameter GoToListMovies
        {
            get { return (SwitchPageParameter)GetProperty(); }
            set { SetProperty(value); }
        }
        public SwitchPageParameter GoToListSeries
        {
            get { return (SwitchPageParameter)GetProperty(); }
            set { SetProperty(value); }
        }
        public SwitchPageParameter GoToListActors
        {
            get { return (SwitchPageParameter)GetProperty(); }
            set { SetProperty(value); }
        }
        public SwitchPageParameter GoToListFriends
        {
            get { return (SwitchPageParameter)GetProperty(); }
            set { SetProperty(value); }
        }

        public void Refresh()
        {
            // Oui, c'est bourrin.
            this.GoToListMovies = new SwitchPageParameter(this, new ListMoviesPage(), new ListMoviesModel(this));
            this.GoToListSeries = new SwitchPageParameter(this, new ListSeriesPage(), new ListSeriesModel(this));
            this.GoToListActors = new SwitchPageParameter(this, new ListPersonsPage(), new ListPersonsModel(this));
            this.GoToListFriends = new SwitchPageParameter(this, new ListFriendsPage(), new ListFriendsModel(this));
        }
        public void Loading()
        {
            this.CurrentPage = new LoadingPage();
        }
        public void Movies()
        {
            // Vraiment...
            this.Refresh();
            SwitchPage.Execute(this.GoToListMovies);
        }
        public void Series()
        {
            // Vraiment...
            this.Refresh();
            SwitchPage.Execute(this.GoToListSeries);
        }
        public void Actors()
        {
            // Très...
            this.Refresh();
            SwitchPage.Execute(this.GoToListActors);
        }
        public void Friends()
        {
            // Bourrin.
            this.Refresh();
            SwitchPage.Execute(this.GoToListFriends);
        }


        public MainWindowModel()
        {
            this.CurrentPage = new ListMoviesPage();
            this.CurrentPage.DataContext = new ListMoviesModel(this);
            this.SwitchPage = new SwitchPage();
            this.Refresh();
        }
    }
}
