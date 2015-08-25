using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyBusinessApplication.Web.Models
{
    public class Prodotto
    {
        [Key]
        [Editable(false)]
        [System.ServiceModel.DomainServices.Server.Ignore]
        public int IDProdotto { get; set; }

        [Display(Name = "Nome Prodotto", ShortName = "Nome Prod.", Description="Nome del prodotto", Order=1)]
        public string NomeProdotto { get; set; }

        [Display(Name = "Prezzo", Description="Prezzo unitario", Order=2)]
        public decimal Prezzo { get; set; }

        [Display(Name = "Giacenza", Description = "Giacenza di magazzino", Order=3)]
        public int Giacenza { get; set; }

        [Display(AutoGenerateField=false)]
        public int IDCategoria {get;set;}
        
    }
}