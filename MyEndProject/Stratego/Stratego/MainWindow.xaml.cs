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
using System.Windows.Threading;
using System.IO;
using System.Data;

// Mine namespace.
using Stratego.Connection.Login;
using Stratego.Connection.DataBase;
using Stratego.LiveNetworks;
using Stratego.Connection.Networks;

namespace Stratego
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Prop

        // The timer that responsabilty to dispaly the intro.
        DispatcherTimer introTimer = new DispatcherTimer();

        // The intro time.
        public const int introTime = 3;

        #endregion

        #region Constractors

        /// <summary>
        /// Defult constractor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetUp();
        }

        #endregion

        #region Events

        /// <summary>
        /// Every interval time doing this code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void introTimer_Tick(object sender, EventArgs e)
        {
            // After shows the intro call to the login window.
            CallLogin();

            introTimer.Stop();
        }

        #endregion

        #region Functions

        /// <summary>
        /// Uplode to the relevant data of conection, display the intro, call to the login window.
        /// </summary>
        public void SetUp()
        {

            // Load files and conection data to the conecction data table.
            UpdateDataBase();

            // Display the intro for 5 seconds using the timer.
            ShowIntro();

        }

        /// <summary>
        /// Update the data with the static class of the conecction class.
        /// </summary>
        public void UpdateDataBase()
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
            
            // Update the conecction database.
            try
            {
                // Need to be deleted.
                ConnectionDatabase.TheDataTable.ReadXml(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]).ToString() + "\\UsersData.xml");
                
                // Only this need to stay.
                // Get the most upadate data from the server.
                ConnectionNetworks.UpdateClient();
            }
            catch (Exception)
            {
                MessageBox.Show("cant read the data base...");
            }

            // Start listen if we need to be updated.
            GetServerUpdates.ListenServer();

        }

        /// <summary>
        /// Display the intro 2 seconds.
        /// </summary>
        public void ShowIntro()
        {
            // Timer setting
            introTimer.Tick += new EventHandler(introTimer_Tick);
            introTimer.Interval = new TimeSpan(0, 0, 0, 0, introTime * 1000);


            // Show the image.
            string programPath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]).ToString();            
            Image introImage = new Image();            
            introImage.Source = new BitmapImage(new Uri(programPath.Substring(0, programPath.IndexOf("\\bin")) + "\\Connection\\Images\\Intro\\IntroStratego.jpg"));
            introImage.Width = IntroPlace.Width;
            introImage.Height = IntroPlace.Height;
            IntroPlace.Children.Add(introImage);

            //Strat the timer.
            introTimer.Start();
        }

        /// <summary>
        /// Call to the login window.
        /// </summary>
        public void CallLogin()
        {
            LoginWin Login = new LoginWin();
            this.Close();
            Login.Show();
        }


        #endregion

    }
}
