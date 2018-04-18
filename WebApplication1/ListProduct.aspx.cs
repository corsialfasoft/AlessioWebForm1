using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1 {
    public partial class Prodotto {
        public int Codice {get; set;}
        public string Descrizione {get; set;}
        public int Quantita {get; set;}

        //Mok
        public Prodotto(int codice,string descrizione) {
            this.Codice = codice;
            this.Descrizione = descrizione;
        }
    }
    public partial class DataBases {
        public List<Prodotto> products;

        public DataBases() {
            products = initLista();
        }

        private List<Prodotto> initLista() {
            List<Prodotto> products = new List<Prodotto>();
            products.Add(new Prodotto(1,"ciao"));
            products.Add(new Prodotto(2,"pino"));
            products.Add(new Prodotto(3,"panino"));
            products.Add(new Prodotto(4,"elisabetta"));
            products.Add(new Prodotto(5,"cotoletta"));
            products.Add(new Prodotto(6,"verso"));
            products.Add(new Prodotto(7,"il"));
            products.Add(new Prodotto(8,"mare"));
            products.Add(new Prodotto(9,"blu"));
            products.Add(new Prodotto(10,"leggenda"));
            return products;
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