using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se la pagina è stata caricata tramite un postback
            if (IsPostBack)
            {
                pwError.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Crea una nuova connessione al database utilizzando la stringa di connessione definita nella classe Connection
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                // Apre la connessione al database
                conn.Open();

                // Crea una query SQL per selezionare un utente con l'email e la password specificate
                string query = $"SELECT * FROM Utenti WHERE Email = '{TextEmail.Text}' AND Password = '{TextPassword.Text}'";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Esegue la query e ottiene un oggetto SqlDataReader per leggere i risultati
                SqlDataReader reader = cmd.ExecuteReader();

                // Se viene trovato un utente corrispondente
                if (reader.Read())
                {
                    // Imposta le variabili di sessione con i dati dell'utente
                    Session["indirizzo"] = reader["Indirizzo"].ToString();
                    Session["idUtente"] = reader["idUtente"].ToString();
                    Session["email"] = reader["Email"].ToString();
                    Session["password"] = reader["Password"].ToString();
                    Session["nome"] = reader["Nome"].ToString();
                    Session["isAdmin"] = reader["Admin"].ToString();

                    // Reindirizza l'utente alla pagina predefinita
                    Response.Redirect("Default");
                }
                else
                {
                    // Se la password non è stata inserita, mostra un messaggio di errore
                    if (!string.IsNullOrEmpty(TextPassword.Text))
                    {
                        lblRegistrati1.Visible = true;
                        LinkButton1.Visible = true;
                    }
                    else
                    {
                        // Altrimenti, mostra un messaggio di errore per la password
                        pwError.Visible = true;
                    }
                }
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