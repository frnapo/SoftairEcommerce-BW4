using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class Home : System.Web.UI.Page
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

                if (categoria != null)
                {
                    // Verifica il valore della categoria e imposta l'intestazione e il banner corrispondenti
                    switch (categoria.ToLower())
                    {
                        case "mitraglietta":
                            categoryHeading.InnerText = "Mitragliette";
                            categoryBanner.Src = "../Content/assets/banner-2.png";
                            break;
                        case "pistola":
                            categoryHeading.InnerText = "Pistole";
                            categoryBanner.Src = "../Content/assets/banner-3.png";
                            break;
                        case "fucile d'assalto":
                            categoryHeading.InnerText = "Fucili d'assalto";
                            categoryBanner.Src = "../Content/assets/banner-1.png";
                            break;
                        default:
                            categoryHeading.InnerText = "Nessun articolo disponibile per questa categoria";
                            break;
                    }
                }
                else
                {
                    // Imposta l'intestazione e il banner per la visualizzazione di tutti gli articoli
                    categoryHeading.InnerHtml = "Tutti gli <span class='orange-span'>articoli</span>";
                    categoryBanner.Src = "./Content/assets/banner-0.png";
                }

                if (categoria == null)
                {
                    // Esegue una query per selezionare tutti i prodotti
                    string query = "SELECT * FROM Prodotti";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Imposta i dati del reader come sorgente per il controllo Repeater1
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                }
                else
                {
                    // Esegue una query per selezionare i prodotti della categoria specificata
                    string query = "SELECT * FROM Prodotti WHERE Categoria = @categoria";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Imposta i dati del reader come sorgente per il controllo Repeater1
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Gestisce eventuali errori e visualizza un messaggio di errore
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