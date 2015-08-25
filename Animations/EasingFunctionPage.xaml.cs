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
    public partial class EasingFunctionPage : UserControl
    {
        public EasingFunctionPage()
        {
            InitializeComponent();
        }

        private void Mouse_Clicked(object sender, MouseButtonEventArgs e)
        {
            myStoryboard.Begin();
        }
    }
}
