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
using System.Threading;
using System.Windows.Threading;

namespace AdvancedSilverlight
{
    public partial class MultithreadPage : UserControl
    {
        
        public MultithreadPage()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
        }

        bool stopped;
        int i = 0;
        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (i >= 100) 
                i = 0;
            stopped = false;
            btStart.IsEnabled = false;
            btStop.IsEnabled = true;
            Thread thread = new Thread(new ThreadStart(Work));
            thread.Start();
        }

        private void Work()
        {
            while (!stopped)
            {
                i++;
                Thread.Sleep(250);
                Dispatcher.BeginInvoke(delegate(){
                    progressBar1.Value=i;
                });
                if (i >= 100)
                {
                    Dispatcher.BeginInvoke(Stop);
                }
            }
        }

        private void Stop()
        {
            btStart.IsEnabled = true;
            btStop.IsEnabled = false;
            stopped = true;
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        public int Count = 0;
        Timer timer;
        private void btStartTimer_Click(object sender, RoutedEventArgs e)
        {
            btStartTimer.IsEnabled = false;
            timer = new Timer(new TimerCallback(TimeOp), tb1, 2000, 1000);
        }

        void TimeOp(object state)
        {
            TextBlock tb = state as TextBlock;
            Count++;
            tb.Dispatcher.BeginInvoke(delegate() { tb.Text = Count+ new String('.', Count); });
            if (Count == 10)
            {
                btStartTimer.Dispatcher.BeginInvoke(delegate() { btStart.IsEnabled = true; });
                timer.Dispose();
            }
        }

        DateTime startTime;
        private void btStartCrono_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispTimer = new DispatcherTimer();
            dispTimer.Interval =new TimeSpan(0,0,0,0, 200); //200ms
            dispTimer.Tick += new EventHandler(dispTimer_Tick);
            startTime = DateTime.Now;
            dispTimer.Start();
        }


        void dispTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts=(DateTime.Now-startTime);
            tbTime.Text = ts.Minutes + ":" + ts.Seconds;
        }

    }
}
