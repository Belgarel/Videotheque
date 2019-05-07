using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.ViewModels
{
    public class ShowMedia : BaseNotifyPropertyChanged
    {
        public Media Media
        {
            get { return this.Media; }
            set
            {
                this.TitleText = value?.Title;
                this.CommentText = value?.Comment;
                this.SynopsisText = value?.Synopsis;
                this.DurationText = value?.Duration?.ToString() ?? "Inconnue";
                this.ReleaseText = value?.DateRelease?.ToString() ?? "Inconnue";
            }
        }

        public String TitleText
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public String CommentText
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public String SynopsisText
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public String DurationText
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public String ReleaseText
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }

        public ShowMedia()
        {
            //Creating a series for testing purposes
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

            this.Media = babylon5;
        }
    }
}
