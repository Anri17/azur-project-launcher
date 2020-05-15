using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace AzurProjectLauncher
{
    public class Launcher
    {
        public string InstallDir { get; private set; }
        public string FileName { get; private set; }
        public string VersionFile { get; private set; }
        public string BaseDir { get; private set; }

        public Launcher()
        {
            InstallDir = "C:\\Azur Project";
            FileName = "Azur.zip";
            VersionFile = "version.txt";
        }

        public void DownloadFile()
        {
            WebClient myWebClient = new WebClient();
            string myFileToDownload = "https://github.com/Anri17/shooter-pap/releases/download/latest/Azur.zip";
            string currentDirectory = Directory.GetCurrentDirectory();

            // Notify user about the instalation process
            MessageBox.Show("The launcher will now download and install the game on " + InstallDir);

            // Download the required file
            myWebClient.DownloadFile(myFileToDownload, FileName);

            // Delete directory to prepare for instalation
            if (Directory.Exists(InstallDir))
            {
                Directory.Delete(InstallDir, true);
            }
            
            // install the game
            ZipFile.ExtractToDirectory(currentDirectory + "\\" + FileName, InstallDir); // extract the downloaded file
            File.Delete(currentDirectory + "\\" + FileName); // delete zip file after extraction is done

            MessageBox.Show("Download Sucessfull!"); // notify user that everything is done
            
        }

        public void LaunchGame()
        {
            if (File.Exists(InstallDir + "\\ShooterPAP.exe"))
            {
                Process.Start(InstallDir + "\\ShooterPAP.exe");
            }
            else
            {
                if (Directory.Exists(InstallDir))
                {
                    MessageBox.Show("Something went wrong. Deleting folder. Download again please.");
                    Directory.Delete(InstallDir, true);
                }
                else
                {
                    MessageBox.Show("Game not installed. Please download the game first.");
                }
            }
        }

        public bool GameIsUpToDate()
        {
            if (!Directory.Exists(InstallDir))
            {
                return false;
            }

            if (!File.Exists(InstallDir + @"\version.txt"))
            {
                return false;
            }

            WebClient myWebClient = new WebClient();
            string myFileToDownload = "https://github.com/Anri17/shooter-pap/releases/download/latest/version.txt";
            string currentDirectory = Directory.GetCurrentDirectory();

            myWebClient.DownloadFile(myFileToDownload, "version.txt");

            string downloadedVersionFile = currentDirectory + @"\version.txt";

            string currentVersion = File.ReadAllText(InstallDir + @"\version.txt");
            string downloadedVersion = File.ReadAllText(downloadedVersionFile);

            File.Delete(downloadedVersionFile);

            if (!Equals(currentVersion, downloadedVersion))
            {
                return false;
            }

            return true;
        }

        public string DefineGameDirectory()
        {
            string newInstallDir;
            string oldInstallDir = InstallDir;
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                newInstallDir = dialog.SelectedPath + @"\Azur Project";
            }

            if (Equals(oldInstallDir, newInstallDir))
            {
                return oldInstallDir;
            }
            else
            {
                MessageBox.Show($"The game files will now be moved to {newInstallDir}");

                Directory.Move(oldInstallDir, newInstallDir);

                InstallDir = newInstallDir;

                MessageBox.Show($"The game files have been moved.");
                return newInstallDir;
            }
        }
    }
}
