using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videotheque.Commands;
using Videotheque.Model;
using Videotheque.Service;

namespace Videotheque.ViewModels
{
    class EditSeriesViewModel : EditMovieViewModel
    {
        public ObservableCollection<Episode> Episodes
        {
            get { return (ObservableCollection<Episode>)GetProperty(); }
            set { SetProperty(value); }
        }
        public Episode SelectedEpisode
        {
            get { return (Episode)GetProperty(); }
            set { if (SetProperty(value)) RemoveEpisode.OnCanExecuteChanged(); }
        }
        public BaseCommand RemoveEpisode { get; }
        public BaseCommand AddEpisode { get; }


        protected override void InitValues()
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
                    if (gm.Genre != null)
                        this.Genres += gm.Genre.Libelle + ", ";
                if (this.Genres.Length >= 2)
                    this.Genres = this.Genres.Substring(0, this.Genres.Length - 2);
            }

            this.RefreshEpisodes();
        }
        private void RefreshEpisodes()
        {
            ObservableCollection<Episode> episodes = new ObservableCollection<Episode>();
            if (this.Media.Episodes != null)
                foreach (Episode episode in this.Media.Episodes)
                    episodes.Add(episode);
            this.Episodes = episodes;
        }

        protected override void SaveObject()
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

            Console.WriteLine("// TODO : manage episodes saving");

            MediaService.GetInstance().Save(this.Media);

            ((ListMoviesModel)this.GoToNextPage.DestinationModel).Refresh(); // refresh the list to include the new media (if a new media was created)
            new SwitchPage().Execute(this.GoToNextPage);
        }

        private bool CanRemoveEpisode()
        {
            return this.SelectedEpisode != null;
        }
        private void RemoveEpisodeExecute()
        {
            if (this.Media.Episodes == null)
                return;
            this.Media.Episodes.Remove(this.SelectedEpisode);
            this.RefreshEpisodes();
        }
        private bool CanAddEpisode()
        {
            return true;
        }
        private void AddEpisodeExecute()
        {
            if (this.Media.Episodes == null)
                this.Media.Episodes = new List<Episode>();
            this.Media.Episodes.Add(new Episode());
            this.RefreshEpisodes();
        }

        public EditSeriesViewModel(Media media, SwitchPageParameter goToNextPage) :
            base(media, goToNextPage)
        {
            this.Media = media;
            this.InitValues();
            this.GoToNextPage = goToNextPage;
            this.RemoveEpisode = new BaseCommand(this.RemoveEpisodeExecute, this.CanRemoveEpisode);
            this.AddEpisode = new BaseCommand(this.AddEpisodeExecute, this.CanAddEpisode);
        }
    }
}
