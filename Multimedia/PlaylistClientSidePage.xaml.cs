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

namespace Multimedia
{
    public partial class PlaylistClientSidePage : UserControl
    {
        public PlaylistClientSidePage()
        {
            InitializeComponent();
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = String.Format("{0}",media.Attributes["TITLE"]);
        }
    }
}
