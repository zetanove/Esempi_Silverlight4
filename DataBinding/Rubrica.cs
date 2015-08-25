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
using System.Collections;
using System.Collections.ObjectModel;

namespace DataBinding
{
    public class Rubrica
    {
        public static ObservableCollection<Persona> Contatti
        {
            get
            {
                ObservableCollection<Persona> persone = new ObservableCollection<Persona>();
                persone.Add(new Persona() { Nome = "Antonio", Cognome = "Pelleriti", IsMaschio=true, DataNascita = new DateTime(1975, 04, 18) });
                persone.Add(new Persona() { Nome = "Caterina", Cognome = "Marguccio", DataNascita = new DateTime(1981, 11, 25) });
                return persone;
            }
        }
    }
}
