using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Multimedia
{
    public partial class CaptureDevicePage : UserControl
    {
        private CaptureSource capture;

        public CaptureDevicePage()
        {
            InitializeComponent();
            capture = new CaptureSource();
        }

        private void btCapture_Click(object sender, RoutedEventArgs e)
        {
            if (CaptureDeviceConfiguration.AllowedDeviceAccess || CaptureDeviceConfiguration.RequestDeviceAccess())
            {
                VideoCaptureDevice webcam=cboWebcams.SelectedItem as VideoCaptureDevice;
                
                if(webcam==null)
                    CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice();
                                
                if (webcam != null)
                {
                    capture.Stop();
                    capture.VideoCaptureDevice = webcam;
                    capture.Start();
                    

                    VideoBrush brush = new VideoBrush();
                    brush.SetSource(capture);
                    brush.Stretch = Stretch.Uniform;
                    captureRect.Fill = brush;
                }
                else MessageBox.Show("Nessuna webcam disponibile");
            
            }
        }

        private void btDevices_Click(object sender, RoutedEventArgs e)
        {
            if (CaptureDeviceConfiguration.AllowedDeviceAccess || CaptureDeviceConfiguration.RequestDeviceAccess())
            {
                ReadOnlyCollection<VideoCaptureDevice> webcams = CaptureDeviceConfiguration.GetAvailableVideoCaptureDevices();
                ReadOnlyCollection<AudioCaptureDevice> mics = CaptureDeviceConfiguration.GetAvailableAudioCaptureDevices();

                foreach (VideoCaptureDevice device in webcams)
                {
                    cboWebcams.Items.Add(device);
                }

                foreach (AudioCaptureDevice device in mics)
                {
                    cboWebcams.Items.Add(device);
                }

            }
        }

        private void btSnapshot_Click(object sender, RoutedEventArgs e)
        {
            if (capture.State == CaptureState.Started)
            {
                capture.CaptureImageCompleted += new System.EventHandler<CaptureImageCompletedEventArgs>(capture_CaptureImageCompleted);
                capture.CaptureImageAsync();
            }
        }

        void capture_CaptureImageCompleted(object sender, CaptureImageCompletedEventArgs e)
        {
            Image img = new Image();
            img.Source = e.Result;
            stackImages.Children.Add(img);
        }

        

    }
}
