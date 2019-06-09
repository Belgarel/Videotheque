using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videotheque.Commands;
using Videotheque.Model;

namespace Videotheque.ViewModels
{
    class EditSeriesViewModel : EditMovieViewModel
    {
        public List<Episode> Episodes
        {
            get { return (List<Episode>)GetProperty(); }
            set { SetProperty(value); }
        }
        private void InitValues()
        {
            this.Comment = this.Media.Comment;
            //            this.DateRelease = this.Media.DateRelease;
            this.Duration = this.Media.Duration ?? 0;
            //            this.ImagePath = this.Media.ImagePath;
            this.LanguageMedia = this.Media.LanguageMedia.ToString();
            this.LanguageSubtitles = this.Media.LanguageSubtitles.ToString();
            this.LanguageVO = this.Media.LanguageVO.ToString();
            this.MinAge = this.Media.MinAge ?? 0;
            this.NumericalSupport = this.Media.NumericalSupport ?? false;
            this.PhysicalSupport = this.Media.PhysicalSupport ?? false;
            this.Rated = this.Media.Rated;
            this.Seen = this.Media.Seen ?? false;
            this.Synopsis = this.Media.Synopsis;
            this.Title = this.Media.Title;

            this.Genres = "";
            if (this.Media.GenreMedias != null)
            {
                foreach (GenreMedia gm in this.Media.GenreMedias)
                    this.Genres += gm.Genre.Libelle + ", ";
                if (this.Genres.Length >= 2)
                    this.Genres = this.Genres.Substring(0, this.Genres.Length - 2);
            }

            this.Episodes = new List<Episode>();
            foreach (Episode episode in this.Media.Episodes)
                this.Episodes.Add(episode);
        }
        private void SaveObject()
        {
            this.Media.Title = this.Title;
            this.Media.Type = TypeMedia.Series;
            this.Media.Synopsis = this.Synopsis;
            this.Media.Seen = this.Seen;
            this.Media.Comment = this.Comment;
            this.Media.Rated = this.Rated ?? 0;
            this.Media.MinAge = this.MinAge;
            //this.Media.DateRelease = this.DateRelease;
            this.Media.Duration = this.Duration;
            //this.Media.ImagePath = this.ImagePath;
            this.Media.NumericalSupport = this.NumericalSupport;
            this.Media.PhysicalSupport = this.PhysicalSupport;

            Language Parsed;
            Language.TryParse(this.LanguageMedia, out Parsed);
            this.Media.LanguageMedia = Parsed;
            Language.TryParse(this.LanguageSubtitles, out Parsed);
            this.Media.LanguageSubtitles = Parsed;
            Language.TryParse(this.LanguageVO, out Parsed);
            this.Media.LanguageVO = Parsed;

            // genres
            Console.WriteLine("// TODO : manage genres saving");
            string[] genres = this.Genres.Split(',');
            foreach (string genre in genres)
            {
                string libelle = genre;
                if (libelle.EndsWith(" "))
                    libelle = genre.Substring(0, this.Genres.Length - 1);
                // TODO : if genre found, add. Else create
            }

            //episodes
            Console.WriteLine("// TODO : manage episodes saving");

            //TODO: actual saving. Not just mocking all of that mess.
            Console.WriteLine("// TODO : save media");

            ((ListMoviesModel)this.GoToNextPage.DestinationModel).Refresh(); // refresh the list to include the new media (if a new media was created)
            new SwitchPage().Execute(this.GoToNextPage);
        }

        public EditSeriesViewModel(Media media, SwitchPageParameter goToNextPage) :
            base(media, goToNextPage)
        {
            this.Media = media;
            this.InitValues();
            this.GoToNextPage = goToNextPage;
        }
    }
}
