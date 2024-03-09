using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace eCommerce_BuildWeek
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se la pagina è caricata per la prima volta
            if (!IsPostBack)
            {
                // Recupera il carrello dalla sessione
                List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
                // Verifica se il carrello non è vuoto
                if (carrello != null && carrello.Count > 0)
                {
                    // Nasconde l'alert che indica che il carrello è vuoto
                    alert.Style.Add("display", "none");
                    // Imposta i dati del carrello nel Repeater
                    Repeater2.DataSource = carrello;
                    Repeater2.DataBind();
                    // Calcola il totale dei prodotti nel carrello
                    double totale = Prodotti.CalcoloTotale(carrello);
                    // Salva il totale nella sessione
                    Session["Totale"] = totale;
                    // Mostra il totale provvisorio nella pagina
                    contoTotale.InnerHtml = "Totale provvisorio: " + totale.ToString("0.00") + "€";

                    // Calcola il numero totale di articoli nel carrello
                    int numeroTotaleArticoli = carrello.Sum(p => p.QuantityInCart);
                    // Verifica se c'è almeno 1 prodotto nel carrello
                    if (carrello.Count >= 1)
                    {
                        procediOrdine.Visible = true;
                    }
                    // Aggiunge il numero totale di articoli al totale provvisorio
                    if (numeroTotaleArticoli > 1)
                    {
                        contoTotale.InnerHtml += " (" + numeroTotaleArticoli + " articoli)";
                    }
                    else
                    {
                        contoTotale.InnerHtml += " (" + numeroTotaleArticoli + " articolo)";
                    }
                }
                else
                {
                    // Mostra l'alert che indica che il carrello è vuoto
                    alert.Style.Add("display", "block");
                    alert.InnerHtml = "Nessun articolo nel carrello";
                }
            }
        }

        protected void rimuoviCarrello_Click(object sender, EventArgs e)
        {
            // Ottiene l'ID del prodotto da rimuovere dal carrello
            Button btn = (Button)sender;
            int rimuoviId = Convert.ToInt32(btn.CommandArgument);
            // Recupera il carrello dalla sessione
            List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
            // Trova il prodotto da rimuovere dal carrello
            Prodotti prodotto = carrello.Find(p => p.Id == rimuoviId);
            // Rimuove il prodotto dal carrello
            if (prodotto != null)
            {
                carrello.Remove(prodotto);
            }
            // Reindirizza alla stessa pagina per aggiornare il carrello
            Response.Redirect(Request.RawUrl);
        }

        protected void procediOrdine_Click(object sender, EventArgs e)
        {
            // Recupera il carrello dalla sessione
            List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
            // Recupera l'ID dell'utente dalla sessione
            int idUtente = Convert.ToInt32(Session["idUtente"]);
            // Crea una connessione al database
            SqlConnection conn = Connection.ConnectionString();

            // Controllo se l'utente è loggato per effettuare l'ordine
            if (Session["nome"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            // Verifica se l'utente è loggato e ha un ID valido
            if (idUtente != 0)
            {
                // Recupera l'indirizzo di spedizione e il totale dal carrello
                string indirizzo = Session["indirizzo"].ToString();
                decimal totale = Convert.ToDecimal(Session["Totale"]);
                try
                {
                    // Apre la connessione al database
                    conn.Open();
                    // Esegue la query per inserire l'ordine nel database
                    string query =
                        "Insert into Ordini (FK_IdUtente, Indirizzo_Spedizione, Totale) VALUES (@idUtente, @indirizzo, @totale)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idUtente", idUtente);
                    cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
                    cmd.Parameters.AddWithValue("@totale", totale);
                    cmd.ExecuteNonQuery();
                    // Crea una nuova connessione al database
                    SqlConnection conn2 = Connection.ConnectionString();
                    try
                    {
                        // Apre la connessione al database
                        conn2.Open();
                        // Esegue la query per recuperare l'ID dell'ordine appena inserito
                        string idOrdineQuery =
                            $"SELECT idOrdine FROM Ordini WHERE FK_IdUtente = {idUtente} ORDER BY idOrdine DESC";
                        SqlCommand getIdOrdineCmd = new SqlCommand(idOrdineQuery, conn2);
                        int idOrdine = (int)getIdOrdineCmd.ExecuteScalar();
                        // Itera attraverso i prodotti nel carrello
                        foreach (Prodotti prodotto in carrello)
                        {
                            // Recupera il percorso dell'immagine del prodotto dalla sessione
                            string immagineProdotto = Session["immagineProdotto"].ToString();
                            // Esegue la query per inserire i dettagli dell'ordine nel database
                            string query2 =
                                $"INSERT INTO DettagliOrdini (FK_IdOrdine, FK_IdProdotto, Quantita, PercorsoImmagine) VALUES ( {idOrdine}, {prodotto.Id}, {prodotto.QuantityInCart}, '{prodotto.Immagine}')";
                            SqlCommand cmd2 = new SqlCommand(query2, conn2);
                            cmd2.ExecuteNonQuery();

                            // Esegue la query per aggiornare la quantità del prodotto nel database
                            string query3 =
                                $"UPDATE Prodotti SET Unita = Unita - {prodotto.QuantityInCart} WHERE idProdotto = {prodotto.Id}";
                            SqlCommand cmd3 = new SqlCommand(query3, conn2);
                            cmd3.ExecuteNonQuery();
                        }
                        // Rimuove il carrello dalla sessione
                        Session.Remove("carrello");
                        // Reindirizza alla pagina delle informazioni utente
                        Response.Redirect("InfoUtente.aspx?utente=" + Session["idUtente"]);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: ");
                        Response.Write(ex.Message);
                    }
                    finally
                    {
                        // Chiude la connessione al database
                        conn2.Close();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: ");
                    Response.Write(ex.Message);
                }
                finally
                {
                    // Chiude la connessione al database
                    conn.Close();
                }
            }
        }

        protected void incrementaQuantita_Click(object sender, EventArgs e)
        {
            // Ottiene l'ID del prodotto da incrementare la quantità nel carrello
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            // Recupera il carrello dalla sessione
            List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
            // Trova il prodotto nel carrello
            Prodotti prodotto = carrello.Find(p => p.Id == idProdotto);
            // Incrementa la quantità del prodotto nel carrello
            if (prodotto != null)
            {
                prodotto.QuantityInCart++;
            }
            // Reindirizza alla stessa pagina per aggiornare il carrello
            Response.Redirect(Request.RawUrl);
        }

        protected void decrementaQuantita_Click(object sender, EventArgs e)
        {
            // Ottiene l'ID del prodotto da decrementare la quantità nel carrello
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);
            // Recupera il carrello dalla sessione
            List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
            // Trova il prodotto nel carrello
            Prodotti prodotto = carrello.Find(p => p.Id == idProdotto);
            // Decrementa la quantità del prodotto nel carrello
            if (prodotto != null && prodotto.QuantityInCart > 1)
            {
                prodotto.QuantityInCart--;
            }
            // Reindirizza alla stessa pagina per aggiornare il carrello
            Response.Redirect(Request.RawUrl);
        }
    }
}
