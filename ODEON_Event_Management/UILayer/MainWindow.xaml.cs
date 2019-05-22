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
        //internal static Controller control = new Controller();
        public Vis_Events vis_Events;
        public Break_Even.BreakEvenChart BreakEvenChart;
        public Tab_Planlæg_Event.Under_Tabs.NavnOgDato NavnOgDato;
        public Tab_Planlæg_Event.Under_Tabs.Sal Sal /*= new Tab_Planlæg_Event.Under_Tabs.Sal()*/;
        public Tab_Planlæg_Event.Under_Tabs.Kategori Kategori;
        public Tab_Planlæg_Event.Under_Tabs.Omkostninger Omkostninger;
        public Tab_Planlæg_Event.Under_Tabs.Økonomi Økonomi;
        public Tab_Planlæg_Event.Under_Tabs.BilletType BilletType;
        public MainWindow()
        {
            InitializeComponent();
            NavnOgDato = new Tab_Planlæg_Event.Under_Tabs.NavnOgDato(this);
            Sal = new Tab_Planlæg_Event.Under_Tabs.Sal(this);
            Kategori = new Tab_Planlæg_Event.Under_Tabs.Kategori(this);
            Omkostninger = new Tab_Planlæg_Event.Under_Tabs.Omkostninger(this);
            Økonomi = new Tab_Planlæg_Event.Under_Tabs.Økonomi(this);
            BilletType = new Tab_Planlæg_Event.Under_Tabs.BilletType(this);
            //vis_Events = new Vis_Events(this);
            BreakEvenChart = new Break_Even.BreakEvenChart(this);
        }

        private void ButtonVisEvents_Click(object sender, RoutedEventArgs e)
        {
            vis_Events = new Vis_Events(this);
            spl_PlanlægEvents.Visibility = Visibility.Hidden;
            MainFrame.Content = vis_Events;
        }

        private void ButtonPlanlægEvent_Click(object sender, RoutedEventArgs e)
        {
            spl_PlanlægEvents.Visibility = Visibility.Visible;
            Tab_Button_Planlæg_Event.IsEnabled = false;
            Tab_Button_Sal.IsEnabled = false;
            Tab_Button_Kategori.IsEnabled = false;
            Tab_Button_Omkostninger.IsEnabled = false;
            Tab_Button_Økonomi.IsEnabled = false;
            Tab_Button_BilletType.IsEnabled = false;

        }

        private void ButtonVisEnkeltEvent_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
        }

        private void Tab_Button_Omkostninger_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = Omkostninger;
        }

        private void Tab_Button_BilletType_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = BilletType;
        }

        private void Tab_Button_Navn_Og_Dato_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = NavnOgDato;
        }

        private void Tab_Button_Sal_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = Sal;
        }

        private void Tab_Button_Kategori_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = Kategori;
        }

        private void Tab_Button_Økonomi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = Økonomi;
        }
    }
}
