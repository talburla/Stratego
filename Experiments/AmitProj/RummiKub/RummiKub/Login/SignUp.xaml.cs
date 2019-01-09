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
using System.IO;

namespace RummiKub
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {

        #region Constractors

        public SignUp()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Sign_Up(object sender, RoutedEventArgs e)
        {
            if (txtBlockPasswoed.Password.Equals(txtBlockConfirmPasswoed.Password) && txtBlockUserName.Text != "" && !UsernameRowExist(StaticVariables.TheDataTable, txtBlockUserName.Text))
            {
                DataRow dr = StaticVariables.TheDataTable.NewRow();
                dr["UserID"] = StaticVariables.TheDataTable.Rows.Count + 1;
                dr["UserName"] = txtBlockUserName.Text;
                dr["Password"] = txtBlockPasswoed.Password;
                StaticVariables.TheDataTable.Rows.Add(dr);
                SignIn si = new SignIn();
                this.Close();
                si.Show();
            }
            else
            {
                MessageBox.Show("The username is taken or the password not the same as the confirm password.");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Connect co = new Connect();
            this.Close();
            co.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StaticVariables.UpdateDataBase();
        }

        #endregion

        #region Functions

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

        #endregion


    }
}
