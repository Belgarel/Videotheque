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
        public SwitchPageParameter GoToListMovies { get; }
        public SwitchPageParameter GoToListSeries { get; }
        public SwitchPageParameter GoToListActors { get; }


        public MainWindowModel()
        {
            this.CurrentPage = new ListMoviesPage();
            this.CurrentPage.DataContext = new ListMoviesModel(this);

            this.SwitchPage = new SwitchPage();
            this.GoToListMovies = new SwitchPageParameter(this, new ListMoviesPage(), new ListMoviesModel(this));
            this.GoToListSeries = new SwitchPageParameter(this, new ListSeriesPage(), new ListSeriesModel(this));
            this.GoToListActors = new SwitchPageParameter(this, new ListMoviesPage(), new ListMoviesModel(this));
        }
    }
}
