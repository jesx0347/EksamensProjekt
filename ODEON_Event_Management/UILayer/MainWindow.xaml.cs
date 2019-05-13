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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static Controller control = new Controller();
        private Vis_Events vis_Events = new Vis_Events();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonVisEvents_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = vis_Events;
        }

        private void ButtonPlanlægEvent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonVisEnkeltEvent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tab_Button_Omkostninger_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tab_Button_BilletType_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
