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
    /// Interaction logic for Sal.xaml
    /// </summary>
    public partial class Sal : Page
    {
        private MainWindow main;
        public Sal()
        {
            InitializeComponent();
            ComboBox_VælgSal.ItemsSource = Controller.Singleton.GetSalNavne();
        }

        public Sal(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
        }

        private void ComboBox_VælgSal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //foreach (string Sale in Controller.Singleton.GetSalNavne())
            //{
            //    ComboBox_VælgSal.Items.Add(Sale);
            //}
            
        }

        private void Button_Sal_Næste_Click(object sender, RoutedEventArgs e)
        {
            Controller.Singleton.VælgSal(NavnOgDato.TempID, ComboBox_VælgSal.SelectedItem.ToString());
            main.MainFrame.Content = main.Kategori;
        }
    }
}
