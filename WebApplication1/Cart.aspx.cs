using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1;
using System.Data.SqlClient;

namespace WebApplication1 {
    public partial class _Cart : Page {
        public List<Prodotto> products { get; set; }
        protected void Page_Load(object sender,EventArgs e) {
            products = Session["prodotti"] as List<Prodotto>;
        }

        protected void Pulisci(object sender,EventArgs e) {
            products = new List<Prodotto>();
            Session["prodotti"] = null;
        }

        protected void AddRequest(object sender,EventArgs e) {
            DataBases db = new DataBases();
            SqlConnection connection = db.InitConnection();
            try {
				connection.Open();
                foreach(Prodotto p in Session["prodotti"] as List<Prodotto>){
				    SqlCommand command = new SqlCommand("dbo.AddRequest",connection);
				    command.CommandType=System.Data.CommandType.StoredProcedure;
				    command.Parameters.Add("@id",System.Data.SqlDbType.Int).Value=p.Codice;
                    command.Parameters.Add("@quantita",System.Data.SqlDbType.Int).Value=p.Quantita;
				    command.Dispose();
                }
			}catch (Exception p) {
				throw p; 
			} finally { 
			    connection.Dispose();
            }
        }
    }
}