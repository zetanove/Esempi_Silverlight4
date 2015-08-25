
namespace MyBusinessApplication.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
using MyBusinessApplication.Web.Models;
    using System.Data.SqlClient;
    using System.Data;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class ProdottoService : DomainService
    {
        

        public IEnumerable<Prodotto> GetProdotti()
        {
            List<Prodotto> prodotti = new List<Prodotto>();
            string cmdString = "Select *  from Prodotto";
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|SilverlightData.mdf;Integrated Security=True;User Instance=True")
                )
            {
                SqlCommand cmd = new SqlCommand(cmdString, conn);
                conn.Open();
                SqlDataReader sqlDataReader;
                sqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (sqlDataReader.Read())
                {
                    prodotti.Add(
                        new Prodotto() {
                            IDProdotto = (int)sqlDataReader["IDProdotto"], 
                            NomeProdotto = sqlDataReader["NomeProdotto"].ToString(), 
                            Prezzo = (decimal)sqlDataReader["Prezzo"],
                            Giacenza=(int)sqlDataReader["Giacenza"],
                            IDCategoria = (int)sqlDataReader["IDCategoria"]
                        }                            
                    );
                }
            }
            return prodotti;
            
        }

        public IEnumerable<Prodotto> GetProdottiCategoria(int idCategoria)
        {
            return GetProdotti().Where<Prodotto>(p=>p.IDCategoria== idCategoria);
        }

        [Query(IsComposable=false)]
        public Prodotto GetProdotto(int idProdotto)
        {
            return GetProdotti().First<Prodotto>(p => p.IDProdotto == idProdotto);
        }

        [Update]
        public void UpdateProdotto(Prodotto p)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|SilverlightData.mdf;Integrated Security=True;User Instance=True")
                )
            {
                string cmdString = "UPDATE Prodotto SET NomeProdotto=@NomeProdotto WHERE IDProdotto=@IDProdotto";
                SqlCommand cmd = new SqlCommand(cmdString, conn);
                cmd.Parameters.AddWithValue("@NomeProdotto", p.NomeProdotto);
                cmd.Parameters.AddWithValue("@IDProdotto", p.IDProdotto);
                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    
    }

 
}


