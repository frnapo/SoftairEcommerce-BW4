using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace eCommerce_BuildWeek
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se la pagina è caricata per la prima volta
            if (!IsPostBack)
            {
                // Recupera il carrello dalla sessione
                List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
                if (carrello != null && carrello.Count > 0)
                {
                    // Calcola il numero totale di articoli nel carrello
                    int numeroTotaleArticoli = carrello.Sum(p => p.QuantityInCart);
                    badge.Style.Add("display", "block");

                    // Mostra il numero totale di articoli nel carrello
                    carrelloCount.Text = numeroTotaleArticoli.ToString();
                }
                else
                {
                    badge.Style.Add("display", "none");
                }

                login.Style.Add("display", "flex");
                pannelloUtente.Style.Add("display", "none");
                backOffice.Style.Add("display", "none");

                // Recupera il nome e il flag isAdmin dalla sessione
                string nome = (string)Session["nome"];
                string isAdmin = (string)Session["isAdmin"];
                if (!string.IsNullOrEmpty(nome))
                {
                    string idUtente = (string)Session["idUtente"];
                    login.Style.Add("display", "none");
                    pannelloUtente.Style.Add("display", "flex");

                    // Imposta il nome dell'utente corrente
                    questoUtente.InnerHtml = nome;

                    // Imposta il link alla pagina InfoUtente con l'ID dell'utente corrente
                    questoUtente.HRef = "/InfoUtente.aspx?utente=" + idUtente;

                    if (isAdmin == "True")
                    {
                        backOffice.Style.Add("display", "block");
                    }
                }
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            // Cancella la sessione e reindirizza alla homepage
            Session.Clear();
            Response.Redirect("/");
        }
    }
}
