using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class Dettagli : System.Web.UI.Page
    {
        // Metodo chiamato quando la pagina viene caricata
        protected void Page_Load(object sender, EventArgs e)
        {
            // Creazione della connessione al database
            SqlConnection conn = Connection.ConnectionString();

            try
            {
                conn.Open();
                if (!string.IsNullOrEmpty(Request.QueryString["IdProdotto"]))
                {
                    // Query per ottenere i dettagli del prodotto specificato
                    string query =
                        $"SELECT * FROM Prodotti WHERE idProdotto = {Convert.ToInt32(Request.QueryString["IdProdotto"])}";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Nascondi l'elemento HTML con id "alert"
                        alert.Style.Add("display", "none");
                        // Imposta l'attributo "src" dell'elemento HTML con id "Immagine" con il valore del campo "Immagine" del prodotto
                        Immagine.Src = reader["Immagine"].ToString();
                        // Imposta il contenuto dell'elemento HTML con id "Nome" con il valore del campo "Nome" del prodotto
                        Nome.InnerHtml = reader["Nome"].ToString();
                        // Imposta il contenuto dell'elemento HTML con id "Descrizione" con il valore del campo "Descrizione" del prodotto
                        Descrizione.InnerHtml = reader["Descrizione"].ToString();
                        // Imposta il contenuto dell'elemento HTML con id "Prezzo" con il valore del campo "Prezzo" del prodotto formattato come valuta
                        Prezzo.InnerHtml =
                            "€" + Convert.ToDouble(reader["Prezzo"]).ToString("0.00");

                        // Verifica la disponibilità del prodotto
                        if (Convert.ToInt32(reader["Unita"]) < 1)
                        {
                            // Se il prodotto non è disponibile, mostra il messaggio "Non disponibile" in rosso e disabilita i pulsanti "aggiungiCarrello" e "Quantità"
                            Disponibilita.InnerHtml = "Non disponibile";
                            Disponibilita.Style.Add("color", "red");
                            aggiungiCarrello.Enabled = false;
                            Quantità.Enabled = false;
                        }
                        else if ((Convert.ToInt32(reader["Unita"]) < 5))
                        {
                            // Se il prodotto è disponibile in quantità limitata, mostra il messaggio "Ultimi pezzi !" in arancione
                            Disponibilita.InnerHtml = "Ultimi pezzi !";
                            Disponibilita.Style.Add("color", "#CD8626");
                        }
                        else
                        {
                            // Se il prodotto è disponibile, mostra il messaggio "Disponibile" in verde
                            Disponibilita.InnerHtml = "Disponibile";
                            Disponibilita.Style.Add("color", "green");
                        }

                        // Imposta il contenuto dell'elemento HTML con id "Categoria" con il valore del campo "Categoria" del prodotto
                        Categoria.InnerHtml = reader["Categoria"].ToString();
                    }
                    else
                    {
                        // Se il prodotto non viene trovato, mostra il messaggio "Prodotto non trovato" nell'elemento HTML con id "alert"
                        alert.Style.Add("display", "block");
                        alert.InnerHtml = "Prodotto non trovato";
                    }

                    // Ottieni la categoria del prodotto
                    string categoria = reader["Categoria"].ToString();
                    // Query per ottenere prodotti simili alla stessa categoria, escludendo il prodotto corrente
                    string querySimili =
                        "SELECT * FROM Prodotti WHERE Categoria = @Categoria AND idProdotto != @IdProdotto";

                    SqlCommand cmdSimili = new SqlCommand(querySimili, conn);

                    cmdSimili.Parameters.AddWithValue("@Categoria", categoria);
                    cmdSimili.Parameters.AddWithValue(
                        "@IdProdotto",
                        Convert.ToInt32(Request.QueryString["IdProdotto"])
                    );
                    reader.Close();
                    SqlDataReader readerSimili = cmdSimili.ExecuteReader();
                    // Imposta il datasource del repeater "Repeater10" con i prodotti simili
                    Repeater10.DataSource = readerSimili;
                    Repeater10.DataBind();
                    readerSimili.Close();
                    // Se necessario, è possibile limitare i prodotti correlati a 3 utilizzando un ciclo for.
                }
                else
                {
                    // Se l'ID del prodotto non è specificato nella query string, reindirizza alla pagina "Default.aspx"
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                // In caso di errore, mostra il messaggio di errore
                Response.Write("Error: ");
                Response.Write(ex.Message);
            }
            finally
            {
                // Chiudi la connessione al database
                conn.Close();
            }
        }

        // Metodo chiamato quando viene cliccato il pulsante "aggiungiCarrello" serve per aggiungere un prodotto al carrello
        protected void aggiungiCarrello_Click(object sender, EventArgs e)
        {
            // Creazione della connessione al database
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["IdProdotto"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["IdProdotto"]);
                    conn.Open();
                    // Query per ottenere i dettagli del prodotto specificato
                    string query = $"SELECT * FROM Prodotti WHERE idProdotto = {id}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Ottieni l'immagine del prodotto selezionata dall'utente o utilizza l'immagine di default
                        string immagineSkin = Session["immagineProdotto"] != null ? Session["immagineProdotto"].ToString() : null;
                        string immagineProdotto = string.IsNullOrEmpty(Mimetica.SelectedValue) ? reader["Immagine"].ToString() : immagineSkin;

                        int quantità = Convert.ToInt32(Quantità.Text);

                        // Creazione dell'oggetto Prodotti con i dettagli del prodotto
                        Prodotti prodotto = new Prodotti(Convert.ToInt32(reader["idProdotto"]), reader["Nome"].ToString(), reader["Descrizione"].ToString(), Convert.ToDouble(reader["Prezzo"]), Convert.ToInt32(reader["Unita"]), reader["Categoria"].ToString(), immagineProdotto);
                        List<Prodotti> carrello;
                        if (Session["carrello"] == null)
                        {
                            // Se il carrello non esiste nella sessione, crea una nuova lista di Prodotti
                            carrello = new List<Prodotti>();
                        }
                        else
                        {
                            // Altrimenti, ottieni il carrello dalla sessione
                            carrello = (List<Prodotti>)Session["carrello"];
                        }

                        // Cerca il prodotto nel carrello
                        Prodotti prodottoEsistente = carrello.Find(p => p.Id == prodotto.Id && p.Immagine == prodotto.Immagine);
                        if (prodottoEsistente != null)
                        {
                            // Se il prodotto esiste nel carrello, aumenta la quantità
                            prodottoEsistente.QuantityInCart += quantità;
                        }
                        else
                        {
                            // Altrimenti, aggiungi il prodotto al carrello
                            prodotto.QuantityInCart = quantità;
                            carrello.Add(prodotto);
                        }

                        // Aggiorna il carrello nella sessione
                        Session["carrello"] = carrello;
                        // Reindirizza alla stessa pagina per aggiornare la visualizzazione
                        Response.Redirect(Request.RawUrl);
                    }
                }
                else
                {
                    // Se l'ID del prodotto non è specificato nella query string, mostra il messaggio "Prodotto non trovato"
                    Response.Write("Prodotto non trovato");
                }
            }
            catch (Exception ex)
            {
                // In caso di errore, mostra il messaggio di errore
                Response.Write("Error: ");
                Response.Write(ex.Message);
            }
            finally
            {
                // Chiudi la connessione al database
                conn.Close();
            }
        }

        // Metodo chiamato quando viene selezionata una nuova opzione nel dropdown "Mimetica"
        protected void Mimetica_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Creazione della connessione al database
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                if (!string.IsNullOrEmpty(Request.QueryString["IdProdotto"]))
                {
                    string valoreSelezionato = Mimetica.SelectedValue;
                    // Imposta il valore selezionato nella sessione come immagine del prodotto
                    Session["immagineProdotto"] = valoreSelezionato;

                    // Query per ottenere l'immagine del prodotto con il colore selezionato
                    string query =
                        $"SELECT * FROM ProdottiColori WHERE idProdotto = {Convert.ToInt32(Request.QueryString["IdProdotto"])} AND NomeColore = '{valoreSelezionato}'";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Imposta l'attributo "src" dell'elemento HTML con id "Immagine" con il percorso dell'immagine del prodotto
                        Immagine.Src = reader["PercorsoImmagine"].ToString();
                        string immagine = reader["PercorsoImmagine"].ToString();
                        // Imposta il valore dell'immagine del prodotto nella sessione
                        Session["immagineProdotto"] = immagine;
                    }
                    else
                    {
                        // Se il colore selezionato non è disponibile, mostra il messaggio "Colore non disponibile" nell'elemento HTML con id "alert"
                        alert.Style.Add("display", "block");
                        alert.InnerHtml = "Colore non disponibile";
                    }
                }
                else
                {
                    // Se l'ID del prodotto non è specificato nella query string, reindirizza alla pagina "Default.aspx"
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                // In caso di errore, mostra il messaggio di errore
                Response.Write("Error: ");
                Response.Write(ex.Message);
            }
            finally
            {
                // Chiudi la connessione al database
                conn.Close();
            }
        }
    }
}
