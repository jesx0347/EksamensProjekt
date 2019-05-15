using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    //public struct CheckBoxData
    //{
    //    public bool Checked { get; set; }
    //    public string Name { get; set; }
    //}
    /// <summary>
    /// Interaction logic for Kategori.xaml
    /// </summary>
    public partial class Kategori : Page
    {
        //private List<CheckBoxData> _theCheckBoxList = new List<CheckBoxData>();
        //public List<CheckBoxData> theCheckBoxList
        //{
        //    get => _theCheckBoxList;
        //    set => _theCheckBoxList = value;
        //}
        public Kategori()
        {
            InitializeComponent();
        }

        private void CheckBox_Kategori_StandUp_Checked(object sender, RoutedEventArgs e)
        {

        }

        //http://www.licensespot.com/blog/wpf-listview-checkbox
        public class CheckBoxListViewItem : INotifyPropertyChanged
        {
            private bool isChecked;
            private string text;
            public bool IsChecked
            {
                get { return isChecked; }
                set
                {
                    if (isChecked == value) return;
                    isChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
            public String Text
            {
                get { return text; }
                set
                {
                    if (text == value) return;
                    text = value;
                    RaisePropertyChanged("Text");
                }
            }
            public CheckBoxListViewItem(string t, bool c)
            {
                this.Text = t;
                this.IsChecked = c;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(string propName)
            {
                PropertyChangedEventHandler eh = PropertyChanged;
                if (eh != null)
                {
                    eh(this, new PropertyChangedEventArgs(propName));
                }
            }
        }

        ////https://social.msdn.microsoft.com/Forums/sqlserver/en-US/ffe90d9d-6487-4d1a-b839-ca810c89ecc4/checkbox-create-automatically-wpf-c?forum=wpf
        //private void ListBox_Loaded(object sender, RoutedEventArgs e)
        //{
        //    foreach (string item in Controller.Singleton.GetKategoriNavne())
        //    {
        //        CheckBoxData data = new CheckBoxData();
        //        data.Name = item;
        //        data.Checked = false;
        //        theCheckBoxList.Add(data);
        //    }
        //}
    }
}
