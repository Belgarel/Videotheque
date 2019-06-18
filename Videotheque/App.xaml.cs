using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Videotheque.Model;

namespace Videotheque
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Videotheque.Model.VideothequeDbContext context = await Videotheque.Model.VideothequeDbContext.getInstance();

            if (!context.Medias.Any() && !context.Genres.Any() && !context.Persons.Any())
            {
                var genres = new Genre[]
                {
                InitData.GenreAction(),
                InitData.GenreAdventure(),
                InitData.GenreAliens(),
                InitData.GenreCartoon(),
                InitData.GenreRobots(),
                InitData.GenreSf(),
                InitData.GenreSpaceOpera()
                };
                List<Genre> genresFightClub = new List<Genre>();
                genresFightClub.Add(genres[0]);
                List<Genre> genresMatrix = new List<Genre>();
                genresMatrix.Add(genres[0]);
                genresMatrix.Add(genres[4]);
                genresMatrix.Add(genres[5]);
                List<Genre> genresBabylon5 = new List<Genre>();
                genresBabylon5.Add(genres[2]);
                genresBabylon5.Add(genres[5]);
                genresBabylon5.Add(genres[6]);
                var medias = new Media[]
                {
                InitData.MovieFightClub(genresFightClub),
                InitData.MovieMatrix(genresMatrix),
                InitData.SeriesBabylon5(genresBabylon5)
                };
                foreach (Genre genre in genres)
                    context.Genres.Add(genre);
                foreach (Media media in medias)
                    context.Medias.Add(media);
                context.SaveChanges();
            }
        }
    }
}
