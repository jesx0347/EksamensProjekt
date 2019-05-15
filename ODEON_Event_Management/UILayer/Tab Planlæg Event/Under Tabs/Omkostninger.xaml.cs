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
        private MainWindow main;
        public Omkostninger()
        {
            InitializeComponent();
        }

        public Omkostninger(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
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
                            main.MainFrame.Content = main.Økonomi;
                        }
                    }
                }
            }
        }

        private void TextBox_Markedsføring_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_Markedsføring_GotFocus;
        }

        private void TextBox_Markedsføring_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast beløb...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_Markedsføring_GotFocus;
            }
        }

        private void TextBox_KODA_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_KODA_GotFocus;
        }

        private void TextBox_KODA_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast mængde...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_Markedsføring_GotFocus;
            }
        }

        private void TextBox_Garantisum_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_Garantisum_GotFocus;
        }

        private void TextBox_Garantisum_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast mængde...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_Garantisum_GotFocus;
            }
        }

        private void TextBox_ArtistSplit_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_ArtistSplit_GotFocus;
        }

        private void TextBox_ArtistSplit_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast mængde...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_ArtistSplit_GotFocus;
            }
        }
    }
}
