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
    class ListMoviesModel : AbstractSortableViewModel
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

        public override void SortByTitleAscExecute()
        {
            this.ListMedias = new ObservableCollection<Media>(this.ListMedias.OrderBy(m => m.Title));
        }
        public override void SortByTitleDescExecute()
        {
            this.ListMedias = new ObservableCollection<Media>(this.ListMedias.OrderByDescending(m => m.Title));
        }
        public override void SortByDateAscExecute()
        {
            this.ListMedias = new ObservableCollection<Media>(this.ListMedias.OrderBy(m => m.DateRelease));
        }
        public override void SortByDateDescExecute()
        {
            this.ListMedias = new ObservableCollection<Media>(this.ListMedias.OrderByDescending(m => m.DateRelease));
        }
        public override void SortByRatingAscExecute()
        {
            this.ListMedias = new ObservableCollection<Media>(this.ListMedias.OrderBy(m => m.Rated));
        }
        public override void SortByRatingDescExecute()
        {
            this.ListMedias = new ObservableCollection<Media>(this.ListMedias.OrderByDescending(m => m.Rated));
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
