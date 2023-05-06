namespace WebApplication2.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public double Preco { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Tipo { get; set; }
    }
}

