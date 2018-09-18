using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;      //framework adicionado pelo nuget
using AForge.Video;                 //framework adicionado pelo nuget
using Google.Cloud.Vision.V1;       //api adicionada pelo nuget
using Newtonsoft.Json;              //biblioteca adicionada pelo nuget
using System.Drawing.Imaging;
using Google.Apis.Auth.OAuth2;
using System.IO;

namespace WebcamAforgeGoogleCloudVision
{
    public partial class FormWebcam : Form
    {
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice dispositivo;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;

        public FormWebcam()
        {
            InitializeComponent();
        }

        private void FormWebcam_Load(object sender, EventArgs e)
        {
            AtualizarDispositivos();
        }

        private void AtualizarDispositivos()
        {
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (dispositivos != null && dispositivos.Count != 0)
            {
                AtualizarComboDispositivos();
                cbDispositivo.SelectedIndex = 0;
                AtualizarComboResolucao();
            }
            else
            {
                cbDispositivo.Items.Add("Nenhum dispositivo encontrado!");
                cbDispositivo.SelectedIndex = 0;
            }
        }

        private void AtualizarComboDispositivos()
        {
            cbDispositivo.Items.Clear();
            foreach (FilterInfo webcams in dispositivos)
            {
                cbDispositivo.Items.Add(webcams.Name);
            }
            dispositivo = new VideoCaptureDevice(dispositivos[0].MonikerString);
        }

        private void AtualizarComboResolucao()
        {
            if (dispositivo.VideoCapabilities.Length != 0)
            {
                cbResolucao.Items.Clear();
                foreach (VideoCapabilities resolucoes in dispositivo.VideoCapabilities)
                {
                    cbResolucao.Items.Add(string.Format("{0} x {1}", resolucoes.FrameSize.Width, resolucoes.FrameSize.Height));
                }
                cbResolucao.SelectedIndex = 0;
                AlterarComboResolucao();
            }
            else
            {
                cbDispositivo.Items.Add("Não disponível!");
            }
        }

        private void AlterarComboDispositivo()
        {
            LiberarDispositivo();
            dispositivo = new VideoCaptureDevice(dispositivos[cbDispositivo.SelectedIndex].MonikerString);
            //linkar os métodos para clonar os frames
            dispositivo.NewFrame += NovoFrame;
            AtualizarComboResolucao();
            InicializarDispositivo();
        }

        private void AlterarComboResolucao()
        {
            LiberarDispositivo();
            dispositivo.VideoResolution = dispositivo.VideoCapabilities[cbResolucao.SelectedIndex];
            InicializarDispositivo();
        }

        private void InicializarDispositivo()
        {
            if (!dispositivo.IsRunning)
            {
                dispositivo.Start();
            }
        }

        private void LiberarDispositivo()
        {
            if (dispositivo.IsRunning)
            {
                dispositivo.Stop();
                pbWebcam.Image = null;
            }
        }

        private void NovoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (pbWebcam.Image != null)
            {
                pbWebcam.Image.Dispose();
            }
            pbWebcam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void cbDispositivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlterarComboDispositivo();
        }

        private void cbResolucao_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlterarComboResolucao();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Sair do aplicativo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                LiberarDispositivo();
                Application.Exit();
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            LiberarDispositivo();
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
            if (pbWebcam.Image != null)
            {

                //remover o link
                dispositivo.NewFrame -= NovoFrame;

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
                                Bitmap imagem = (Bitmap)pbWebcam.Image;
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
                dispositivo.NewFrame += NovoFrame;
            }
            else
            {
                MessageBox.Show("O dispositivo não foi iniciado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
