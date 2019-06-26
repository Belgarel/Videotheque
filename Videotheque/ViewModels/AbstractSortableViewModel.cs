using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Commands;

namespace Videotheque.ViewModels
{
    abstract class AbstractSortableViewModel : BaseNotifyPropertyChanged
    {
        public BaseCommand SortByTitleAsc { get; set; }
        public BaseCommand SortByTitleDesc { get; set; }
        public BaseCommand SortByDateAsc { get; set; }
        public BaseCommand SortByDateDesc { get; set; }
        public BaseCommand SortByRatingAsc { get; set; }
        public BaseCommand SortByRatingDesc { get; set; }

//        public abstract void SortByNameAscCanExecute();
        public abstract void SortByTitleAscExecute();
//        public abstract void SortByNameDescCanExecute();
        public abstract void SortByTitleDescExecute();

//        public abstract void SortByDateAscCanExecute();
        public abstract void SortByDateAscExecute();
//        public abstract void SortByDateDescCanExecute();
        public abstract void SortByDateDescExecute();

//        public abstract void SortByRatingAscCanExecute();
        public abstract void SortByRatingAscExecute();
//        public abstract void SortByRatingDescCanExecute();
        public abstract void SortByRatingDescExecute();

        public AbstractSortableViewModel()
        {
            this.SortByTitleAsc = new BaseCommand(this.SortByTitleAscExecute);
            this.SortByTitleDesc = new BaseCommand(this.SortByTitleDescExecute);
            this.SortByDateAsc = new BaseCommand(this.SortByDateAscExecute);
            this.SortByDateDesc = new BaseCommand(this.SortByDateDescExecute);
            this.SortByRatingAsc = new BaseCommand(this.SortByRatingAscExecute);
            this.SortByRatingDesc = new BaseCommand(this.SortByRatingDescExecute);
        }
    }
}
