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
using LiveCharts;
using LiveCharts.Wpf;

namespace UILayer.Break_Even
{
    public partial class BreakEvenChart : Page
    {
        MainWindow main;
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public BreakEvenChart()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Udgifter",
                    Values = new ChartValues<decimal> { /*10000, 25200, 39, 50 */}
                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Indtægter",
                Values = new ChartValues<decimal> {}
            });

            //also adding values updates and animates the chart automatically

            //Labels = new[] { "Maria", "Susan", "Charles", "Frida" };
            List<string> eventNavn = new List<string>();
            Labels = eventNavn;
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public BreakEvenChart(MainWindow window) : this()
        {
            main = window;
        }
    }
}
