using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Migrations;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class CarrinhoController : Controller
    {
        private readonly Carrinho _carrinhoCompra;
        private readonly IProductService _productService;
        private readonly UserManager<IdentityUser> _userManager;    
        public CarrinhoController(Carrinho carrinhoCompra, IProductService productService, UserManager<IdentityUser> userManager)
        {
            _carrinhoCompra = carrinhoCompra;
            _productService = productService;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetItemCarrinhos();
            _carrinhoCompra.ItensCarrinhos = itens;

            var carrinhoViewModel = new CarrinhoViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetTotalCarrinho(),
                IdUser = _userManager.GetUserId(User),
            };
            return View(carrinhoViewModel);

        }

        public async Task<IActionResult> AdicionarNoCarrinho(int Idproduto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var produtoSelecionado = await _productService.GetById(Idproduto);
                if (produtoSelecionado is not null)
                {
                     _carrinhoCompra.AdicionarNoCarrinho(produtoSelecionado.Value);
                    return RedirectToAction("Index","Carrinho");
                }
                else
                {
                    return Problem();
                }

            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
          
            
        }
        [Authorize]

        public async Task<IActionResult> RemoverItemNoCarrinhoCompra(int Idproduto)
        {
            var produtoSelecionado = await _productService.GetById(Idproduto);
            if(produtoSelecionado is not null)
            {
                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado.Value);
                return RedirectToAction("Index");
            }
            else
            {
                return produtoSelecionado.Result;
            }
        }
        [Authorize]

        public IActionResult LimparCarrinho()
        {
            _carrinhoCompra.LimparCarrinho();
            return RedirectToAction("Index");
        }
    }
}
