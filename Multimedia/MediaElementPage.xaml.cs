using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Threading;

namespace Multimedia
{
    public partial class MediaElementPage : UserControl
    {
        DispatcherTimer timer;
        public MediaElementPage()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (media.CurrentState == System.Windows.Media.MediaElementState.Playing)
            {
                ShowPosition();
            }

        }

        private void media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.ToString());
        }

        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
            btPlay.IsEnabled = false;
            btPause.IsEnabled = true;
            btStop.IsEnabled = true;

        }

        private void ShowPosition()
        {
            txtDurata.Text = string.Format("{0:00}:{1:00}/{2:00}:{3:00}", media.Position.Minutes, media.Position.Seconds,
                media.NaturalDuration.TimeSpan.Minutes, media.NaturalDuration.TimeSpan.Seconds);

        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            ShowPosition();
            btPlay.IsEnabled = true;
        }

        private void btPause_Click(object sender, RoutedEventArgs e)
        {
            btPlay.IsEnabled = true;
            btPause.IsEnabled = false;
            media.Pause();

        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            btPlay.IsEnabled = true;
            btPause.IsEnabled = false;
            btStop.IsEnabled = false;
            media.Position = new TimeSpan(0);
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            btPlay.IsEnabled = true;
            btStop.IsEnabled = false;
            btPause.IsEnabled = false;
            media.Stop();
        }

        private void media_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (media.CurrentState == System.Windows.Media.MediaElementState.Playing)
            {
                timer.Start();
            }
            else if(media.CurrentState== System.Windows.Media.MediaElementState.Paused || 
                media.CurrentState== System.Windows.Media.MediaElementState.Stopped)
            {
                timer.Stop();
            }
            ShowPosition();
        }
    }
}
