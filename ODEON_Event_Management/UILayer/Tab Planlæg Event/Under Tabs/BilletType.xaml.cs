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
        List<string> billetter = new List<string>();
        private MainWindow main;

        public BilletType()
        {
            InitializeComponent();

        }

        public BilletType(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
        }

        //private TextBox CreateTextBox(int row, int column)
        //{
        //    TextBox tb = new TextBox();
        //    tb.Margin = new Thickness(5);
        //    tb.Height = 22;
        //    tb.Width = 150;
        //    Grid.SetColumn(tb, column);
        //    Grid.SetRow(tb, row);
        //    return tb;
        //}

        private void Button_tilføj_Billet_Click(object sender, RoutedEventArgs e)
        {
            //CreateTextBox(3, 5);
            string billet = TextBox_BT_Udbud.Text + ";" + TextBox_BT_Pris.Text;
            if (billetter.Contains(billet))
            {
                billetter.Remove(billet);
            }
            else
            {
                billetter.Add(billet);
            }
            TextBox_BT_Udbud.Clear();
            TextBox_BT_Pris.Clear();

            StringBuilder sb = new StringBuilder();
            foreach (string item in billetter)
            {
                sb.AppendLine(item.ToString());
            }
            TextBox_Billet_Windu.Text = sb.ToString();

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

        private void Button_BilletType_Udfør_Click(object sender, RoutedEventArgs e)
        {
            List<Tuple<int, decimal>> billet = new List<Tuple<int, decimal>>();

            //make stuff
            foreach (string b in billetter)
            {
                string[] t = b.Split(';');
                if (int.TryParse(t[0], out int udbud) && decimal.TryParse(t[1], out decimal pris))
                {
                    Tuple<int, decimal> tuple = new Tuple<int, decimal>(udbud, pris);
                    billet.Add(tuple);
                }
                else
                {
                    MessageBox.Show("noget er galt");
                    return;
                }
            }

            Controller.Singleton.IndskrivBilletTyper(NavnOgDato.TempID, billet);

            Controller.Singleton.UploadEvent(NavnOgDato.TempID);

            MessageBox.Show("Event gemt");

            main.Tab_Button_Planlæg_Event.IsEnabled = true;
        }
    }
}
