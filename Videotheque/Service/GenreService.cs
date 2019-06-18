using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.Service
{
    class GenreService
    {
        private static GenreService _instance;
        private VideothequeDbContext context;

        private GenreService()
        {
            initialize();
        }
        private async void initialize()
        {
            context = await VideothequeDbContext.getInstance();
        }


        public static GenreService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GenreService();
            }
            return _instance;
        }

        public Genre findByGenreId(int genreId)
        {
            return context.Genres.Find(genreId);
        }
        public Genre findByLibelle(string libelle)
        {
            List<Genre> genres =  context.Genres
                .Where((g) => g.Libelle.Equals(libelle)).ToList();
            if (genres == null || genres.Count == 0)
                return null;
            return genres.First();
        }

        public List<Genre> ToGenres(String genres)
        {
            List<Genre> ret = new List<Genre>();
            string[] genresSplit = genres.Split(',');
            foreach (string g in genresSplit)
            {
                string libelle = g;
                // Normalizing: cleanupspaces, minuscule
                while (libelle.StartsWith(" "))
                    libelle = libelle.Substring(1, libelle.Length - 1);
                while (libelle.EndsWith(" "))
                    libelle = libelle.Substring(0, libelle.Length - 1);
                if (libelle.Length == 0)
                    continue;
                libelle = libelle.Substring(0, 1).ToUpper() + libelle.Substring(1, libelle.Length - 1).ToLower();

                // Find in DB or 
                Genre genre = findByLibelle(libelle);
                if (genre == null)
                {
                    genre = new Genre();
                    genre.Libelle = libelle;
                }
                ret.Add(genre);
            }
            return ret;
        }
    }
}
