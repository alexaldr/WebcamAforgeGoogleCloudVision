using System;
using System.Windows.Forms;

namespace WebcamAforgeGoogleCloudVision
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormWebcam formWebcam = new FormWebcam();
            //Application.Run(new FormWebcam());// FormAlter);
            Application.Run(formWebcam);
        }
    }
}