using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationLayer;

namespace UILayer.Tab_Planlæg_Event.Under_Tabs
{
    /// <summary>
    /// Interaction logic for Omkostninger.xaml
    /// </summary>
    public partial class Omkostninger : Page
    {
        public Omkostninger()
        {
            InitializeComponent();
        }

        private void Button_Omkostninger_Næste_Click(object sender, RoutedEventArgs e)
        {
            //decimal m;
            if(decimal.TryParse(TextBox_Markedsføring.Text, out decimal m))
            {
                if(double.TryParse(TextBox_KODA.Text, out double k))
                {
                    if (decimal.TryParse(TextBox_Garantisum.Text, out decimal g))
                    {
                        if (double.TryParse(TextBox_ArtistSplit.Text, out double a))
                        {
                            Controller.Singleton.IndskrivOmkostninger(NavnOgDato.TempID, m, k, g, a);
                        }
                    }
                }
            }
        }
    }
}
