using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque
{
    class TestData
    {
        public TestData() { }

        public async void createData()
        {
            var context = await VideothequeDbContext.getInstance();

            //Creating a movie
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
            //Creating another movie
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
            //Creating a series
            Media babylon5 = new Media();
            babylon5.Type = TypeMedia.Series;
            babylon5.Title = "Babylon 5";
            babylon5.Comment = "Londo 4ever";
            babylon5.Seen = true;
            babylon5.Rated = 5;
            babylon5.LanguageVO = Language.English;
            babylon5.LanguageMedia = Language.English;
            babylon5.LanguageSubtitles = Language.French;
            babylon5.NumericalSupport = true;


        }
    }
}
