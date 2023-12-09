using WebApplication2.Context;
using WebApplication2.Migrations;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Repository.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;
        private readonly Carrinho _carrinho;
        public PedidoService(AppDbContext context, Carrinho carrinho)
        {
            _context = context;
            _carrinho = carrinho;
        }

        public bool CriarPedido(Pedido pedido)
        {
            if (pedido is not null)
            {
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
                var carrinhoItems = _carrinho.ItensCarrinhos;
                foreach (var item in carrinhoItems)
                {
                    Models.PedidoDetalhe pedidoDetalhe = new Models.PedidoDetalhe
                    {
                        PedidoId = pedido.IdPedido,
                        IdProduto = item.Produto.IdProduto,
                        Quantidade = item.QntProduto,
                        Preco = (decimal)(item.Produto.Preco * item.QntProduto),
                        Produto = item.Produto
                    };
                   _context.PedidoDetalhe.Add(pedidoDetalhe);
                }
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Pedido VerificarPedido(int id)
        {
            throw new NotImplementedException();
        }
    }
}
