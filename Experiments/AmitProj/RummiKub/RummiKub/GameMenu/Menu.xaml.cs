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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitWindow ex = new ExitWindow();
            this.Close();
            ex.Show();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow pfw = new ProfileWindow();
            this.Close();
            pfw.Show();
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            InstructionsWindow ins = new InstructionsWindow();
            this.Close();
            ins.Show();

        }
    }
}
