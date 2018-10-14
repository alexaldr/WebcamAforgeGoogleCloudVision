using AForge.Video;                 //framework adicionado pelo nuget
using AForge.Video.DirectShow;      //framework adicionado pelo nuget
using Google.Cloud.Vision.V1;       //api adicionada pelo nuget
using System;

//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;

//using Newtonsoft.Json;              //biblioteca adicionada pelo nuget
using System.Drawing.Imaging;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

//using Google.Apis.Auth.OAuth2;
//using System.IO;

namespace WebcamAforgeGoogleCloudVision
{
    public partial class FormWebcam : Form
    {
        private FilterInfoCollection allDevices;
        private VideoCaptureDevice currentDevice;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;

        public FormWebcam()
        {
            InitializeComponent();
        }

        private void FormWebcam_Load(object sender, EventArgs e)
        {
            this.allDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cboDevices.SelectedIndex = -1;
            cboDevices.Items.Clear();
            bool hasDevices = false;
            if (allDevices.Count != 0)
            {
                foreach (FilterInfo currentCam in allDevices)
                {
                    cboDevices.Items.Add(currentCam.Name);
                    hasDevices = true;
                }
            }
            else
            {
                cboDevices.Items.Add("Nenhum dispositivo encontrado!");
            }
            cboDevices.Enabled = hasDevices;
            cboDevices.SelectedIndex = 0;

            //AtualizarComboResolucao();
        }

        private void cbDispositivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCapabilities.SelectedIndex = -1;
            cboCapabilities.Items.Clear();
            bool hasResolution = false;
            if (cboDevices.Enabled)
            {
                currentDevice = new VideoCaptureDevice(allDevices[cboDevices.SelectedIndex].MonikerString);
            }

            if (currentDevice != null && currentDevice.VideoCapabilities.Length != 0)
            {
                foreach (VideoCapabilities capability in currentDevice.VideoCapabilities)
                {
                    cboCapabilities.Items.Add($"{capability.FrameSize.Width}x{capability.FrameSize.Height} - {capability.MaximumFrameRate} FPS");
                    hasResolution = true;
                }
            }
            else
            {
                cboCapabilities.Items.Add("Não disponível!");
            }
            cboCapabilities.Enabled = hasResolution;
            cboCapabilities.SelectedIndex = 0;
        }

        private void cbResolucao_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopStream();
            if (cboCapabilities.SelectedIndex >= 0 && cboDevices.Enabled && cboCapabilities.Enabled)
            {
                StartStream();
            }
        }

        private void StartStream()
        {
            if (currentDevice != null)
            {
                lock (this)
                {
                    currentDevice.NewFrame += NovoFrame;
                    currentDevice.VideoResolution = currentDevice.VideoCapabilities[cboCapabilities.SelectedIndex];
                    currentDevice.Start();
                }
            }
        }

        private void StopStream()
        {
            if (currentDevice != null)
            {
                if (currentDevice.IsRunning)
                {
                    currentDevice.Stop();
                }
            }
            pbWebcam.Image = null;
        }

        private async void NovoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pbWebcam.Image != null)
            {
                pbWebcam.Image.Dispose();
            }

            //Utilizar INVOKE PARA TENTAR RESOLEVR ESTE PROBLEMA
            //if (this.InvokeRequired)
            //{
            //    pbWebcam.Invoke(new Action(() => pbWebcam.Image = (Bitmap)eventArgs.Frame.Clone()));
            //}
            //pbWebcam.Invoke((delegate)() =>
            //this.pbWebcam.Invoke((MethodInvoker)delegate
            //{
            //    pbWebcam.Image = (Bitmap)eventArgs.Frame.Clone();
            //});
            //lock(this)
            //{
            if (pbWebcam.InvokeRequired)
            {
                pbWebcam.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            //pbWebcam.Image = (Bitmap)eventArgs.Frame.Clone();
            //}
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Sair do aplicativo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                StopStream();
                Application.Exit();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopStream();
            base.OnFormClosing(e);
        }

        private void btAnalisar_Click(object sender, EventArgs e)
        {
            using (openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens (*.jpg)|*.jpg";
                openFileDialog.DefaultExt = "*.jpg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        lock (this)
                        {
                            //Variável setada no código devido erro ao reconhecer variável setada no ambiente
                            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\ApiKeys\googleKey.json");
                            string Pathsave = System.Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

                            //Cliente da requisição
                            var client = ImageAnnotatorClient.Create();

                            //Carregar a imagem na memória
                            var imagem = Google.Cloud.Vision.V1.Image.FromFile(openFileDialog.FileName);

                            //Executa a análise da imagem
                            var resposta = client.DetectFaces(imagem);

                            foreach (var face in resposta)
                            {
                                MessageBox.Show("Imagem analisada com sucesso:\n\n\n"
                                    + "Nome: " + openFileDialog.SafeFileName + ":\n"
                                    + "Alegria: " + face.JoyLikelihood + "\n"
                                    + "Raiva: " + face.AngerLikelihood + "\n"
                                    + "Tristeza: " + face.SorrowLikelihood + "\n"
                                    + "Surpresa: " + face.SurpriseLikelihood + "\n"
                                    + "Subexposição: " + face.UnderExposedLikelihood + "\n"
                                    + "Borrado: " + face.BlurredLikelihood + "\n"
                                    + "Chapéu: " + face.HeadwearLikelihood + "\n"
                                    + "Confiança da análise: " + face.DetectionConfidence + "\n"
                                    + "delimitador: " + face.BoundingPoly + "\n"
                                    + "FdBoundingPoly: " + face.FdBoundingPoly + "\n"
                                    //+ "Landmarks: " + face.Landmarks + "\n"
                                    //+ "LandmarkingConfidence: " + face.LandmarkingConfidence + "\n"
                                    + "PanAngle: " + face.PanAngle + "\n"
                                    + "RollAngle: " + face.RollAngle + "\n"
                                    + "TiltAngle: " + face.TiltAngle + "\n"

                                    + ".", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //MessageBox.Show("Imagem analisada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha ao analisar imagem!\n" + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Operação cancelada!", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (this.pbWebcam.Image != null)
            {
                //remover o link
                currentDevice.NewFrame -= NovoFrame;

                //using para ser descartado depois
                using (saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Imagens (*.jpg)|*.jpg";
                    saveFileDialog.DefaultExt = "*.jpg";
                    /*
                    JPEG
                    PNG8
                    PNG24
                    GIF
                    GIF animado (primeiro quadro apenas)
                    BMP
                    WEBP
                    RAW
                    ICO
                     */
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ImageFormat format = ImageFormat.Jpeg;

                        try
                        {
                            lock (this)
                            {
                                Bitmap imagem = (Bitmap)this.pbWebcam.Image;
                                imagem.Save(saveFileDialog.FileName, format);
                                MessageBox.Show("Imagem salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Falha ao salvar a imagem!\n" + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operação cancelada!", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //linkar métodos para clonar frames
                currentDevice.NewFrame += NovoFrame;
            }
            else
            {
                MessageBox.Show("O dispositivo não foi iniciado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbWebcam_Click(object sender, EventArgs e)
        {
        }

        private void btExecutar_Click(object sender, EventArgs e)
        {
        }
    }
}