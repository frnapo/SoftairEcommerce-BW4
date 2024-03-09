using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class backOffice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Controlla se l'utente è un amministratore
            string isAdmin = (string)Session["isAdmin"];
            if (isAdmin != "True")
            {
                // Reindirizza l'utente alla pagina di default se non è un amministratore
                Response.Redirect("Default");
            }

            // Imposta la stringa di connessione al database
            Connection.ConnectionString();
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                // Imposta i dati del reader come sorgente dei dati per il repeater
                backOfficeRepeater.DataSource = reader;
                backOfficeRepeater.DataBind();
            }
            catch (Exception ex)
            {
                // Gestisce l'eccezione e mostra un messaggio di errore
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