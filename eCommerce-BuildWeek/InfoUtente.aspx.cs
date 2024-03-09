using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class InfoUtente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se la pagina è caricata per la prima volta
            if (!IsPostBack)
            {
                // Ottieni l'idUtente dalla query string
                int idUtente = Convert.ToInt32(Request.QueryString["utente"]);

                // Crea una connessione al database
                SqlConnection conn = Connection.ConnectionString();
                try
                {
                    conn.Open();

                    // Esegui una query per ottenere i dettagli dell'utente con l'id specificato
                    string query = $"SELECT * FROM Utenti WHERE idUtente = {idUtente}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Se esiste un record corrispondente, popola i campi di testo con i dati dell'utente
                    if (reader.Read())
                    {
                        Nome.Text = reader["Nome"].ToString();
                        Cognome.Text = reader["Cognome"].ToString();
                        Email.Text = reader["Email"].ToString();
                        Password.Text = reader["Password"].ToString();
                        Indirizzo.Text = reader["Indirizzo"].ToString();
                        Citta.Text = reader["Citta"].ToString();
                        Cap.Text = reader["Cap"].ToString();
                    }
                    else
                    {
                        // Se non esiste un record corrispondente, reindirizza alla pagina di default
                        Response.Redirect("Default.aspx");
                    }
                }
                catch (Exception ex)
                {
                    // Gestisci eventuali errori e visualizza un messaggio di errore
                    Response.Write("Error: ");
                    Response.Write(ex.Message);
                }
                finally
                {
                    // Chiudi la connessione al database
                    conn.Close();
                }

                // Crea una nuova connessione per ottenere i dettagli degli ordini dell'utente
                SqlConnection ordiniConnection = Connection.ConnectionString();
                try
                {
                    ordiniConnection.Open();

                    // Esegui una query per ottenere i dettagli degli ordini dell'utente
                    string query =
                        $"SELECT O.idOrdine, O.Indirizzo_Spedizione, O.Totale, COUNT(D.Quantita) AS Quantita FROM Ordini AS O JOIN DettagliOrdini AS D ON O.idOrdine = D.FK_IdOrdine JOIN Prodotti AS P ON D.FK_IdProdotto = P.idProdotto WHERE O.FK_IdUtente = {idUtente} GROUP BY O.idOrdine, O.Indirizzo_Spedizione, O.Totale ";
                    SqlCommand cmd = new SqlCommand(query, ordiniConnection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Imposta i dati degli ordini come sorgente per il controllo di visualizzazione dei dati
                    RiepilodoOrdiniRep.DataSource = reader;
                    RiepilodoOrdiniRep.DataBind();
                }
                catch (Exception ex)
                {
                    // Gestisci eventuali errori e visualizza un messaggio di errore
                    Response.Write("Errore: ");
                    Response.Write(ex.Message);
                }
                finally
                {
                    // Chiudi la connessione al database
                    ordiniConnection.Close();
                }
            }
        }

        protected void Modifica_Click(object sender, EventArgs e)
        {
            // Ottieni l'idUtente dalla query string
            string idUtente = Request.QueryString["utente"];

            // Crea una connessione al database
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();

                // Esegui una query per aggiornare i dati dell'utente con i valori dei campi di testo
                string query =
                    $"UPDATE Utenti SET Nome = '{Nome.Text}', Cognome = '{Cognome.Text}', Email = '{Email.Text}', Password = '{Password.Text}', Indirizzo = '{Indirizzo.Text}', Citta = '{Citta.Text}', Cap = '{Cap.Text}' WHERE idUtente = {idUtente}";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                // Cancella la sessione e reindirizza alla pagina di login
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                // Gestisci eventuali errori e visualizza un messaggio di errore
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
