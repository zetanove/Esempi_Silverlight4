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
using System.Collections.ObjectModel;

namespace DataBinding
{
    public partial class DataboundTreeView : UserControl
    {
        public DataboundTreeView()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<CategoriaProdotto> categorie = new ObservableCollection<CategoriaProdotto>();
            CategoriaProdotto catBevande = new CategoriaProdotto() { NomeCategoria = "Bevande", Icona = "Images/wine.png" };
            catBevande.Prodotti.Add(new Prodotto() { NomeProdotto = "Vino" });
            catBevande.Prodotti.Add(new Prodotto() { NomeProdotto = "Birra" });
            catBevande.Prodotti.Add(new Prodotto() { NomeProdotto = "Acqua" });

            CategoriaProdotto catPizze = new CategoriaProdotto() { NomeCategoria = "Pizze", Icona = "Images/pizza_slice.png" };
            catPizze.Prodotti.Add(new Prodotto() { NomeProdotto = "Margherita" });
            catPizze.Prodotti.Add(new Prodotto() { NomeProdotto = "4 Formaggi" });
            catPizze.Prodotti.Add(new Prodotto() { NomeProdotto = "Capricciosa" });

            categorie.Add(catBevande);
            categorie.Add(catPizze);
            LayoutRoot.DataContext = categorie;
        }
    }
}
