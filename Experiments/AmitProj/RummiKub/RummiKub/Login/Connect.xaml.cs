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
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Connect : Window
    {
 
        public Connect()
        {
            InitializeComponent();
        }

        private void Sign_In(object sender, RoutedEventArgs e)
        {
            SignIn s = new SignIn();
            this.Close();
            s.Show();
        }

        private void Sign_Up(object sender, RoutedEventArgs e)
        {
            SignUp s = new SignUp();
            this.Close();
            s.Show();
        }
    }
}
