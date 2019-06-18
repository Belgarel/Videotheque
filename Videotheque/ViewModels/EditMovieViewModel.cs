﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Videotheque.Commands;
using Videotheque.Model;
using Videotheque.Service;

namespace Videotheque.ViewModels
{
    class EditMovieViewModel : BaseNotifyPropertyChanged
    {
        public TypeMedia TypeMedia { get; set; }
        public Media Media
        {
            get { return (Media)GetProperty(); }
            set
            {
                SetProperty(value);
                InitValues();
            }
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
        public string Genres
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

        protected virtual void InitValues()
        {
            this.Comment = this.Media.Comment;
            this.TypeMedia = TypeMedia.Movie;
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
        }
        private bool CanSave()
        {
            return (!"".Equals(this.Title));
        }
        protected virtual void SaveObject()
        {
            this.Media.Title = this.Title;
            this.Media.Type = this.TypeMedia;
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

            // If genres already exist, they are found; else, they are created.
            // Same goes for GenreMedia.
            //TODO: avoid code duplication (override)
            //TODO: cleanup unused genres
            this.Media.GenreMedias = GenreMediaService.GetInstance()
                .ToGenreMedias(this.Media, GenreService.GetInstance().ToGenres(this.Genres));

            MediaService.GetInstance().Save(this.Media);

            ((ListMoviesModel)this.GoToNextPage.DestinationModel).Refresh(); // refresh the list to include the new media (if a new media was created)
            new SwitchPage().Execute(this.GoToNextPage);
        }

        public EditMovieViewModel(Media media, SwitchPageParameter goToNextPage)
        {
            this.Media = media;
            this.GoToNextPage = goToNextPage;
        }
    }
}
