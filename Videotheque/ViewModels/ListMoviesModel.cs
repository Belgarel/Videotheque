using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Commands;
using Videotheque.Model;

namespace Videotheque.ViewModels
{
    class ListMoviesModel : BaseNotifyPropertyChanged
    {
        public MainWindowModel MainWindow { get; set; }
        public List<Media> ListMovies
        {
            get { return (List<Media>)GetProperty(); }
            set { SetProperty(value); }
        }

        public EditMedia EditMedia { get; }
        public ListMoviesModel(MainWindowModel MainWindow)
        {
            this.MainWindow = MainWindow;
            this.EditMedia = new EditMedia(MainWindow);

            //For testing purposes
            List < Media > liste = new List<Media>();
            Media matrix = new Media();
            matrix.MediaId = 1;
            matrix.Type = TypeMedia.Movie;
            matrix.Rated = 4;
            matrix.Title = "Matrix";
            matrix.Comment = "Genius.";
            matrix.Duration = 130;
            matrix.LanguageVO = Language.English;
            matrix.LanguageMedia = Language.English;
            matrix.PhysicalSupport = true;
            Media fightClub = new Media();
            fightClub.MediaId = 2;
            fightClub.Type = TypeMedia.Movie;
            fightClub.Seen = false;
            fightClub.Rated = 2;
            fightClub.Title = "Fight Club";
            fightClub.Comment = "I'd rather not talk about it";
            fightClub.Duration = 300;
            fightClub.MinAge = 9;
            fightClub.LanguageVO = Language.English;
            fightClub.LanguageMedia = Language.Japanese;
            fightClub.PhysicalSupport = false;
            fightClub.NumericalSupport = true;

            Genre robots = new Genre();
            robots.GenreId = 1;
            robots.Libelle = "Robots";
            GenreMedia fcr = new GenreMedia();
            fcr.MediaId = 2;
            fcr.GenreId = 1;
            fcr.Genre = robots;
            Genre aliens = new Genre();
            aliens.GenreId = 2;
            aliens.Libelle = "Aliens";
            GenreMedia fca = new GenreMedia();
            fca.MediaId = 2;
            fca.GenreId = 2;
            fca.Genre = aliens;
            Genre cartoon = new Genre();
            cartoon.GenreId = 3;
            cartoon.Libelle = "Cartoon";
            GenreMedia fcc = new GenreMedia();
            fcc.MediaId = 2;
            fcc.GenreId = 3;
            fcc.Genre = cartoon;
            List<GenreMedia> gmList = new List<GenreMedia>();
            gmList.Add(fcr);
            gmList.Add(fca);
            gmList.Add(fcc);
            fightClub.GenreMedias = gmList;
            liste.Add(matrix);
            liste.Add(fightClub);

            this.ListMovies = liste;
        }
    }
}
