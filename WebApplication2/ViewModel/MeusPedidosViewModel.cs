using WebApplication2.Models;

namespace WebApplication2.ViewModel
{
    public class MeusPedidosViewModel
    {
        public IEnumerable<Pedido> Pedidos { get; set; }
        public IEnumerable<Produto> ProdutosPedido { get; set; }
    }
}
