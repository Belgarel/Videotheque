﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videotheque.Commands;
using Videotheque.Model;

namespace Videotheque.ViewModels
{
    class EditMovieViewModel : BaseNotifyPropertyChanged
    {
        public Media Media
        {
            get { return (Media)GetProperty(); }
            set { SetProperty(value); }
        }
        public Boolean? Seen
        {
            get { return (Boolean?)GetProperty(); }
            set { SetProperty(value); }
        }
        public int? Rated
        {
            get { return (int?)GetProperty(); }
            set { SetProperty(value); }
        }

        public string Title
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string Comment
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string Synopsis
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string ImagePath
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string DateRelease
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public int? Duration
        {
            get { return (int?)GetProperty(); }
            set { SetProperty(value); }
        }
        public int? MinAge
        {
            get { return (int?)GetProperty(); }
            set { SetProperty(value); }
        }
        public string LanguageVO
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string LanguageMedia
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public string LanguageSubtitles
        {
            get { return (string)GetProperty(); }
            set { SetProperty(value); }
        }
        public Boolean? PhysicalSupport
        {
            get { return (Boolean?)GetProperty(); }
            set { SetProperty(value); }
        }
        public Boolean? NumericalSupport
        {
            get { return (Boolean?)GetProperty(); }
            set { SetProperty(value); }
        }

        public SwitchPageParameter GoToNextPage { get; set; }
        public BaseCommand Save
        {
            get
            {
                return new BaseCommand(this.SaveObject, this.CanSave);
            }
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

        }
        private bool CanSave()
        {
            return (!"".Equals(this.Title));
        }
        private void SaveObject()
        {
            this.Media.Title = this.Title;
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

            //TODO: genres

            //TODO: actual saving. Not just mocking all of that mess.
            Console.WriteLine("// TODO : save media");

            ((ListMoviesModel)this.GoToNextPage.DestinationModel).Refresh(); // refresh the list to include the new media (if a new media was created)
            new SwitchPage().Execute(this.GoToNextPage);
        }

        public EditMovieViewModel(Media media, SwitchPageParameter goToNextPage)
        {
            this.Media = media;
            this.InitValues();
            this.GoToNextPage = goToNextPage;
        }
    }
}
