using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebcamAforgeGoogleCloudVision
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormWebcam formWebcam = new FormWebcam();
            //Application.Run(new FormWebcam());// FormAlter);
            Application.Run(formWebcam);
        }
    }
}
