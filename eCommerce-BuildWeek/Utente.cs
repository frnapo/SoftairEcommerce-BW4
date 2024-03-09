using System.Collections.Generic;

namespace eCommerce_BuildWeek
{
    public class Utente
    {
        private int id;
        public int Id { get => id; set => id = value; }
        private string nome;
        public string Nome { get => nome; set => nome = value; }
        private string cognome;
        public string Cognome { get => cognome; set => cognome = value; }
        private string email;
        public string Email { get => email; set => email = value; }
        private string password;
        public string Password { get => password; set => password = value; }
        private string indirizzo;
        public string Indirizzo { get => indirizzo; set => indirizzo = value; }
        private string citta;
        public string Citta { get => citta; set => citta = value; }
        private string cap;
        public string Cap { get => cap; set => cap = value; }
        private bool isAdmin = false;
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public List<Utente> listaUtenti = new List<Utente>();

        public Utente(string nome, string cognome, string email, string password, string indirizzo, string citta, string cap, bool isAdmin)
        {

            this.nome = nome;
            this.cognome = cognome;
            this.email = email;
            this.password = password;
            this.indirizzo = indirizzo;
            this.citta = citta;
            this.cap = cap;
            this.isAdmin = isAdmin;
        }






    }
}