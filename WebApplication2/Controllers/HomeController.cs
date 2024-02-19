using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _produtos;
        public HomeController(IProductService produtos)
        {
            _produtos = produtos;
        }

        public async Task<IActionResult> Index(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel.Produtos is null)
            {
                IEnumerable<Produto> produtos =  await _produtos.GetAll();
                ProdutoViewModel produtoViewModelPadrao = new ProdutoViewModel()
                {
                    Produtos = produtos
                };
                return View(produtoViewModelPadrao);
            }
            else
            {
                return View(produtoViewModel);
            }

        }
        [HttpGet]
        public async Task<IActionResult> SearchBy(string searchString)
        {
            IEnumerable<Produto> produtos;
            if (searchString is not null)
            {
                produtos = await _produtos.GetByName(searchString);
                if (produtos is null)
                {
                    ModelState.AddModelError("erroPesquisaNome", "Produto não encontrado!");

                    return RedirectToAction("Index", "Home");
                }
                ProdutoViewModel pVM = new ProdutoViewModel()
                {
                    Produtos = produtos
                };
                return View("~/Views/Produto/SearchProduto.cshtml", pVM);
            }
            return View(this);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}