using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Shapes
{
    public partial class ImageClip : UserControl
    {
        public ImageClip()
        {
            InitializeComponent();
        }

        private void btClipRect_Click(object sender, RoutedEventArgs e)
        {
            RectangleGeometry rect = new RectangleGeometry();
            rect.Rect = new Rect(50, 50, 250, 200);
            rect.RadiusX = 10;
            rect.RadiusY = 20;
            img.Clip = rect;
        }
    }
}
