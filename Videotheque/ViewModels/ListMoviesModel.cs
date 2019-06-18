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
    class ListMoviesModel : BaseNotifyPropertyChanged
    {
        public MainWindowModel MainWindow { get; set; }
        public ObservableCollection<Media> ListMedias
        {
            get { return (ObservableCollection<Media>)GetProperty(); }
            set { SetProperty(value); }
        }

        public EditMedia EditMedia { get; set; }
        public Media NewMedia { get; set; } // NewMedia is an empty media that will be taken to the EditMedia page if button "Créer" is used

        public DeleteMedia DeleteMedia { get; set; }

        public virtual void Refresh()
        {
            this.NewMedia = new Media();
            this.NewMedia.Type = TypeMedia.Movie;
            this.ListMedias = new ObservableCollection<Media>(MediaService.GetInstance().GetMovies());
        }

        public ListMoviesModel(MainWindowModel MainWindow)
        {
            this.MainWindow = MainWindow;
            this.EditMedia = new EditMedia(MainWindow, new ListMoviesPage(), this);
            this.DeleteMedia = new DeleteMedia(MainWindow, new ListMoviesPage(), this);
            this.Refresh(); // populate the list of medias by reading from the database
        }
    }
}
