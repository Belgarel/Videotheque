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
    class ListSeriesModel : ListMoviesModel
    {
        public override void Refresh()
        {
            this.NewMedia = new Media();
            this.NewMedia.Type = TypeMedia.Series;
            this.ListMedias = new ObservableCollection<Media>(MediaService.GetInstance().GetSeries());
            this.ListGenres = new ObservableCollection<Genre>(GenreService.GetInstance().GetGenres());
        }

        public override void FilterExecute()
        {
            if ((WithNameLike != null && WithNameLike != "") && (WithGenre != null && WithGenre.Libelle != null))
                this.ListMedias = new ObservableCollection<Media>(
                    MediaService.GetInstance().findMediasByTypeAndTitleAndGenre(TypeMedia.Series, WithNameLike, WithGenre));
            else if (WithNameLike != null && WithNameLike != "")
                this.ListMedias = new ObservableCollection<Media>(
                    MediaService.GetInstance().findMediasByTypeAndTitle(TypeMedia.Series, WithNameLike));
            else //if (WithGenre != null && WithGenre.Libelle != null)
                this.ListMedias = new ObservableCollection<Media>(
                    MediaService.GetInstance().findMediasByTypeAndGenre(TypeMedia.Series, WithGenre));
        }

        public ListSeriesModel(MainWindowModel MainWindow) :
            base(MainWindow)
        {
            this.EditMedia = new EditMedia(MainWindow, new ListSeriesPage(), this);
        }
    }
}
