using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Commands;
using Videotheque.Model;
using Videotheque.Views;

namespace Videotheque.ViewModels
{
    class ListSeriesModel : ListMoviesModel
    {
        public override void Refresh()
        {
            this.NewMedia = new Media();
            this.NewMedia.Type = TypeMedia.Series;

            //For testing purposes
            List<Media> liste = new List<Media>();
            //Creating a series
            Media babylon5 = new Media();
            babylon5.Type = TypeMedia.Series;
            babylon5.MediaId = 5;
            babylon5.Title = "Babylon 5";
            babylon5.Comment = "Londo 4ever";
            babylon5.Seen = true;
            babylon5.Rated = 5;
            babylon5.LanguageVO = Language.English;
            babylon5.LanguageMedia = Language.English;
            babylon5.LanguageSubtitles = Language.French;
            babylon5.NumericalSupport = true;

            Genre so = new Genre();
            so.GenreId = 1;
            so.Libelle = "Space Opera";
            GenreMedia bso = new GenreMedia();
            bso.MediaId = 5;
            bso.GenreId = 1;
            bso.Genre = so;
            Genre aliens = new Genre();
            aliens.GenreId = 2;
            aliens.Libelle = "Aliens";
            GenreMedia ba = new GenreMedia();
            ba.MediaId = 5;
            ba.GenreId = 2;
            ba.Genre = aliens;
            Genre sf = new Genre();
            sf.GenreId = 3;
            sf.Libelle = "SF";
            GenreMedia bsf = new GenreMedia();
            bsf.MediaId = 5;
            bsf.GenreId = 3;
            bsf.Genre = sf;
            List<GenreMedia> gmList = new List<GenreMedia>();
            gmList.Add(bso);
            gmList.Add(ba);
            gmList.Add(bsf);
            babylon5.GenreMedias = gmList;

            Episode ep1 = new Episode();
            ep1.EpisodeId = 1;
            ep1.NumSeason = 1;
            ep1.NumEpisode = 1;
            ep1.Title = "Londo est sympa";
            ep1.Description = "Londo est encore au casino";
            ep1.Media = babylon5;
            ep1.MediaId = 5;
            Episode ep2 = new Episode();
            ep2.EpisodeId = 2;
            ep2.NumSeason = 1;
            ep2.NumEpisode = 2;
            ep2.Title = "Londo est triste";
            ep2.Description = "Adira s'est faite tuer :(";
            ep2.Media = babylon5;
            ep2.MediaId = 5;
            Episode ep3 = new Episode();
            ep3.EpisodeId = 3;
            ep3.NumSeason = 1;
            ep3.NumEpisode = 3;
            ep3.Title = "Londo est méchant";
            ep3.Description = "Tu connais l'histoire de la planète Narne et du vieux Centauri ?";
            ep3.Media = babylon5;
            ep3.MediaId = 5;
            List<Episode> episodes = new List<Episode>();
            episodes.Add(ep1);
            episodes.Add(ep2);
            episodes.Add(ep3);
            babylon5.Episodes = episodes;

            liste.Add(babylon5);
            this.ListMedias = liste;
        }

        public ListSeriesModel(MainWindowModel MainWindow) :
            base(MainWindow)
        {
            this.EditMedia = new EditMedia(MainWindow, new ListSeriesPage(), this);
        }
    }
}
