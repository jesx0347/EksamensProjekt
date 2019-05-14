using System;
using System.Threading;
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
    /// Interaction logic for Økonomi.xaml
    /// </summary>
    public partial class Økonomi : Page
    {
        public Økonomi()
        {
            InitializeComponent();
        }

        private void Button_Økonomi_Næste_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(TextBox_VO.Text, out decimal vo))
            {
                if (decimal.TryParse(TextBox_VariableIndtægter.Text, out decimal vi))
                {
                    Controller.Singleton.IndskrivVariable(NavnOgDato.TempID, vo, vi, TextBox_VO_Note.Text, TextBox_VI_Note.Text);
                }
            }
        }
    }
}
