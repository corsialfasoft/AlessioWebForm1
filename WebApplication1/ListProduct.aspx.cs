using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1 {
    public partial class Prodotto {
        public int Codice {get; set;}
        public string Descrizione {get; set;}
        public int Quantita {get; set;}

        public Prodotto(int codice,string descrizione) {
            this.Codice = codice;
            this.Descrizione = descrizione;
        }
        public Prodotto(int codice,string descrizione,int Quantita) {
            this.Codice = codice;
            this.Descrizione = descrizione;
            this.Quantita = Quantita;
        }
    }
    public partial class DataBases {
        public List<Prodotto> products;

        public DataBases() {
            products = initLista();
        }

        private List<Prodotto> initLista() {
            return Reader<List<Prodotto>>(TakeProducts,$"SELECT ProdottiSet.Id,ProdottiSet.descrizione,ProdottiSet.quantita FROM ProdottiSet");
        }

        public SqlConnection InitConnection() {
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = @"(localdb)\MSSQLLocalDB";
			builder.InitialCatalog = "RICHIESTE";
			return new SqlConnection(builder.ConnectionString);
		}

        private void Procedura(string sql){
            SqlConnection connection = InitConnection();
			try {
				connection.Open();				
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			} catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
        }

        public delegate T Delelato<T>(SqlDataReader reader);
        public T Reader<T>(Delelato<T> metodo, string sql){
            SqlConnection con = InitConnection();
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                T ris = metodo(reader);
                reader.Dispose();
                cmd.Dispose();
                return ris;
            }
            catch(Exception e){
                throw e;
            }
            finally{
                con.Dispose();
            }
        }
        private List<Prodotto> TakeProducts(SqlDataReader reader) {
            try{
                List<Prodotto> prodotti = new List<Prodotto>();
                while (reader.Read()){
                    prodotti.Add(new Prodotto(reader.GetInt32(0),reader.GetString(1),(int)reader.GetSqlInt32(2)));
                }
                reader.Close();
                return prodotti;
            } catch(Exception e) {
                throw e;
            }
        }
    }
    public partial class _ListProduct : Page {
        public string wordSearch { get; set; }
        public List<Prodotto> products { get; set; }

        protected void Page_Load(object sender,EventArgs e) {
            wordSearch = Request["parola"];
            products = Cerca(wordSearch);
        }

        private List<Prodotto> Cerca(string wordSearch) {
            DataBases db = new DataBases();
            List<Prodotto> products = db.products;
            List<Prodotto> result = new List<Prodotto>();
            foreach(Prodotto p in products) {
                if(p.Descrizione.Contains(wordSearch)){
                    result.Add(p);
                }
            }
            return result;
        }
    }
}