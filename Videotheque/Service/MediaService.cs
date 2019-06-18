using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.Service
{
    class MediaService
    {
        private static MediaService _instance;
        private VideothequeDbContext context;

        private MediaService()
        {
            initialize();
        }
        private async void initialize()
        {
            context = await VideothequeDbContext.getInstance();
        }


        public static MediaService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MediaService();
            }
            return _instance;
        }


        public List<Media> GetMedias()
        {
            return context.Medias.ToList();
        }
        public Media findByMediaId(int mediaId)
        {
            return context.Medias.Find(mediaId);
        }

        public List<Media> GetMovies()
        {
            return context.Medias
                .Where(m => m.Type.Equals(TypeMedia.Movie))
                .OrderBy(m => m.Title)
                .ToList();
        }
        public List<Media> GetSeries()
        {
            return context.Medias
                .Where((m) => m.Type.Equals(TypeMedia.Series))
                .OrderBy(m => m.Title)
                .ToList();
        }
        public void Save(Media m)
        {
            if (m.MediaId == 0)
            {
                if (this.findByMediaId(m.MediaId) != null)
                    return;
                context.Medias.Add(m);
            }
            else
            {
                if (this.findByMediaId(m.MediaId) == null)
                    return;
                context.Medias.Update(m);
            }
            context.SaveChanges();
        }
    }
}
