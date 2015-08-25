using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Multimedia
{
    public partial class BufferingPage : UserControl
    {
        public BufferingPage()
        {
            InitializeComponent();
        }

        private void media_BufferingProgressChanged(object sender, RoutedEventArgs e)
        {
            txtBuffer.Text =  String.Format("buffering {0:0}%",media.BufferingProgress*100);
            progressBar.Value = media.BufferingProgress * 100 ;
        }

        private void media_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (media.CurrentState == MediaElementState.Buffering)
            {
                txtBuffer.Visibility = System.Windows.Visibility.Visible;
                progressBar.Visibility = System.Windows.Visibility.Visible;
            }
            else {
                txtBuffer.Visibility = System.Windows.Visibility.Collapsed;
                progressBar.Visibility = System.Windows.Visibility.Collapsed;
            }

        }

        private void media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.ToString());
        }

        private void media_DownloadProgressChanged(object sender, RoutedEventArgs e)
        {
            txtDownload.Text = String.Format("{0:0}", media.DownloadProgress * 100);
        }
    }
}
