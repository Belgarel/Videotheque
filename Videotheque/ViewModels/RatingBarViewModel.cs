using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Windows;

namespace Videotheque.ViewModels
{
    class RatingBarViewModel : BaseNotifyPropertyChanged
    {
        [Description("Grade"), Category("Value"), DefaultValue(0), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int Grade
        {
            get { return Grade; }
            set
            {
                int val = value;
                if (val <= 0)
                    val = 0;
                else if (5 <= val)
                    val = 5;
                Grade = val;

                Rate[0] = Rate[1] = Rate[2] = Rate[3] = Rate[4] = "pack://application:,,,/" + assembly + ";component/Controls/star_ko.png";
                for (int i = 0; i != val; i++)
                    Rate[i] = "pack://application:,,,/" + assembly + ";component/Controls/star_ok.png";
            }
        }

        public string[] Rate { get; set; }
        private String assembly = Assembly.GetExecutingAssembly().GetName().Name;

        public RatingBarViewModel()
        {
            Rate = new string[5];
            Rate[0] = Rate[1] = Rate[2] = Rate[3] = Rate[4] = "pack://application:,,,/" + assembly + ";component/Controls/star_ko.png";
        }
    }
}
