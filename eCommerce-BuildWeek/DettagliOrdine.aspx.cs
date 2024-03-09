using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class DettagliOrdine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupera il valore della variabile di sessione "nome"
            string nome = (string)Session["nome"];
            if (string.IsNullOrEmpty(nome))
            {
                // Se il valore è vuoto o nullo, reindirizza alla pagina "Default"
                Response.Redirect("Default");
            }

            // Crea una nuova connessione al database utilizzando la stringa di connessione definita nella classe "Connection"
            SqlConnection conn = Connection.ConnectionString();
            // Recupera il valore del parametro "ordineId" dalla query string
            string idOrdine = Request.QueryString["ordineId"];
            try
            {
                // Apre la connessione al database
                conn.Open();

                if (!string.IsNullOrEmpty(Request.QueryString["ordineId"]))
                {
                    // Costruisce la query per recuperare i dettagli dell'ordine specificato

                    string SingleOrdineQuery = $"SELECT D.FK_IdOrdine, D.FK_IdProdotto, D.Quantita, D.PercorsoImmagine,  P.Nome, P.Prezzo * D.Quantita AS TOTALE FROM DettagliOrdini AS D JOIN Prodotti AS P ON P.idProdotto = D.FK_IdProdotto WHERE D.FK_IdOrdine = {idOrdine}";

                    // Crea un nuovo oggetto SqlCommand per eseguire la query sul database
                    SqlCommand cmd = new SqlCommand(SingleOrdineQuery, conn);
                    // Esegue la query e recupera i risultati
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Imposta i risultati come sorgente dei dati per il controllo DettagliOrdiniRep
                    DettagliOrdiniRep.DataSource = reader;
                    // Associa i dati al controllo DettagliOrdiniRep
                    DettagliOrdiniRep.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Gestisce eventuali errori e visualizza un messaggio di errore
                Response.Write("Errore: ");
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
