using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DataBinding
{
    public class CategoriaProdotto: INotifyPropertyChanged
    {
        private string m_nomeCategoria;
        private string m_icona;
        private ObservableCollection<Prodotto> m_prodotti;

        public string NomeCategoria
        {
            get
            {
                return m_nomeCategoria;
            }
            set
            {
                m_nomeCategoria = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NomeCategoria"));
            }
        }

        public ObservableCollection<Prodotto> Prodotti
        {
            get
            {
                if (m_prodotti == null)
                    m_prodotti = new ObservableCollection<Prodotto>();
                return m_prodotti;
            }
            set
            {
                m_prodotti = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Prodotti"));
            }
        }

        

        public string Icona
        {
            get
            {
                return m_icona;
            }
            set
            {
                m_icona = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Icona"));
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
