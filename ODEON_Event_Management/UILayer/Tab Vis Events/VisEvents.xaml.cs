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

namespace UILayer
{
    /// <summary>
    /// Interaction logic for Vis_Events.xaml
    /// </summary>
    public partial class Vis_Events : Page
    {
        List<WPFEventView> WPFEventViews;
        public Vis_Events()
        {
            InitializeComponent();
            WPFEventViews = new List<WPFEventView>();
            foreach (Tuple<int, string> tuple in Controller.Singleton.GetEventListing())
            {
                WPFEventView add = new WPFEventView(tuple.Item2, tuple.Item1);
                WPFEventViews.Add(add);
            }
            EventList.ItemsSource = WPFEventViews;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tab_VE_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= Tab_VE_TextBox_GotFocus;
        }

        private void Tab_VE_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Search...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += Tab_VE_TextBox_GotFocus;
            }
        }
    }

    public class WPFEventView
    {
        public string name { get; }
        public int ID { get; }
        public WPFEventView(string n, int id)
        {
            name = n;
            ID = id;
        }
        public override string ToString()
        {
            return name.ToString();
        }
    }
}
