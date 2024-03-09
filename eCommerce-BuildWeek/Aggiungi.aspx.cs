using System;
using System.Data.SqlClient;
using System.Globalization;

namespace eCommerce_BuildWeek
{
    public partial class Aggiungi : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            // Controlla se l'utente è un amministratore
            string isAdmin = (string)Session["isAdmin"];
            if (isAdmin != "True")
            {
                // Reindirizza l'utente alla pagina "Default" se non è un amministratore
                Response.Redirect("Default");
            }
        }

        // Gestisce l'evento di click sul pulsante "Aggiungi" e aggiunge un nuovo prodotto al database.
        protected void invioAggiungi_Click(object sender, EventArgs e)
        {
            // Ottiene la stringa di connessione al database
            Connection.ConnectionString();
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                // Apre la connessione al database
                conn.Open();

                // Prepara i dati da inserire nel database
                string prezzoText = Prezzo.Text.Replace(",", ".");
                // Converte la stringa del prezzo in un valore double e la formatta con il punto decimale
                double prezzo = double.Parse(prezzoText, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                // Crea la query di inserimento nel database e la formatta con i dati inseriti dall'utente
                string query = $"INSERT INTO Prodotti (Nome, Descrizione, Prezzo, Unita, Categoria, Immagine) VALUES ('{Nome.Text}', '{Descrizione.Text}', {prezzo.ToString(CultureInfo.InvariantCulture)}, {Convert.ToInt32(Unita.Text)}, '{Categoria.Text}', '{Immagine.Text}')";

                // Esegue la query di inserimento nel database
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                // Reindirizza l'utente alla pagina "backOffice"
                Response.Redirect("backOffice");
            }
            catch (Exception ex)
            {
                // Gestisce eventuali errori e visualizza un messaggio di errore sulla pagina
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
}