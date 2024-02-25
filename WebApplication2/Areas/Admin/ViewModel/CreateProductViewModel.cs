using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.ViewModel
{
    public class CreateProductViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public Pedido _Pedido { get; set; }
        public ItemCarrinho _itensCarrinho { get; set; }
    }
}
