using EduCommerceWeb.Models.Graphs;
using WebApplication2.Context;

namespace EduCommerceWeb.Areas.Admin.Services
{
    
    public class GraficoVendasService
    {
        private readonly AppDbContext _context;
        public GraficoVendasService(AppDbContext context)
        {
            _context = context;
        }
        public List<GraficoProduto> GetVendasProdutos(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);
            var produtos = (from pd in _context.PedidoDetalhe
                            join l in _context.Produtos on pd.IdProduto equals l.IdProduto
                            where pd.Pedido.DataPedido >= data 
                            group pd by new {pd.IdProduto, l.Nome, pd.Quantidade} into g
                            select new
                            {
                                NomeProduto = g.Key.Nome,
                                QuantidadeProduto = g.Sum( q=> q.Quantidade),
                                ProdutosValorTotal =  g.Sum( a=> a.Preco)
                            });
            var lista = new List<GraficoProduto>();
            foreach(var item in produtos)
            {
                var produto = new GraficoProduto();
                produto.NomeProduto = item.NomeProduto;
                produto.QuantidadeProduto = item.QuantidadeProduto;
                produto.ProdutosValorTotal = item.ProdutosValorTotal;
                lista.Add(produto);
            }
            return lista;
        }
    }
    
}
