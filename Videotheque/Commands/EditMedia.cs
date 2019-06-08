using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Videotheque.Model;
using Videotheque.ViewModels;
using Videotheque.Views;

namespace Videotheque.Commands
{
    class EditMedia : ICommand
    {
        public MainWindowModel MainWindow { get; set; }
        public SwitchPageParameter GoToNextPage { get;set;}
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(Media))
                return;
            this.MainWindow.CurrentPage = new EditMoviePage();
            this.MainWindow.CurrentPage.DataContext = new EditMovieViewModel((Media) parameter, this.GoToNextPage);
        }
        public EditMedia(MainWindowModel mainWindowModel, Page destinationPage, BaseNotifyPropertyChanged destinationModel)
        {
            this.MainWindow = mainWindowModel;
            this.GoToNextPage = new SwitchPageParameter(mainWindowModel, destinationPage, destinationModel);
        }
    }
}
