using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1;

namespace WebApplication1 {
    public partial class _Cart : Page {
        public List<Prodotto> products { get; set; }
        protected void Page_Load(object sender,EventArgs e) {
            products = new List<Prodotto>();
            products.Add(new Prodotto(1,"pino"));
            products.Add(new Prodotto(2,"panino"));
            products.Add(new Prodotto(3,"ciao"));
        }

        protected void Pulisci(object sender,EventArgs e) {
            products = new List<Prodotto>();
        }
    }
}