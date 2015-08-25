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
    public partial class DoubleAnimPage : UserControl
    {
        public DoubleAnimPage()
        {
            InitializeComponent();
        }

        private void rect2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sb.Begin();
        }

        private void rect3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sb3.Begin();
        }
    }
}
