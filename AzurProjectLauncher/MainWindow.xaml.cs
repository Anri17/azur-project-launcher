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
using System.Diagnostics;
using System.IO;

namespace AzurProjectLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Launcher launcher = new Launcher();

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("old_ver.exe"))
            {
                File.Delete("old_ver.exe");
                MessageBox.Show("The launcher has been updated");
            }
        }

        private void LaunchGameButton_Click(object sender, RoutedEventArgs e)
        {
            launcher.LaunchGame();
        }

        private void DownloadGameButton_Click(object sender, RoutedEventArgs e)
        {
            launcher.DownloadFile();
        }

        private void UpdateLauncherButton_Click(object sender, RoutedEventArgs e)
        {
            launcher.UpdateLauncher();
        }
    }
}
