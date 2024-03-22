using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Authorize]
    
    public class PedidoController : Controller
    {
        private readonly Carrinho _carrinho;
        private readonly IPedidoService _pedidoService;
        UserManager<IdentityUser> _userMananger;
        public PedidoController(Carrinho carrinho, IPedidoService pedidoService, UserManager<IdentityUser> userMananger)
        {
            _carrinho = carrinho;
            _pedidoService = pedidoService;
            _userMananger = userMananger;
        }
        [HttpGet]
        public async Task<IActionResult> MeusPedidos(string user_id)
        {
            MeusPedidosViewModel pedidos = await _pedidoService.GetMeusPedidos(user_id);
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(Pedido pedido)
        {
            int totalItemsPedido = 0;
            double precoTotalPedido = 0.0;
            List<ItemCarrinho> itemCarrinhos = _carrinho.GetItemCarrinhos();
            _carrinho.ItensCarrinhos = itemCarrinhos;
            foreach(var item in itemCarrinhos)
            {
                totalItemsPedido += item.QntProduto;
                precoTotalPedido += item.QntProduto * item.Produto.Preco;
            }
            if (_carrinho.ItensCarrinhos.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, que tal incluir um pedido?");
            }
            pedido.TotalItensPedido = totalItemsPedido;
            pedido.TotalPedido = precoTotalPedido;
           
            if (ModelState.IsValid)
            {
                var user_id = _userMananger.GetUserId(User);
                pedido.Id_User = user_id;
                var result = await _pedidoService.CriarPedido(pedido, user_id);
                if (result is not null)
                {
                    ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido ;)";
                    ViewBag.TotalPedido = _carrinho.GetTotalCarrinho();
                    _carrinho.LimparCarrinho();
                    return View("~/Views/Pedido/Resumo.cshtml", pedido);
                    

                }
                else
                {
                    ModelState.AddModelError("Erro", "Erro ao realizar pedido!");
                    return View(pedido);
                }
            }
            else
            {
                ModelState.AddModelError("ErroDados", "Verifique todos os campos e tente novamente!");
                return View(pedido);
            }
        }
      
    }
}
