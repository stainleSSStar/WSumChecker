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
using System.Diagnostics;

namespace WSumChecker
{
    /// <summary>
    /// Logika interakcji dla klasy Licence.xaml
    /// </summary>
    public partial class Licence : Window
    {
        public Licence()
        {
            InitializeComponent();
        }

        private void License_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void License_OpenFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileToOpen = @"LICENCE.txt";
                var process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = fileToOpen
                };

                process.Start();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Licence file couldn't be loaded", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
