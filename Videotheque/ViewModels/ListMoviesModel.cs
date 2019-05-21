using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.ViewModels
{
    class ListMoviesModel : BaseNotifyPropertyChanged
    {
        public List<Media> ListMovies
        {
            get { return (List<Media>)GetProperty(); }
            set { SetProperty(value); }
        }

        public ListMoviesModel()
        {
            //For testing purposes
            List < Media > liste = new List<Media>();
            Media matrix = new Media();
            matrix.Type = TypeMedia.Movie;
            matrix.Seen = true;
            matrix.Title = "Matrix";
            matrix.Comment = "Genius.";
            matrix.Duration = 130;
            matrix.MinAge = 15;
            matrix.LanguageVO = Language.English;
            matrix.LanguageMedia = Language.English;
            matrix.PhysicalSupport = true;
            Media fightClub = new Media();
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
            liste.Add(matrix);
            liste.Add(fightClub);

            this.ListMovies = liste;
        }
    }
}
