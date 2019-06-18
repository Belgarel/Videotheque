using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Commands;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.Views;

namespace Videotheque.ViewModels
{
    class ListSeriesModel : ListMoviesModel
    {
        public override void Refresh()
        {
            this.NewMedia = new Media();
            this.NewMedia.Type = TypeMedia.Series;
            this.ListMedias = MediaService.GetInstance().GetSeries();
        }

        public ListSeriesModel(MainWindowModel MainWindow) :
            base(MainWindow)
        {
            this.EditMedia = new EditMedia(MainWindow, new ListSeriesPage(), this);
        }
    }
}
