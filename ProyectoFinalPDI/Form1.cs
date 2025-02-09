using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using AForge.Video;
using AForge.Controls;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalPDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarVideoSource(); //controlamos que el video se pare cuando cerramos
        }
        private void txtGo_Click(object sender, EventArgs e)
        {
            //nos vamos directamente al WPF para grabar el escritorio
            Hide();
            MainWindow main = new MainWindow(true);
            main.Visibility = System.Windows.Visibility.Visible;
            main.ShowDialog();
            Close();
        }

        //Declaramos los metodos para grabar la cámara
        private VideoCaptureDevice VideoCaptureDev = null;
        private VideoCaptureDeviceForm captureDevice;
        private Bitmap Recorder;
        public VideoFileWriter FileWriter = new VideoFileWriter();
        private SaveFileDialog saveAvi;



        private void Form1_Load(object sender, EventArgs e)
        {
            // al cargar el form cargamos los datos importantes 
            captureDevice = new VideoCaptureDeviceForm();
        }
        
        private void VideoSource(IVideoSource source)
        {
            //Por si queremos cambiar de calidad de camara vamos a parar primero la calidad que tenia para realizar el cambio
            CerrarVideoSource();
            //E Inicializamos el videosource
            videoSourcePlayer.VideoSource = source;
            videoSourcePlayer.Start();
        }

        private void buttonRecStart_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDeviceForm();

            if (captureDevice.ShowDialog(this) == DialogResult.OK)
            {
                //Gracias a la clase de VideoCaptureDeviceForm que añadimos al form podemos tener una bonita pantalla
                // donde seleccionaremos los datos que nos haga falta y ahi dejamos correr el videocapture
                VideoCaptureDev = captureDevice.VideoDevice;
                //Seleccionamos el videocapture y lo corremos para que la camara se encienda con los datos especificados de arriba
                VideoSource(VideoCaptureDev);
                VideoCaptureDev.NewFrame += new NewFrameEventHandler(VideoNewFrame);
                VideoCaptureDev.Start();
            }
        }
        void VideoNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (buttonRecStop.Text == "Stop Record")
            {
                Recorder = (Bitmap)eventArgs.Frame.Clone();
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
                FileWriter.WriteVideoFrame(Recorder);
            }
            else 
            {
                Recorder = (Bitmap)eventArgs.Frame.Clone();
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            }
        }


        private void buttonRecStop_Click(object sender, EventArgs e)
        {   //Este boton tendrá 2 funciones, detener la grabacion y detener la camara para que ya no se muestre
            // 
            if (buttonRecStop.Text == "Stop Record")
            {
                buttonRecStop.Text = "Stop Camera";
                if (VideoCaptureDev == null)
                { 
                    return; 
                }
                if (VideoCaptureDev.IsRunning)
                {
                    FileWriter.Close();
                    pictureBox1.Image = null;
                }
            }
            // te apaga la camara
            else
            {
                this.VideoCaptureDev.Stop();
                FileWriter.Close();
                pictureBox1.Image = null;
            }
        }

        private void buttonRecSave_Click(object sender, EventArgs e)
        {
            //Aqui se ingresa cuando el boton sea stop camera , que asi siempre sera
            //para que luego elijas el nombre del archivo y lo guardes donde quieras 
            // para que al final empieces a grabar

            if (buttonRecStop.Text == "Stop Camera")
            {
                saveAvi = new SaveFileDialog();
                saveAvi.Filter = "Avi Files (*.avi)|*.avi";
                if (saveAvi.ShowDialog() == DialogResult.OK)
                {
                    int height = captureDevice.VideoDevice.VideoResolution.FrameSize.Height;
                    int width = captureDevice.VideoDevice.VideoResolution.FrameSize.Width;
                    FileWriter.Open(saveAvi.FileName, width, height, 25, VideoCodec.Default, 5000000);
                    FileWriter.WriteVideoFrame(Recorder);

                    buttonRecStop.Text = "Stop Record";
                }
            }
        }
        private void CerrarVideoSource()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();

                for (int i = 0; i < 30; i++)
                {
                    if (!videoSourcePlayer.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (videoSourcePlayer.IsRunning)
                {
                    videoSourcePlayer.Stop();
                }

                videoSourcePlayer.VideoSource = null;
            }
        }
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

