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
        public SwitchPageParameter GoToListMovies { get; set; }
        public SwitchPageParameter GoToListSeries { get; set; }
        public SwitchPageParameter GoToListActors { get; set; }

        public void Refresh()
        {
            this.GoToListMovies = new SwitchPageParameter(this, new ListMoviesPage(), new ListMoviesModel(this));
            this.GoToListSeries = new SwitchPageParameter(this, new ListSeriesPage(), new ListSeriesModel(this));
            this.GoToListActors = new SwitchPageParameter(this, new ListPersonsPage(), new ListPersonsModel(this));
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
