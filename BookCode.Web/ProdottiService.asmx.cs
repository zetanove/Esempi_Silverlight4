using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Data;

namespace BookCode.Web
{
    /// <summary>
    /// Summary description for ProdottiService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProdottiService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Prodotto> GetProdotti()
        {
            List<Prodotto> prodotti = new List<Prodotto>();
            const string cmdString = "Select NomeProdotto, NomeCategoria  from Prodotto Inner Join Categoria ON Prodotto.IDCategoria=Categoria.IDCategoria";
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
                        new Prodotto() { Nome = sqlDataReader["NomeProdotto"].ToString(), NomeCategoria = sqlDataReader["NomeCategoria"].ToString() }
                    );
                }
            }
            return prodotti;
        }
    }


    [DataContract]
    public class Prodotto
    {
        private string m_nome;
        private string m_nomeCategoria;

        [DataMember]
        public string Nome
        {
            get
            {
                return m_nome;
            }
            set
            {
                m_nome = value;
            }
        }

        [DataMember]
        public string NomeCategoria
        {
            get
            {
                return m_nomeCategoria;
            }
            set
            {
                m_nomeCategoria = value;
            }
        }
    }
}
