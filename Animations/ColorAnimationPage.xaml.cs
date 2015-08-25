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

namespace Animations
{
    public partial class ColorAnimationPage : UserControl
    {
        public ColorAnimationPage()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sb.GetCurrentState() == ClockState.Stopped)
                sb.Begin();
            else
            {
                sb.Pause();
                txt.Text=(rect.Fill as LinearGradientBrush).GradientStops[0].Color.ToString();
            }
        }
    }
}
