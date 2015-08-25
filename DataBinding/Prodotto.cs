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
using System.ComponentModel.DataAnnotations;

namespace DataBinding
{
    public class Prodotto: INotifyPropertyChanged
    {
        private string m_nomeProdotto;

        [Display()]
        public string NomeProdotto
        {
            get
            {
                return m_nomeProdotto;
            }
            set
            {
                m_nomeProdotto = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NomeProdotto"));
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
