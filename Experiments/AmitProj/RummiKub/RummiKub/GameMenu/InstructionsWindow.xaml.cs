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
using System.IO;

namespace RummiKub
{
    /// <summary>
    /// Interaction logic for InstructionsWindow.xaml
    /// </summary>
    public partial class InstructionsWindow : Window
    {

        #region Prop

        // The list of the instruction picture.
        public List<Image> m = new List<Image>();

        // The currect picture index.
        int curr = 0;

        #endregion

        #region Constractors

        public InstructionsWindow()
        {
            InitializeComponent();
            ShowImage();
        }

        #endregion

        #region ClickEvents

        private void NextPage_button_Click(object sender, RoutedEventArgs e)
        {
            if (curr + 1 < m.Count)
            {
                Gr.Children.Clear();
                Gr.Children.Add(m[++curr]);
            }
        }

        private void Back_button_Click_1(object sender, RoutedEventArgs e)
        {
            if (curr > 0)
            {
                Gr.Children.Clear();
                Gr.Children.Add(m[--curr]);
            }
            else
            {
                Menu m1 = new Menu();
                this.Close();
                m1.Show();
            }
        }

        #endregion

        #region SetUp

        public void ShowImage()
        {

            string temp = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]).ToString();         

            string[] fileEntries = Directory.GetFiles(temp.Substring(0, temp.IndexOf("bin")) +  @"Images\instructions");

            for (int i = 0; i < fileEntries.Length; i++)
            {
                BitmapImage image = new BitmapImage(new Uri(fileEntries[i] ,UriKind.Absolute));
                m.Add(new Image());
                m[i].Source = image;
                m[i].Width = Gr.Width;
                m[i].Height = Gr.Height;                
            }

            Gr.Children.Add(m[curr]);
        }

        #endregion
    }
}
