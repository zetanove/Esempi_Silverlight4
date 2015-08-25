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
using System.Windows.Interop;

namespace UserInterfaces
{
    public partial class FullScreenPage : UserControl
    {
        public FullScreenPage()
        {
            InitializeComponent();
            App.Current.Host.Content.FullScreenOptions = FullScreenOptions.StaysFullScreenWhenUnfocused;
            Application.Current.Host.Content.FullScreenChanged += new EventHandler(Content_FullScreenChanged);
        }

        void Content_FullScreenChanged(object sender, EventArgs e)
        {
            if (Application.Current.Host.Content.IsFullScreen)
                button1.Content = "Esci da da schermo intero";
            else button1.Content = "Schermo intero";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Host.Content.IsFullScreen = !Application.Current.Host.Content.IsFullScreen;
        }
    }
}
