using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            TempData["HttpContext"] = HttpContext;
            if(HttpContext.Session is not null)
            {
                TempData["Usuario"] = HttpContext.Session.GetString("Usuario");
            }
            
            IEnumerable<Produto> produtos = _produtos.GetAll();
            ProdutoViewModel pVM = new ProdutoViewModel()
            {
                Produtos = produtos
            };
            return View(pVM);
        }
        [HttpGet]
        [Route("{controller}/Search")]
        public IActionResult SearchBy(string searchString)
        {
            IEnumerable<Produto> produtos;
            if(!string.IsNullOrEmpty(searchString))
            {
                produtos = _produtos.GetByName(searchString);
                if(produtos is null)
                {
                    return new NotFoundObjectResult("Produto não encontrado!");
                }
                ProdutoViewModel pVM = new ProdutoViewModel()
                {
                    Produtos = produtos
                };
                return View("~/Views/Produto/SearchProduto.cshtml", pVM);
            }

            else
            {
                return new NotFoundObjectResult(searchString);
            }
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}