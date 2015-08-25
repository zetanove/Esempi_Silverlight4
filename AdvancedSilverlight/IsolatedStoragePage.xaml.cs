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
using System.IO.IsolatedStorage;
using System.IO;

namespace AdvancedSilverlight
{
    public partial class IsolatedStoragePage : UserControl
    {
        public IsolatedStoragePage()
        {
            InitializeComponent();
        }

        private void btLoad_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                tbQuota.Text = store.UsedSize + " / " + store.Quota;
                string path = "user.txt";
                if (store.FileExists(path))
                {
                    using (StreamReader reader =
                        new StreamReader(store.OpenFile(path, FileMode.Open, FileAccess.Read)))
                    {
                        string contents = reader.ReadToEnd();
                        string[] cred = contents.Split(';');
                        if (cred.Length == 2)
                        {
                            txtUsername.Text = cred[0];
                            txtPassword.Text = cred[1];
                        }
                    }
                }
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {

            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string path = "user.txt";

                try
                {
                    using (StreamWriter sw =
                        new StreamWriter(store.OpenFile(path,
                            FileMode.OpenOrCreate, FileAccess.Write)))
                    {
                        sw.Write(txtUsername.Text+";");
                        sw.Write(txtPassword.Text);
                    }
                    tbQuota.Text = store.UsedSize + " / " + store.Quota;
                }
                catch (IsolatedStorageException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            store.Remove();
        }

        private void btIncrease_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            store.IncreaseQuotaTo(store.Quota + 1024576);
        }
        
    }
}
