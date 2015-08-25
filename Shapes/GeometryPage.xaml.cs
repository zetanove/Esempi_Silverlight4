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
    public partial class GeometryPage : UserControl
    {
        public GeometryPage()
        {
            InitializeComponent();
        }

        private void Path_MouseMove(object sender, MouseEventArgs e)
        {
            txtCoords.Text = e.GetPosition(LayoutRoot).ToString();
        }
    }
}
