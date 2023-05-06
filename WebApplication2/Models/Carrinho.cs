namespace WebApplication2.Models
{
    public class Carrinho : Produto

    {
        public int QuantidadeProd { get; set; }

        public double PrecoFinal(double preco, int quantidade)

        {
            this.Preco = preco;
            this.QuantidadeProd = quantidade;
            return preco * quantidade;
        }
    }
}
