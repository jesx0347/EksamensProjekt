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
        private MainWindow main;

        public Økonomi()
        {
            InitializeComponent();
        }

        public Økonomi(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
        }

        private void Button_Økonomi_Næste_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(TextBox_VO.Text, out decimal vo))
            {
                if (decimal.TryParse(TextBox_VI.Text, out decimal vi))
                {
                    Controller.Singleton.IndskrivVariable(NavnOgDato.TempID, vo, vi, TextBox_VO_Note.Text, TextBox_VI_Note.Text);

                    main.MainFrame.Content = main.BilletType;
                    main.Tab_Button_BilletType.IsEnabled = true;
                }
            }
        }

        private void Button_Økonomi_Tilbage_Click(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = main.Omkostninger;
        }

        private void TextBox_VO_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_VO_GotFocus;
        }

        private void TextBox_VO_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast Beløb...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_VO_GotFocus;
            }
        }

        private void TextBox_VO_Note_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_VO_Note_GotFocus;
        }

        private void TextBox_VO_Note_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indskriv Noter...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_VO_Note_GotFocus;
            }
        }

        private void TextBox_VI_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_VI_GotFocus;
        }

        private void TextBox_VI_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast Beløb...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_VI_GotFocus;
            }
        }

        private void TextBox_VI_Note_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_VI_Note_GotFocus;
        }

        private void TextBox_VI_Note_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indskriv Noter...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_VI_Note_GotFocus;
            }
        }

    }
}
