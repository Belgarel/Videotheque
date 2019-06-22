using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Videotheque.Model;

namespace Videotheque
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Videotheque.Model.VideothequeDbContext context = await Videotheque.Model.VideothequeDbContext.getInstance();

            if (!context.Medias.Any() && !context.Genres.Any() && !context.Persons.Any())
                InitData.GetInstance().createData(context);
        }
    }
}
