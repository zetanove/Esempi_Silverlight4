using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Multimedia
{
    public partial class ImagesPage : UserControl
    {
        public ImagesPage()
        {
            InitializeComponent();
           
        }

        private void Image_ImageOpened(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Image opened " + sender.ToString());
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Image failed " + e.ErrorException.ToString());
        }

        private void btSetUrl_Click(object sender, RoutedEventArgs e)
        {
            img.Source = new BitmapImage(new Uri(txtUrl.Text, UriKind.RelativeOrAbsolute));

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            
            
            
            
            
        }
    }
}
