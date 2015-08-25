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
using System.Xml.Linq;
using System.Xml;

namespace DataBinding
{
    public partial class CollectionBindingPage : UserControl
    {
        private IEnumerable<Persona> m_persone;
        public CollectionBindingPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_DownloadCompleted;
            Uri xmlUri = new Uri("Persone.xml", UriKind.Relative);
            client.DownloadStringAsync(xmlUri);
        }

        private void client_DownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                LoadXmlData(e.Result);
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        public void LoadXmlData(string xmlContent)
        {
            XDocument doc = XDocument.Parse(xmlContent);
            m_persone = from persona in doc.Descendants("Persona")
                        select new Persona
                        {
                            Nome = (string)persona.Attribute("Nome"),
                            Cognome = (string)persona.Attribute("Cognome"),
                            DataNascita = Convert.ToDateTime((string)persona.Attribute("DataNascita"))
                        };

            LayoutRoot.DataContext = m_persone;
        }
    }
}

   
