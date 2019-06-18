using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.Service
{
    class GenreMediaService
    {
        private static GenreMediaService _instance;
        private VideothequeDbContext context;

        private GenreMediaService()
        {
            initialize();
        }
        private async void initialize()
        {
            context = await VideothequeDbContext.getInstance();
        }


        public static GenreMediaService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GenreMediaService();
            }
            return _instance;
        }

        public GenreMedia FindByGenreIdAndMediaId(int genreId, int mediaId)
        {
            List< GenreMedia> gms = context.GenreMedias
                .Where(gm => gm.GenreId.Equals(genreId) && gm.MediaId.Equals(mediaId)).ToList();
            if (gms == null || gms.Count == 0)
                return null;
            return gms.First();
        }
        public List<GenreMedia> ToGenreMedias(Media media, List<Genre> genres)
        {
            List<GenreMedia> genreMedias = new List<GenreMedia>();
            foreach (Genre genre in genres)
            {
                GenreMedia gm = (genre.GenreId != 0) ? FindByGenreIdAndMediaId(genre.GenreId, media.MediaId) : null;
                if (gm == null)
                {
                    gm = new GenreMedia();
                    gm.Genre = genre;
                    gm.Media = media;
                }
                genreMedias.Add(gm);
            }
            return genreMedias;
        }
    }
}
