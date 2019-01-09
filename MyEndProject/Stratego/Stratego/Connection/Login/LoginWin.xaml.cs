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
using System.Windows.Shapes;
using System.Data;

// Mine namespace.
using Stratego.Connection.Register;
using Stratego.Connection.DataBase;

namespace Stratego.Connection.Login
{
    /// <summary>
    /// Interaction logic for LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {

        #region Constractors

        /// <summary>
        /// Defult constractor.
        /// </summary>
        public LoginWin()
        {
            InitializeComponent();
        }


        #endregion

        #region Events

        /// <summary>
        /// On login click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login_Click(object sender, RoutedEventArgs e)
        {
            bool found = false;
            foreach (DataRow row in ConnectionDatabase.TheDataTable.Rows)
            {
                if (row["UserName"].Equals(usernameTxtBox.Text) && row["Password"].Equals(passwordTxtBox.Password))
                {
                    found = true;

                    // Update the database of the menu and the network.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    //StaticVariables.currentId = (int)row["UserID"];

                    // Update the id that login in the menu!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // Call the menu window!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    //Menu m1 = new Menu();
                    //this.Close();
                    //m1.Show();
                    MessageBox.Show("Go menu");
                }
            }
            if (!found)
            {
                MessageBox.Show("Password or username incorrect.");
            }
        }

        /// <summary>
        /// On register click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWin registerWin = new RegisterWin();
            this.Close();
            registerWin.Show();
        }

        #endregion

    }
}
