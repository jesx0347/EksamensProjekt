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
    }
}
