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
            //new Thread(() => 
            {
                DateTime date = (DateTime)Kalender.SelectedDate;
                if (dates.Contains(date))
                {
                    dates.Remove(date);
                }
                else
                {
                    dates.Add(date);
                    dates.Sort();
                }
                TextBox_Datoer.Clear();
                StringBuilder sb = new StringBuilder();
                foreach (DateTime item in dates)
                {
                    sb.AppendLine(item.ToString());
                }
                TextBox_Datoer.Text = sb.ToString();
                //ListView_Datoer.
            }//).Start();
        }

        private void Button_NavnOgDato_Næste_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void ListView_Datoer_SourceUpdated(object sender, DataTransferEventArgs e)
        //{
        //    new Thread(() =>
        //    {
        //        foreach (DateTime item in dates)
        //        {
        //            ListView_Datoer.Items.Add(item);
        //        }
        //    }).Start();
        //}
    }
}
