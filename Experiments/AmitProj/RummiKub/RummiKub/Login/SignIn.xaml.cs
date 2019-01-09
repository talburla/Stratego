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

namespace RummiKub
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void BackSignIn_Click(object sender, RoutedEventArgs e)
        {
            Connect co = new Connect();
            this.Close();
            co.Show();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            bool found = false;
            foreach (DataRow row in StaticVariables.TheDataTable.Rows)
            {
                if (row["UserName"].Equals(txtBlockUserName.Text) && row["Password"].Equals(txtBlockPasswoed.Password))
                {
                    found = true;

                    StaticVariables.currentId = (int)row["UserID"];

                    Menu m1 = new Menu();
                    this.Close();
                    m1.Show();
                }
            }
            if (!found)
            {
                MessageBox.Show("Password or username incorrect.");
            }
        }
    }
}
