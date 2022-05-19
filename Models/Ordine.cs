namespace WebApplication2.Models
{
    public class Ordine
    {

        public int Id_Customer { get; set; }
        public string Nome_Prodotto { get; set; }
        public float Prezzo { get; set; }
        
        public DateTime DataAcquisto { get; set; }

    }
}
