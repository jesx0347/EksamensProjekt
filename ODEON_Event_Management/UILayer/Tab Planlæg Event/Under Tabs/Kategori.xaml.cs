using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private MainWindow main;
        public ObservableCollection<BoolStringClass> TheList { get; set; }
        //private List<CheckBoxData> _theCheckBoxList = new List<CheckBoxData>();
        //public List<CheckBoxData> theCheckBoxList
        //{
        //    get => _theCheckBoxList;
        //    set => _theCheckBoxList = value;
        //}
        public Kategori()
        {
            InitializeComponent();
            CreateCheckBoxList();
           
        }
        public class BoolStringClass
        {
            public string TheText { get; set; }
        }

        //from https://www.c-sharpcorner.com/uploadfile/syedshakeer/checkboxlist-in-wpf/
        public void CreateCheckBoxList()
        {
            TheList = new ObservableCollection<BoolStringClass>();
            foreach (string kat in Controller.Singleton.GetKategoriNavne())
            {
                TheList.Add(new BoolStringClass { TheText = kat});
            }
            this.DataContext = this;
        }

        public Kategori(MainWindow mainWindow) : this()
        {
            //InitializeComponent();
            main = mainWindow;
        }

        //private void CheckBox_Kategori_StandUp_Checked(object sender, RoutedEventArgs e)
        //{

        //}

        ////http://www.licensespot.com/blog/wpf-listview-checkbox
        //public class CheckBoxListViewItem : INotifyPropertyChanged
        //{
        //    private bool isChecked;
        //    private string text;
        //    public bool IsChecked
        //    {
        //        get { return isChecked; }
        //        set
        //        {
        //            if (isChecked == value) return;
        //            isChecked = value;
        //            RaisePropertyChanged("IsChecked");
        //        }
        //    }
        //    public String Text
        //    {
        //        get { return text; }
        //        set
        //        {
        //            if (text == value) return;
        //            text = value;
        //            RaisePropertyChanged("Text");
        //        }
        //    }
        //    public CheckBoxListViewItem(string t, bool c)
        //    {
        //        this.Text = t;
        //        this.IsChecked = c;
        //    }
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    private void RaisePropertyChanged(string propName)
        //    {
        //        PropertyChangedEventHandler eh = PropertyChanged;
        //        if (eh != null)
        //        {
        //            eh(this, new PropertyChangedEventArgs(propName));
        //        }
        //    }
        //}

        private void Button_Kategori_Tilbage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Kategori_Næste_Click(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = main.Omkostninger;
        }

        private void ListBoxZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
        }

 

        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{

        //}



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
