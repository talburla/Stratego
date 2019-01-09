using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
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
using System.Threading;
using System.Data;
using System.IO;

namespace RummiKub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Constractors

        public MainWindow()
        {
            InitializeComponent();
            SetUp();
        }

        #endregion

        #region SetUp

        public void SetUp()
        {
            // Create the Xml file if is not exist, and read the Data from the file .
            if (!File.Exists(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]).ToString() + "\\UsersData.xml"))
            {
                DataTable tempOne = new DataTable("Users");

                // Create the columns objects.
                DataColumn c1 = new DataColumn();
                DataColumn c2 = new DataColumn();
                DataColumn c3 = new DataColumn();

                // Set the name of the columns.
                c1.ColumnName = "UserID";
                c2.ColumnName = "UserName";
                c3.ColumnName = "Password";

                // Set the type of the columns.
                c1.DataType = typeof(System.Int32);
                c2.DataType = typeof(System.String);
                c3.DataType = typeof(System.String);

                // Set the uniqe of the columns.
                c1.Unique = true;
                c2.Unique = true;
                c3.Unique = false;

                // Add the columns to the table. 
                tempOne.Columns.Add(c1);
                tempOne.Columns.Add(c2);
                tempOne.Columns.Add(c3);

                // Set primarykey.
                DataColumn[] arr = new DataColumn[1];
                arr[0] = c1;
                tempOne.PrimaryKey = arr;

                // Create the xml file, because it's not exists.
                tempOne.WriteXml(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]).ToString() + "\\UsersData.xml", XmlWriteMode.WriteSchema);
            }

            try
            {
                StaticVariables.TheDataTable.ReadXml(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]).ToString() + "\\UsersData.xml");
            }
            catch (Exception)
            {
                MessageBox.Show("cant read the data base...");
            }

            // Show the intro of the game.
            this.Show();
            Thread.Sleep(2000);
            Connect co1 = new Connect();
            this.Close();
            co1.Show();

        }

        #endregion

    }
}
