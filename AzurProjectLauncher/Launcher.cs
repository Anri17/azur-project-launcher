using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            string myFileToDownload = "https://drive.google.com/uc?export=download&confirm=Z049&id=1zEixv6Tf9fRqgkMvRV1lgO1eEKqZEn7G";

            myWebClient.DownloadFile(myFileToDownload, FileName);
        }

    }
}
