using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using ReflectionIT.Mvc.Paging;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.Repository.Services;
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

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var list = _produtos.PaginationProduct();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                list = list.Where(p => p.Nome.Contains(filter));
            }
            var model = await PagingList.CreateAsync(list, 5, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> SearchBy(string searchString)
        {
            IEnumerable<Produto> produtos = new List<Produto>();
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
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}