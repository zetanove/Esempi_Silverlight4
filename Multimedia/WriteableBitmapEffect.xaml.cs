using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Multimedia
{
    public partial class WriteableBitmapEffect : UserControl
    {
        public WriteableBitmapEffect()
        {
            InitializeComponent();
        }

        private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WriteableBitmap bmp = new WriteableBitmap(img, null);
            for (int i = 0; i < bmp.Pixels.Length; i++)
            {
                bmp.Pixels[i] ^= 0x00ffffff;
            }
            img.Source = bmp;

        }
    }
}
