using System;
using System.Data.SqlClient;
using System.Globalization;

namespace eCommerce_BuildWeek
{
    public partial class Modifica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica se l'utente è un amministratore
                string isAdmin = (string)Session["isAdmin"];
                if (isAdmin != "True")
                {
                    // Reindirizza l'utente alla pagina di default se non è un amministratore
                    Response.Redirect("Default");
                }
                string idProdotto = Request.QueryString["ProdottoId"];
                if (idProdotto != null)
                {
                    // Apre la connessione al database
                    Connection.ConnectionString();
                    SqlConnection conn = Connection.ConnectionString();
                    try
                    {
                        conn.Open();
                        // Esegue una query per selezionare i dati del prodotto specificato
                        string query = $"SELECT * FROM Prodotti WHERE idProdotto = {idProdotto}";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // Popola i controlli della pagina con i dati del prodotto
                            codiceProdotto.InnerHtml = reader["idProdotto"].ToString();
                            img.ImageUrl = reader["Immagine"].ToString();
                            Nome.Text = reader["Nome"].ToString();
                            Descrizione.Text = reader["Descrizione"].ToString();
                            Prezzo.Text = reader["Prezzo"].ToString();
                            Unita.Text = reader["Unita"].ToString();
                            Categoria.Text = reader["Categoria"].ToString();
                            Immagine.Text = reader["Immagine"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Gestisce eventuali errori durante l'esecuzione della query
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

        protected void invioModifica_Click(object sender, EventArgs e)
        {
            // Apre la connessione al database
            Connection.ConnectionString();
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                // Prepara i dati per l'aggiornamento del prodotto
                string prezzoText = Prezzo.Text.Replace(',', '.');
                double prezzo = double.Parse(prezzoText, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                string query = $"UPDATE Prodotti SET Nome = '{Nome.Text}', Descrizione = '{Descrizione.Text}', Prezzo = {prezzo.ToString(CultureInfo.InvariantCulture)}, Unita = {Convert.ToInt32(Unita.Text)}, Categoria = '{Categoria.Text}', Immagine = '{Immagine.Text}' WHERE idProdotto = {Request.QueryString["ProdottoId"]}";
                SqlCommand cmd = new SqlCommand(query, conn);
                // Esegue l'aggiornamento del prodotto
                cmd.ExecuteNonQuery();
                // Reindirizza l'utente alla pagina di backOffice
                Response.Redirect("backOffice");
            }
            catch (Exception ex)
            {
                // Gestisce eventuali errori durante l'esecuzione dell'aggiornamento
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