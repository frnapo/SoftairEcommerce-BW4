using System.Collections.Generic;

namespace eCommerce_BuildWeek
{
    public class Prodotti
    {
        private int id;
        public int Id { get => id; set => id = value; }
        private string nome;
        public string Nome { get => nome; set => nome = value; }
        private string descrizione;
        public string Descrizione { get => descrizione; set => descrizione = value; }
        private double prezzo;
        public double Prezzo { get => prezzo; set => prezzo = value; }
        private int unita;
        public int Unita { get => unita; set => unita = value; }

        private int quantityInCart;
        public int QuantityInCart { get => quantityInCart; set => quantityInCart = value; }
        private string categoria;
        public string Categoria { get => categoria; set => categoria = value; }
        private string immagine;
        public string Immagine { get => immagine; set => immagine = value; }

        private static List<Prodotti> ListaProdotti = new List<Prodotti>();




        public static double CalcoloTotale(List<Prodotti> carrello)
        {
            double Totale = 0;
            foreach (Prodotti prodotto in carrello)
            {
                // Moltiplica il prezzo del prodotto per la sua quantità
                Totale += prodotto.Prezzo * prodotto.QuantityInCart;
            }
            return Totale;
        }

        public Prodotti(int id, string nome, string descrizione, double prezzo, int unita, string categoria, string immagine)
        {
            this.id = id;
            this.nome = nome;
            this.descrizione = descrizione;
            this.prezzo = prezzo;
            this.unita = unita;
            this.categoria = categoria;
            this.immagine = immagine;
        }


    }




}
