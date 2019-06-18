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


        public IEnumerable<Media> GetMedias()
        {
            return context.Medias.ToList();
        }

        public IEnumerable<Media> GetMovies()
        {
            return context.Medias.Where((m) => m.Type.Equals(TypeMedia.Movie));
        }
    }
}
