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
    /// Interaction logic for BilletType.xaml
    /// </summary>
    public partial class BilletType : Page
    {
        List<Tuple<int, decimal>> billet = new List<Tuple<int, decimal>>();
        

        public BilletType()
        {
            InitializeComponent();

        }

        private TextBox CreateTextBox(int row, int column)
        {
            TextBox tb = new TextBox();
            tb.Margin = new Thickness(5);
            tb.Height = 22;
            tb.Width = 150;
            Grid.SetColumn(tb, column);
            Grid.SetRow(tb, row);
            return tb;
        }

        private void Button_tilføj_Billet_Click(object sender, RoutedEventArgs e)
        {
            CreateTextBox(3, 5);
        }

        private void TextBox_BT_Udbud_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_BT_Udbud_GotFocus;
        }

        private void TextBox_BT_Udbud_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast Mængde...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_BT_Udbud_GotFocus;
            }
        }

        private void TextBox_BT_Pris_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_BT_Pris_GotFocus;
        }

        private void TextBox_BT_Pris_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast Mængde...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_BT_Pris_GotFocus;
            }
        }
    }
}
