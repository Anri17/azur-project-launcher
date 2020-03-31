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

        public Launcher()
        {
            InstallDir = "C:\\Azur Project";
            FileName = "Azur.zip";
        }

        public void DownloadFile()
        {
            WebClient myWebClient = new WebClient();
            string myFileToDownload = "https://github.com/Anri17/shooter-pap/releases/download/beta-20200331/Azur.zip";
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
    }
}
