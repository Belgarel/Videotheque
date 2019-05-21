using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.ViewModels
{
    public class DetailMediaModel : BaseNotifyPropertyChanged
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

        public DetailMediaModel()
        {
            this.Media = new Media();
        }
        public DetailMediaModel(Media media)
        {
            this.Media = media;
        }
    }
}
