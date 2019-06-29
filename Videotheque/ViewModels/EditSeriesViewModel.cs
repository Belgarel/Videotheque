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
            this.TypeMedia = TypeMedia.Series;
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

            ObservableCollection<Episode> episodes = new ObservableCollection<Episode>();
            if (this.Media.Episodes != null)
                foreach (Episode episode in this.Media.Episodes)
                    episodes.Add(episode);
            this.Episodes = episodes;
        }

        private bool CanRemoveEpisode()
        {
            return this.SelectedEpisode != null;
        }
        private void RemoveEpisodeExecute()
        {
            if (this.Episodes == null)
                return;
            this.Episodes.Remove(this.SelectedEpisode);
        }
        private bool CanAddEpisode()
        {
            return true;
        }
        private void AddEpisodeExecute()
        {
            if (this.Episodes == null)
                this.Episodes = new ObservableCollection<Episode>();
            this.Episodes.Add(new Episode());
        }

        protected override void SaveObject()
        {
            base.SaveObject();
            this.Media.Episodes = this.Episodes.ToList();
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
