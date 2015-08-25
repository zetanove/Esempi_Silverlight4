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

namespace Styling
{
    public partial class ResourceDictionaryPage : UserControl
    {
        public ResourceDictionaryPage()
        {
            InitializeComponent();

            LinearGradientBrush brush=this.Resources["RedBlackBrush"] as LinearGradientBrush;
        }
    }
}
