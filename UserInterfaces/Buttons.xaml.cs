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

namespace UserInterfaces
{
    public partial class Buttons : UserControl
    {
        
        public Buttons()
        {
            InitializeComponent();
        }

        int repeatCount = 0;
        private void repeatButton_Click(object sender, RoutedEventArgs e)
        {
            repeatCount++;
            txtCount.Text = repeatCount.ToString();
        }
    }
}
