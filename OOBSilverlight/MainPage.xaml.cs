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
using System.Net.NetworkInformation;
using System.IO;

namespace OOBSilverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            App.Current.InstallStateChanged += new EventHandler(Current_InstallStateChanged);
        }

        void Current_InstallStateChanged(object sender, EventArgs e)
        {
            if (App.Current.InstallState == InstallState.Installed)
            {
                btInstall.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (App.Current.InstallState == InstallState.InstallFailed)
            {
                MessageBox.Show("Errore di installazione");
            }
            else btInstall.Visibility = System.Windows.Visibility.Visible;
        }

        private void btInstall_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.InstallState != InstallState.Installed)
            {
                App.Current.Install();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            

            if (App.Current.IsRunningOutOfBrowser)
            {
                txtOOB.Text = "App. Out Of Browser";
                if (App.Current.HasElevatedPermissions)
                    txtOOB.Text += " Elevated Trust";
                btInstall.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                if (Application.Current.InstallState == InstallState.Installed)
                {
                    btInstall.Visibility = System.Windows.Visibility.Collapsed;
                    txtOOB.Text = "Applicazione installata localmente";
                }
                else
                {
                    btInstall.Visibility = System.Windows.Visibility.Visible;
                }
            }
            

            UpdateNetworkState();
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkChange_NetworkAddressChanged);
        }

        private void UpdateNetworkState()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                txtNetworkState.Text = "Rete disponibile";
            }
            else txtNetworkState.Text = "Rete non disponibile";
        }
        void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            UpdateNetworkState();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            App.Current.CheckAndDownloadUpdateAsync();
        }

        private void App_CheckAndDownloadUpdateCompleted(object sender,
            CheckAndDownloadUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                MessageBox.Show("L'applicazione è stata aggiornata, riavviarla per eseguire la nuova versione");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(
                    "E' disponibile un aggiornamento ma non è stato possibile scaricarlo:\n" +
                    e.Error+Environment.NewLine+
                    "Visita la home page dell'applicazione.");
            }
            else
            {
                MessageBox.Show("Nessun aggiornamento disponibile.");
            }
        }

        private void btNotify_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.IsRunningOutOfBrowser)
            {
                NotificationWindow notify = new NotificationWindow();
                notify.Height = 100;
                notify.Width = 200;
               
                StackPanel sp = new StackPanel();
                TextBlock text = new TextBlock();
                text.Text = "Hello";
                sp.Children.Add(text);
                Button btClose = new Button();
                btClose.Content = "chiudi";
                btClose.Click +=  delegate(object s, RoutedEventArgs ev)
                {
                    notify.Close();
                };
                sp.Children.Add(btClose);
                    
                notify.Content = sp;
                notify.Show(5000);
            }
        }

        private void btLeggiDocumenti_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.HasElevatedPermissions)
            {
                var fileNames = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                List<FileInfo> files = new List<FileInfo>();
                foreach (string file in fileNames)
                {
                    files.Add(new FileInfo(file));
                }
                lstDocumenti.DisplayMemberPath = "Name";
                lstDocumenti.ItemsSource = files;
            }
        }

        private void lstDocumenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Application.Current.HasElevatedPermissions)
            {
                if (lstDocumenti.SelectedItem is FileInfo)
                {
                    FileInfo fi = lstDocumenti.SelectedItem as FileInfo;
                    txtInfo.Text = fi.FullName + Environment.NewLine + "size: " + fi.Length;
                }
            }
        }

        private void btOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                bool b = ofd.ShowDialog() ?? false;
                if (b)
                {
                    txtInfo.Text = ofd.File.FullName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (lstDocumenti.SelectedItem is FileInfo)
            {
                FileInfo fi = lstDocumenti.SelectedItem as FileInfo;
                fi.MoveTo(fi.FullName + ".bak");
            }
        }

        bool isDragging = false;
        
        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current.IsRunningOutOfBrowser && !isDragging)
                isDragging = true;
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current.IsRunningOutOfBrowser && isDragging)
                isDragging = false;
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
                Application.Current.MainWindow.DragMove();
        }

        private void chkFullscreen_Checked(object sender, RoutedEventArgs e)
        {
            App.Current.Host.Content.IsFullScreen = true;
        }

        private void chkFullscreen_Unchecked(object sender, RoutedEventArgs e)
        {
            App.Current.Host.Content.IsFullScreen = false;
        }
    }
}
