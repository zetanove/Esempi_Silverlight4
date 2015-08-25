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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookCommonLib
{
    public class Persona : INotifyPropertyChanged
    {
        private string m_nome;
        private string m_cognome;
        private DateTime m_dataNascita;
        private int m_eta;
        private bool m_isMaschio;
        private string m_urlImmagine;
        private string m_citta;

        [Display(Name = "Nome:", ShortName = "Nome", Description = "Nome della persona", Prompt = "Inserisci il nome")]
        public string Nome
        {
            get
            {
                return m_nome;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Il nome è obbligatorio.");
                }
                if (value.Trim().Length < 2)
                {
                    throw new Exception("Il nome è troppo breve.");
                }
                m_nome = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Nome"));
            }
        }

        [Display(Name = "Cognome:", ShortName = "Cognome", Description = "Cognome della persona", Prompt = "Inserisci il cognome")]
        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        public string Cognome
        {
            get
            {
                return m_cognome;
            }
            set
            {

                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Il cognome è obbligatorio.");
                }
                if (value.Trim().Length < 2)
                {
                    throw new Exception("Il cognome è troppo breve.");
                }
                m_cognome = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Cognome"));
            }
        }

        [Display(Name = "Città:")]
        public string Citta
        {
            get
            {
                return m_citta;
            }
            set
            {
                if (m_citta == value)
                    return;
                m_citta = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Citta"));
            }
        }

        [Display(Name = "Sesso maschile:", Description = "Se selezionato indica che la persona è di sesso maschile", ShortName = "Masch.")]
        public bool IsMaschio
        {
            get
            {
                return m_isMaschio;
            }
            set
            {
                if (m_isMaschio == value)
                    return;
                m_isMaschio = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsMaschio"));
            }
        }

        [Display(Name = "Data di nascita:", Description = "Data di nascita della persona", ShortName = "Data nasc.")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "La data di nascita è obbligatoria")]
        public DateTime DataNascita
        {
            get
            {
                return m_dataNascita;
            }
            set
            {
                m_dataNascita = value;
                if (Eta < 18)
                    throw new Exception("La persona deve essere maggiorenne");
                OnPropertyChanged(new PropertyChangedEventArgs("DataNascita"));
                //Eta = DateTime.Now.Year - m_dataNascita.Year;
                OnPropertyChanged(new PropertyChangedEventArgs("Eta"));

            }
        }

        [Display(Name = "Età (in anni:)", ShortName = "Età", Description = "L'età della persona espressa in anni")]
        public int Eta
        {
            get
            {
                m_eta = DateTime.Now.Year - m_dataNascita.Year;
                return m_eta;
            }
            //set
            //{
            //    m_eta = value;
            //    OnPropertyChanged(new PropertyChangedEventArgs("Eta"));
            //}
        }

        [Display(Name = "Foto:", ShortName = "Foto", Description = "La foto della persona")]
        public string UrlImmagine
        {
            get
            {
                return m_urlImmagine;
            }
            set
            {
                if (m_urlImmagine == value)
                    return;
                m_urlImmagine = value;
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
