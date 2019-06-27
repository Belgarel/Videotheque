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
        public ObservableCollection<Genre> ListGenres
        {
            get { return (ObservableCollection<Genre>)GetProperty(); }
            set { SetProperty(value); }
        }
        public string WithNameLike
        {
            get { return (string)GetProperty(); }
            set { if(SetProperty(value)) Filter.OnCanExecuteChanged(); }
        }
        public Genre WithGenre
        {
            get { return (Genre)GetProperty(); }
            set { if(SetProperty(value)) Filter.OnCanExecuteChanged(); }
        }

        public EditMedia EditMedia { get; set; }
        public Media NewMedia { get; set; } // NewMedia is an empty media that will be taken to the EditMedia page if button "Créer" is used
        public DeleteMedia DeleteMedia { get; set; }
        public BaseCommand Filter { get; set; }

        public virtual void Refresh()
        {
            this.NewMedia = new Media();
            this.NewMedia.Type = TypeMedia.Movie;
            this.WithNameLike = "";
            this.WithGenre = null;
            this.ListMedias = new ObservableCollection<Media>(MediaService.GetInstance().GetMovies());
            this.ListGenres = new ObservableCollection<Genre>(GenreService.GetInstance().GetGenres());
        }

        public bool FilterCanExecute()
        {
            return (WithGenre != null && WithGenre.Libelle != null) || (WithNameLike != null && WithNameLike != "");
        }
        public virtual void FilterExecute()
        {
            if ((WithNameLike != null && WithNameLike != "") && (WithGenre != null && WithGenre.Libelle != null))
                this.ListMedias = new ObservableCollection<Media>(
                    MediaService.GetInstance().findMediasByTypeAndTitleAndGenre(TypeMedia.Movie, WithNameLike, WithGenre));
            else if (WithNameLike != null && WithNameLike != "")
                this.ListMedias = new ObservableCollection<Media>(
                    MediaService.GetInstance().findMediasByTypeAndTitle(TypeMedia.Movie, WithNameLike));
            else //if (WithGenre != null && WithGenre.Libelle != null)
                this.ListMedias = new ObservableCollection<Media>(
                    MediaService.GetInstance().findMediasByTypeAndGenre(TypeMedia.Movie, WithGenre));
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
            this.Filter = new BaseCommand(this.FilterExecute, this.FilterCanExecute);
            this.EditMedia = new EditMedia(MainWindow, new ListMoviesPage(), this);
            this.DeleteMedia = new DeleteMedia(MainWindow, new ListMoviesPage(), this);
            this.Refresh(); // populate the list of medias by reading from the database
        }
    }
}
