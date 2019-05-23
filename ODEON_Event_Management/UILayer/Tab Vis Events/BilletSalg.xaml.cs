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

namespace UILayer.Tab_Vis_Events
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class BilletSalg : Page
    {
        private string eventID;
        List<WPFBillet> billeter;
        private MainWindow main;
        public BilletSalg(string eventID)
        {
            InitializeComponent();
            this.eventID = eventID;
            LoadBilleter();
        }

        public BilletSalg(string eventID, MainWindow mainWindow) : this(eventID)
        {
            main = mainWindow;
        }

        public void LoadBilleter()
        {
            billeter = new List<WPFBillet>();
            foreach (Tuple<DateTime, decimal> billet in Controller.Singleton.GetBilleter(eventID))
            {
                WPFBillet WPF = new WPFBillet() { Afvikling = billet.Item1, Pris = billet.Item2 };
                billeter.Add(WPF);
            }
            BilletListe.ItemsSource = billeter;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = string.Empty;
            box.GotFocus -= TextBox_GotFocus;

        }

        private void Button_Annuller_Click(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = main.vis_Events;
        }
    }

    public class WPFBillet
    {
        public DateTime Afvikling { get; set; }
        public decimal Pris { get; set; }

        public override string ToString()
        {
            return Pris.ToString() + " " + Afvikling.ToString();
        }
    }

}
