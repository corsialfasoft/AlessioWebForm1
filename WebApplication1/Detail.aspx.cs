using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1;

namespace WebApplication1 {
    public partial class _Detail : Page {
        public int codice{ get; set; }
        public string descrizione{ get; set; }
        public string Quantita{ get; set; }
        public Prodotto p;

        protected void Page_Load(object sender,EventArgs e) {
            try{
                p = CercaById(int.Parse(Request["codice"]));
                if(p != null) {
                    codice = p.Codice;
                    descrizione = p.Descrizione;
                }
            } catch(Exception) {
                p = null;
            }
        }

        private Prodotto CercaById(int codice) {
            DataBases db = new DataBases();
            foreach(Prodotto p in db.products) {
                if(p.Codice == codice) {
                    return p;
                }
            }
            return null;
        }

        protected void Add(object sender,EventArgs e) {

        }
    }
}