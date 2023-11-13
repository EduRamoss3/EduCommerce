using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProductService _produtos;
        public ProdutoController(IProductService produtos)
        {
            _produtos = produtos;
        }
        [HttpGet]
        [Route("{controller}/{id}")]
        public IActionResult Produto(int id)
        {
            var produto = _produtos.GetById(id);
            return View(produto);
        }


    }
}
