using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Accord.Video.FFMPEG;
using AForge.Video;
using AForge.Video.DirectShow;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
namespace ProyectoFinalPDI
{
    internal class MainWindowViewModel : ObservableObject
    {
        [Obsolete]
        public MainWindowViewModel()
        {
            EscritorioActvo = true;
            IniciarCamara = new RelayCommand(StartCamera);
            DetenerCamara = new RelayCommand(StopCamera);
            IniciarGrabacion = new RelayCommand(StartRecording);
            StopRecordingCommand = new RelayCommand(StopRecording);
        }

        private BitmapImage imagen;
        private bool escritorioActivo;
        private IVideoSource videosource;
        private VideoFileWriter videofilewriter;
        private bool grabando;
        private DateTime? frameTime;

        public BitmapImage Image
        {
            get { return imagen; }
            set { Set(ref imagen, value); }
        }

        public bool EscritorioActvo
        {
            get { return escritorioActivo; }
            set { Set(ref escritorioActivo, value); }
        }



        public ICommand IniciarGrabacion { get; private set; }

        public ICommand StopRecordingCommand { get; private set; }

        public ICommand IniciarCamara { get; private set; }

        public ICommand DetenerCamara { get; private set; }

        public ICommand SaveSnapshotCommand { get; private set; }



        private void StartCamera()
        {
            if (EscritorioActvo)
            {
                var rectangle = new Rectangle();
                foreach (var screen in System.Windows.Forms.Screen.AllScreens)
                {
                    rectangle = Rectangle.Union(rectangle, screen.Bounds);
                }
                videosource = new ScreenCaptureStream(rectangle);
                videosource.NewFrame += newFrame;
                videosource.Start();
            }
        }

        private void newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                if (grabando)
                {
                    using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                    {
                        if (frameTime != null)
                        {
                            videofilewriter.WriteVideoFrame(bitmap, DateTime.Now - frameTime.Value);
                        }
                        else
                        {
                            videofilewriter.WriteVideoFrame(bitmap);
                            frameTime = DateTime.Now;
                        }
                    }
                }
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {
                    var bi = bitmap.ToBitmapImage();
                    bi.Freeze();
                    Dispatcher.CurrentDispatcher.Invoke(() => Image = bi);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error on videoSource_NewFrame" + exc);
                StopCamera();
            }
        }

        private void StopCamera()
        {
            if (videosource != null && videosource.IsRunning)
            {
                videosource.SignalToStop();
                videosource.NewFrame -= newFrame;
            }
            Image = null;
        }

        private void StopRecording()
        {
            grabando = false;
            videofilewriter.Close();
            videofilewriter.Dispose();
        }

        [Obsolete]
        private void StartRecording()
        {
            var Dialog = new SaveFileDialog();
            Dialog.FileName = "Video1";
            Dialog.DefaultExt = ".avi";
            Dialog.AddExtension = true;
            var dialogresult = Dialog.ShowDialog();
            if (dialogresult != true)
            {
                return;
            }
            frameTime = null;
            videofilewriter = new VideoFileWriter();
            videofilewriter.Open(Dialog.FileName, (int)Math.Round(Image.Width, 0), (int)Math.Round(Image.Height, 0));
            grabando = true;
        }


    }
}
