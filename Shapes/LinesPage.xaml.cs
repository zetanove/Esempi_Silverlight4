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

namespace Shapes
{
    public partial class LinesPage : UserControl
    {
        public LinesPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for(int x=0; x <= 360; x++)
            {
                polyline.Points.Add(new Point(x, 50+ 100* Math.Sin(x * Math.PI /180)));
            }
        }
    }
}
