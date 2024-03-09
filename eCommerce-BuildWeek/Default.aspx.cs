using System;
using System.Data.SqlClient;
using System.Web.UI;


namespace eCommerce_BuildWeek
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Apre una connessione al database
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();

                // Ottiene il valore del parametro "categoria" dalla query string
                string categoria = Request.QueryString["categoria"];

                // Se il parametro "categoria" è nullo, esegue una query per selezionare tutti i prodotti
                if (categoria == null)
                {
                    string query = "SELECT * FROM Prodotti";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Imposta il risultato della query come sorgente dei dati per il controllo Repeater1
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    return;
                }

                // Se il parametro "categoria" non è nullo, esegue una query per selezionare i prodotti della categoria specificata
                if (categoria != null)
                {
                    string query = "SELECT * FROM Prodotti WHERE Categoria = @categoria";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Imposta il risultato della query come sorgente dei dati per il controllo Repeater1
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    return;
                }
            }
            catch (Exception ex)
            {
                // Gestisce eventuali eccezioni e mostra un messaggio di errore
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