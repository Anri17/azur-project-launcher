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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Security.AccessControl;

namespace AzurProjectLauncher
{
    public class Launcher
    {
        public string GameDir { get; private set; }
        public string FileName { get; private set; }
        public string VersionFile { get; private set; }
        public string BaseDir { get; private set; }

        public Launcher()
        {
            GameDir = Properties.Settings.Default.GameDir;
            FileName = "Azur.zip";
            VersionFile = "version.txt";
        }

        public bool DownloadFile()
        {
            try
            {
                WebClient myWebClient = new WebClient();
                string myFileToDownload = "https://github.com/Anri17/shooter-pap/releases/download/latest/Azur.zip";
                string currentDirectory = Directory.GetCurrentDirectory();

                // Notify user about the instalation process
                MessageBox.Show("The launcher will now download and install the game on " + GameDir);

                // Download the required file
                myWebClient.DownloadFile(myFileToDownload, FileName);

                // Delete directory to prepare for instalation
                if (Directory.Exists(GameDir))
                {
                    Directory.Delete(GameDir, true);
                }

                // install the game
                ZipFile.ExtractToDirectory(currentDirectory + "\\" + FileName, GameDir); // extract the downloaded file
                File.Delete(currentDirectory + "\\" + FileName); // delete zip file after extraction is done

                MessageBox.Show("Download Sucessfull!"); // notify user that everything is done
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("No Internet Connection. The game will not download.");
                return false;
            }
        }

        public void LaunchGame()
        {
            if (File.Exists(GameDir + "\\ShooterPAP.exe"))
            {
                Process.Start(GameDir + "\\ShooterPAP.exe");
            }
            else
            {
                if (Directory.Exists(GameDir))
                {
                    MessageBox.Show("Something went wrong. Deleting folder. Download again please.");
                    Directory.Delete(GameDir, true);
                }
                else
                {
                    MessageBox.Show("Game not installed. Please download the game first.");
                }
            }
        }

        public bool GameIsUpToDate()
        {
            if (!Directory.Exists(GameDir))
            {
                return false;
            }

            if (!File.Exists(GameDir + @"\version.txt"))
            {
                return false;
            }

            try
            {
                WebClient myWebClient = new WebClient();
                string myFileToDownload = "https://github.com/Anri17/shooter-pap/releases/download/latest/version.txt";
                string currentDirectory = Directory.GetCurrentDirectory();

                myWebClient.DownloadFile(myFileToDownload, "version.txt");

                string downloadedVersionFile = currentDirectory + @"\version.txt";

                string currentVersion = File.ReadAllText(GameDir + @"\version.txt");
                string downloadedVersion = File.ReadAllText(downloadedVersionFile);

                File.Delete(downloadedVersionFile);

                if (!Equals(currentVersion, downloadedVersion))
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("No Internet Connection. The Launcher will not check for updates.");
                return true;
            }
        }

        public string DefineGameDirectory()
        {
            string newInstallDir;
            string oldInstallDir = GameDir;
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result == CommonFileDialogResult.Cancel)
                {
                    return oldInstallDir;
                }

                newInstallDir = Path.Combine(dialog.FileName, "Azur Project");
            }

            if (Equals(oldInstallDir, newInstallDir))
            {
                return oldInstallDir;
            }
            else
            {
                MessageBox.Show($"The game files will now be moved to {newInstallDir}");

                MoveInstallDirectory(oldInstallDir, newInstallDir);

                GameDir = newInstallDir;
                Properties.Settings.Default.GameDir = newInstallDir;

                MessageBox.Show($"The game files have been moved.");
                return newInstallDir;
            }
        }

        void MoveInstallDirectory(string oldInstallDir, string newInstallDir)
        {
            // Copy all the files to the new dir
            if (!Directory.Exists(newInstallDir))
                Directory.CreateDirectory(newInstallDir);

            // substring is to remove destination_dir absolute path (E:\).

            // Create subdirectory structure in destination    
            foreach (string dir in System.IO.Directory.GetDirectories(oldInstallDir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(newInstallDir, dir.Substring(oldInstallDir.Length + 1)));
                // Example:
                //     > C:\sources (and not C:\E:\sources)
            }

            foreach (string file_name in System.IO.Directory.GetFiles(oldInstallDir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.File.Copy(file_name, System.IO.Path.Combine(newInstallDir, file_name.Substring(oldInstallDir.Length + 1)), true);
            }

            // Delete old dir after copying is done
            Directory.Delete(oldInstallDir, true);
        }

        public void SetFirstTimeInstalationDirectory()
        {
            MessageBox.Show("Where do you want the game installed?");
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result == CommonFileDialogResult.Cancel)
                {
                    Properties.Settings.Default.GameDir = @"C:\Azur Project";
                    GameDir = Properties.Settings.Default.GameDir;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.GameDir = Path.Combine(dialog.FileName, "Azur Project");
                    GameDir = Properties.Settings.Default.GameDir;
                    Properties.Settings.Default.Save();
                }
            }

            DownloadFile();
        }
    }
}
