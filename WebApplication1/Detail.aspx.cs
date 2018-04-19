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
        public int Quantita{ get; set; }
        public Prodotto p;
        public List<Prodotto> prodotticar = new List<Prodotto>();
        protected void Page_Load(object sender,EventArgs e) {
            if(Session["prodotti"]!=null){
                prodotticar = Session["prodotti"] as List<Prodotto>;
            }
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

        protected void ControllaQuantita(Object oggetto, ServerValidateEventArgs args) {
            if (args.Value.Equals("3")) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
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
            if (Page.IsValid){
                p.Quantita = Convert.ToInt16(quantita.Text);
                prodotticar.Add(p);
                Session["prodotti"] = prodotticar;
                Response.Redirect(String.Format("~/Cart"));
            }
        }
    }
}