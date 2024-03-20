using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Areas.Admin.ViewModel;
using WebApplication2.Context;
using WebApplication2.Migrations;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;
using PedidoDetalhe = WebApplication2.Models.PedidoDetalhe;

namespace WebApplication2.Repository.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;
        private readonly Carrinho _carrinho;
        private readonly IProductService _productService;
        public PedidoService(AppDbContext context, Carrinho carrinho, IProductService productService)
        {
            _context = context;
            _carrinho = carrinho;
            _productService = productService;   
        }
        public async Task<MeusPedidosViewModel> GetMeusPedidos(string user_id)
        {
            var meusPedidos = await _context.Pedidos.Where(p => p.Id_User == user_id).ToListAsync();

            foreach (Pedido pedido in meusPedidos)
            {
                // Criar uma nova lista de detalhes do pedido para cada pedido
                var pedidoDetalhes = DetalhePedidoList(pedido.IdPedido);
                pedido._PedidoDetalhes = pedidoDetalhes; // Definir a lista de detalhes do pedido para o pedido atual
            }

            MeusPedidosViewModel meusPedidosViewModel = new MeusPedidosViewModel()
            {
                Pedidos = meusPedidos
            };
            return meusPedidosViewModel;
        }

        public async Task<IEnumerable<Produto>> GetMeusProdutos(int cod_pedido)
        {
            var meuPedido = _context.Pedidos.FirstOrDefault(mp => mp.IdPedido == cod_pedido);
            string[] Ids = meuPedido.strPedidos.Split(',');
            List<Produto> ProdutosEmPedido = new();

            for (int i = 0; i < Ids.Length; i++)
            {
                int idGet = Convert.ToInt32(Ids[i]);
                var item = await _productService.GetById(idGet);
                ProdutosEmPedido.Add(item.Value);
            }

            return ProdutosEmPedido;
        }
        public async Task<ActionResult<IEnumerable<Pedido>>> GetAll()
        {
            var pedidos = await _context.Pedidos.ToListAsync();
            return pedidos;
        }
        public async Task<ActionResult<Pedido>> Delete(int id)
        {
            var pedido = await GetById(id);
            if (pedido is not null)
            {
                _context.Pedidos.Remove(pedido.Value);
                await _context.SaveChangesAsync();
                return new OkObjectResult("O pedido foi excluido com sucesso!");
            }
            return new NotFoundObjectResult("O pedido não foi encontrado!");
        }
        public async Task<ActionResult<Pedido>> GetById(int id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.IdPedido == id);
            if (pedido is not null)
            {
                return pedido;
            }
            else
            {
                return new NotFoundObjectResult($"O pedido não foi encontrado, verifique o ID:{id}");
            }
        }
        public async Task<ActionResult<Pedido>> Update(int id, Pedido pedido)
        {
            if (pedido is not null)
            {
                var pedidoExist = await _context.Pedidos.FirstOrDefaultAsync(p => p.IdPedido == id);
                if (pedidoExist is not null)
                {

                    pedidoExist.Nome = pedido.Nome;
                    pedidoExist.DataPedido = pedido.DataPedido;
                    pedidoExist.Rua = pedido.Rua;
                    pedidoExist.Numero = pedido.Numero;
                    pedidoExist.Telefone = pedido.Telefone;
                    pedidoExist.TotalItensPedido = pedido.TotalItensPedido;
                    pedidoExist.TotalPedido = pedido.TotalPedido;
                    pedidoExist.Entregue = pedido.Entregue;
                    pedidoExist.Concluido = pedido.Concluido;

                    _context.Pedidos.Update(pedidoExist);
                    await _context.SaveChangesAsync();

                    return new OkObjectResult($"O pedido ID:{pedido.IdPedido} foi atualizado com sucesso! Data de alteração:{DateTime.Now}");
                }
                return new NotFoundObjectResult("Pedido não encontrado!");
            }
            return new BadRequestObjectResult("O Pedido é nulo!");
        }
        public async Task<ActionResult> CriarPedido(Pedido pedido, string id_user)
        {
            if (pedido is not null)
            {
                await _context.Pedidos.AddAsync(pedido);
                await _context.SaveChangesAsync();
                var carrinhoItems = _carrinho.ItensCarrinhos;

                List<string> strList = new List<string>();
                string result = "";
                foreach (var produto in carrinhoItems)
                {
                    string produtoIdString = produto.Produto.IdProduto.ToString();
                    strList.Add(produtoIdString);
                }
                foreach (string produtoIdString in strList) // adicionando todos os ids em uma string, para futuramente usar split(",") e obter todos os ids
                {
                    result += produtoIdString + ",";
                }
                result = result.TrimEnd(',');
                pedido.Id_User = id_user;
                pedido.strPedidos = result;

                foreach (var item in carrinhoItems)
                {
                    
                    PedidoDetalhe pedidoDetalhe = new PedidoDetalhe
                    {
                        PedidoId = pedido.IdPedido,
                        IdProduto = item.Produto.IdProduto,
                        Quantidade = item.QntProduto,
                        Preco = (decimal)(item.Produto.Preco * item.QntProduto),
                        Produto = item.Produto,
                        strPedidos = result,
                       
                    };
                    _context.PedidoDetalhe.Add(pedidoDetalhe);
                }
                await _context.SaveChangesAsync();
                return new OkObjectResult("Pedido criado com sucesso!");
            }
            return new NotFoundObjectResult("O Pedido é nulo!");
        }

        public async Task<ActionResult> VerificarPedido(int id)
        {
            throw new NotImplementedException();
        }
        public List<PedidoDetalhe> DetalhePedidoList(int id)
        {
            var detalhe = _context.PedidoDetalhe.Where(p => p.PedidoId == id).ToList();
            
            return detalhe;
        }
        public PedidoDetalhe DetalhePedido(int id)
        {
            var detalhe = _context.PedidoDetalhe.FirstOrDefault(p => p.PedidoId == id);
            return detalhe;
        }
        public List<Produto> ProdutosPedido(int id)
        {
            var produtosPedido = _context.Produtos.Where(p => p.IdProduto == id).ToList();
            return produtosPedido;
        }
    }
}
