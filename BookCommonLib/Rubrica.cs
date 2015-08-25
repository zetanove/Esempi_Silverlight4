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
using System.Collections.ObjectModel;

namespace BookCommonLib
{
    public class Rubrica
    {
        public static ObservableCollection<Persona> Contatti
        {
            get
            {
                ObservableCollection<Persona> persone = new ObservableCollection<Persona>();
                persone.Add(new Persona() { Nome = "Antonio", Cognome = "Pelleriti", Citta = "New York" });
                persone.Add(new Persona() { Nome = "Bill", Cognome = "Gates", Citta = "Redmond" });
                persone.Add(new Persona() { Nome = "Larry", Cognome = "Page", Citta = "SAn Antonio" });
                persone.Add(new Persona() { Nome = "Zlatan", Cognome = "Ibrahimovic", Citta = "Milano" });
                persone.Add(new Persona() { Nome = "Nelson", Cognome = "Mandela", Citta = "Città del Capo" });
                return persone;
            }
        }
    }
}
