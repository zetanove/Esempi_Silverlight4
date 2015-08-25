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

namespace DataBinding
{
    public class Magazzino
    {
        private  static ObservableCollection<CategoriaProdotto> m_categorie;
        static Magazzino()
        {
            m_categorie = new ObservableCollection<CategoriaProdotto>();
            CategoriaProdotto catBevande = new CategoriaProdotto() { NomeCategoria = "Bevande", Icona = "Images/wine.png" };
            catBevande.Prodotti.Add(new Prodotto(){NomeProdotto="Vino"});
            catBevande.Prodotti.Add(new Prodotto() { NomeProdotto = "Birra" });
            catBevande.Prodotti.Add(new Prodotto() { NomeProdotto = "Acqua" });

            CategoriaProdotto catPizze = new CategoriaProdotto() { NomeCategoria = "Pizze", Icona = "Images/pizza_slice.png" };
            catPizze.Prodotti.Add(new Prodotto() { NomeProdotto = "Margherita" });
            catPizze.Prodotti.Add(new Prodotto() { NomeProdotto = "4 Formaggi" });
            catPizze.Prodotti.Add(new Prodotto() { NomeProdotto = "Capricciosa" });

            m_categorie.Add(catBevande);
            m_categorie.Add(catPizze);
        }

        public static ObservableCollection<CategoriaProdotto> ElencoCategorie
        {
            get
            {
                return m_categorie;
            }
        }
    }

}
