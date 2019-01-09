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
using System.Data;

namespace helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataTable dt = new DataTable();

        public string theDataTablename= @"G:\Tal\Programing\yud B\EndProject\MyEndProject\Stratego\Stratego\bin\Debug\UsersData.xml";

        public MainWindow()
        {
            InitializeComponent();
            dt.ReadXml(theDataTablename);
            dg.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dt.Clear();
            dt.WriteXml(theDataTablename, XmlWriteMode.WriteSchema);
            dg.ItemsSource = dt.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dt.Rows.RemoveAt(int.Parse(id.Text) - 1);
            dt.WriteXml(theDataTablename, XmlWriteMode.WriteSchema);
            dg.ItemsSource = dt.DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["UserID"] = dt.Rows.Count + 1;
            dr["UserName"] = UserName.Text;
            dr["Password"] = Password.Text;
            dr["BestScore"] = 0;
            dt.Rows.Add(dr);
            dg.ItemsSource = dt.DefaultView;
            dt.WriteXml(theDataTablename, XmlWriteMode.WriteSchema);
        }
    }
}
