using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Nasconde l'elemento HTML con id "alert"
            alert.Style.Add("display", "none");
        }

        protected void Registrati_Click(object sender, EventArgs e)
        {
            // Apre una connessione al database
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                // Query per controllare se l'utente è già registrato
                string query = $"SELECT * FROM Utenti WHERE Email = '{TextEmail.Text}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Mostra l'elemento HTML con id "alert" e imposta il messaggio di errore
                    alert.Style.Add("display", "block");
                    alert.InnerHtml = "Utente già registrato";
                }
                else
                {
                    // Apre una seconda connessione al database
                    SqlConnection conn2 = Connection.ConnectionString();
                    try
                    {
                        conn2.Open();

                        // Controlla se i campi obbligatori sono stati compilati
                        if (
                            TextName.Text == ""
                            || TextName.Text == ""
                            || TextEmail.Text == ""
                            || TextPassword.Text == ""
                        )
                        {
                            // Mostra l'elemento HTML con id "alert" e imposta il messaggio di errore
                            alert.Style.Add("display", "block");
                            alert.InnerHtml =
                                "I seguenti campi sono obbligatori: Nome, Cognome, Email, Password";
                        }

                        // Query per inserire i dati dell'utente nel database
                        string query2 =
                            $"INSERT INTO Utenti(Nome, Cognome, Email, Password, Indirizzo, Citta, Cap) VALUES('{TextName.Text}', '{TextCognome.Text}', '{TextEmail.Text}', '{TextPassword.Text}', '{TextInirizzo.Text}', '{TextCittà.Text}', '{TextCap.Text}'); ";
                        SqlCommand cmd2 = new SqlCommand(query2, conn2);
                        cmd2.ExecuteNonQuery();
                        // Reindirizza l'utente alla pagina di login
                        Response.Redirect("Login.aspx");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: ");
                        Response.Write(ex.Message);
                    }
                    finally
                    {
                        // Chiude la seconda connessione al database e resetta i campi del form
                        conn2.Close();
                        TextCap.Text = string.Empty;
                        TextCittà.Text = string.Empty;
                        TextCognome.Text = string.Empty;
                        TextEmail.Text = string.Empty;
                        TextInirizzo.Text = string.Empty;
                        TextName.Text = string.Empty;
                        TextPassword.Text = string.Empty;
                    }
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
}
