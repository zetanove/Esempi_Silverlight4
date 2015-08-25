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
using System.Windows.Media.Imaging;

namespace Multimedia
{
    public partial class CaptureScreenshotVideo : UserControl
    {
        public CaptureScreenshotVideo()
        {
            InitializeComponent();
        }

        private void myMediaElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WriteableBitmap wb = new WriteableBitmap(myMediaElement, null);

            Image image = new Image();
            image.Height = 64;
            image.Margin = new Thickness(5);
            image.Source = wb;

            image.MouseLeftButtonDown += new MouseButtonEventHandler(image_MouseLeftButtonDown);
            screenshots.Children.Add(image);

        }

        void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            screenshots.Children.Remove(sender as UIElement);
        }
    }
}
