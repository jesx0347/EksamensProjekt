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

namespace UILayer.Tab_Planlæg_Event.Under_Tabs
{
    /// <summary>
    /// Interaction logic for NavnOgDato.xaml
    /// </summary>
    public partial class NavnOgDato : Page
    {
        string eventNavn;
        List<DateTime> dates = new List<DateTime>();
        public NavnOgDato()
        {
            InitializeComponent();
        }

        private void TextBox_EventNavn_TextChanged(object sender, TextChangedEventArgs e)
        {
            eventNavn = TextBox_EventNavn.Text;
            //MainWindow.control.IndskrivNavnOgDato(TextBox_EventNavn)
        }

        private void Button_Tilføj_Flere_Datoer_Click(object sender, RoutedEventArgs e)
        {
            //dates.Add();
        }

        private void Kalender_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox_Datoer.Text = Kalender.SelectedDate.ToString();
        }
    }
}
