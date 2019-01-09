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

// Mine namespase
using Stratego.Connection.DataBase;
using Stratego.Connection.Login;


namespace Stratego.Connection.Register
{
    /// <summary>
    /// Interaction logic for RegisterWin.xaml
    /// </summary>
    public partial class RegisterWin : Window
    {

        #region Constractor

        /// <summary>
        /// Defult constractor.
        /// </summary>
        public RegisterWin()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// On register click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void register_Click(object sender, RoutedEventArgs e)
        {
            // We can add here check on the length of the password.!!!!!!!!!!!!!!!!!!
            // Right now we check: 
            // 1. the same with confirm.
            // 2. the username not empty
            // 3. the username not awrady exist. 
            if (passwordTxtBox.Password.Equals(confirmPasswordTxtBox.Password) && usernameTxtBox.Text != "" && !UsernameRowExist(ConnectionDatabase.TheDataTable, usernameTxtBox.Text))
            {
                // Add to the database here.
                DataRow dr = ConnectionDatabase.TheDataTable.NewRow();
                dr["UserID"] = ConnectionDatabase.TheDataTable.Rows.Count + 1;
                dr["UserName"] = usernameTxtBox.Text;
                dr["Password"] = passwordTxtBox.Password;
                ConnectionDatabase.TheDataTable.Rows.Add(dr);

                // update the datatable in the client.
                ConnectionDatabase.UpdateDataBase();

                // And here we also need to upgrade the Server!!!!!!!!!!!!!!!!!!!!!!!!!!


                CallLogin();
            }
            else
            {
                MessageBox.Show("The username is taken or the password not the same as the confirm password.");
            }
        }

        /// <summary>
        /// On back click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            CallLogin();
        }

        #endregion

        #region Function

        /// <summary>
        /// Get database and username, return true if the username already exist in the database.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UsernameRowExist(DataTable dataTable, string username)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["UserName"].Equals(username))
                {
                    return true;
                }
            }
            return false;
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
