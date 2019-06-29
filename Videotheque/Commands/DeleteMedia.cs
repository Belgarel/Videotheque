using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.ViewModels;
using Videotheque.Views;

namespace Videotheque.Commands
{
    class DeleteMedia : ICommand
    {
        public MainWindowModel MainWindow { get; set; }
        public SwitchPageParameter GoToNextPage { get;set;}
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter.GetType() != typeof(Media))
                return;
            await MediaService.GetInstance().Delete((Media)parameter, this.Loading);

            //Refresh the list of medias
            if (this.GoToNextPage.DestinationModel is ListMoviesModel)
                ((MainWindowModel)this.GoToNextPage.MainWindow).Movies();
            else if (this.GoToNextPage.DestinationModel is ListSeriesModel)
                ((MainWindowModel)this.GoToNextPage.MainWindow).Series();
        }
        public void Loading()
        {
            ((MainWindowModel)this.GoToNextPage.MainWindow).Loading();
        }
        public DeleteMedia(MainWindowModel mainWindowModel, Page destinationPage, BaseNotifyPropertyChanged destinationModel)
        {
            this.MainWindow = mainWindowModel;
            this.GoToNextPage = new SwitchPageParameter(mainWindowModel, destinationPage, destinationModel);
        }
    }
}
