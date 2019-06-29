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
            set { if (SetProperty(value)) Save.OnCanExecuteChanged(); }
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
            base.InitValues();
            this.TypeMedia = TypeMedia.Series;

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

        protected override bool CanSave()
        {
            if  (this.Title == null || "".Equals(this.Title))
                return false;
            bool ret = true;
            foreach (Episode episode in this.Episodes)
            {
                if (episode.Title == null || "".Equals(episode.Title))
                    ret = false;
            }
            return ret;
        }
        protected override void SaveObject()
        {
            this.Media.Episodes = this.Episodes.ToList();
            base.SaveObject();
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
