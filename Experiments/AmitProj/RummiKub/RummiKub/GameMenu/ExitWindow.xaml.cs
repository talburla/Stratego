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

namespace RummiKub
{
    /// <summary>
    /// Interaction logic for ExitWindow.xaml
    /// </summary>
    public partial class ExitWindow : Window
    {
        public ExitWindow()
        {
            InitializeComponent();
        }

        private void Yes_Button_Click(object sender, RoutedEventArgs e)
        {
            StaticVariables.currentId = -1;
            Connect con = new Connect();
            this.Close();
            con.Show();
        }

        private void No_Button_Click(object sender, RoutedEventArgs e)
        {
            Menu mn = new Menu();
            this.Close();
            mn.Show();
        }
    }
}
