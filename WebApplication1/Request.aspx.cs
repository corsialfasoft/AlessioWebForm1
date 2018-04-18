using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {
    public partial class _Request : Page {
        public int IdDaCercare;
        public string ParolaCercare;
        public List<Prodotto> products;
        protected void Page_Load(object sender,EventArgs e) {
        }
        protected void Cerca(object sender,EventArgs e) {
            if (!String.IsNullOrEmpty(id.Text)) {
                Response.Redirect($"~/Detail.aspx?codice={id.Text}");
            } else if (!String.IsNullOrEmpty(descr.Text)) {
                DataBases db = new DataBases();
                foreach (var p in CercaProducts(descr.Text)) {
                    TableRow tr = new TableRow();
                    TableCell codice = new TableCell();
                    codice.Controls.Add(new Label() { Text = p.Codice.ToString(),CssClass="col-xs-2" });
                    tr.Cells.Add(codice);
                    TableCell descri = new TableCell();
                    descri.Controls.Add(new Label() { Text = p.Descrizione ,CssClass="col-xs-6" });
                    tr.Cells.Add(descri);
                    TableCell qnt = new TableCell();
                    qnt.Controls.Add(new Label() { Text = p.Quantita.ToString(),CssClass="col-xs-2" });
                    tr.Cells.Add(qnt);
                    TableCell but = new TableCell();
                    but.Controls.Add(new Button() { Text = "Dettaglio", PostBackUrl = $"Detail?codice={p.Codice}", CssClass="col-xs-2"});
                    tr.Cells.Add(but);
                    Table1.Rows.Add(tr);
                }
            }
        }
        private List<Prodotto> CercaProducts(string wordSearch) {
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