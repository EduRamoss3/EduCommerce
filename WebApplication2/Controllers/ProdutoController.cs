using Microsoft.AspNetCore.Mvc;
using WebApplication2.Enums;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProductService _produtos;
        private readonly ICategoriaService _categorias;
        public ProdutoController(IProductService produtos, ICategoriaService categorias)
        {
            _produtos = produtos;
            _categorias = categorias;   
        }
        [HttpGet]
        public IActionResult ProdutoDetalhe(int id)
        {
            var produto = _produtos.GetById(id);
            return View(produto);
        }
        public IActionResult ProdutosByCategoria(int idCategoria)
        {
            var prodCatg = _categorias.GetByCategoria(idCategoria);
            if(prodCatg is null)
            {
                ModelState.AddModelError("Erro", "Nenhum produto com essa categoria");
            }
            ProdutoViewModel produtoViewModel = new ProdutoViewModel()
            {
                Produtos = prodCatg
            };
            return View("~/Views/Home/Index.cshtml",produtoViewModel);
        }
        [HttpPost]
        public IActionResult CreateProductByAdm (Produto produto)
        {
           var existProd = _produtos.GetByName(produto.Nome);
           if(produto is not null && existProd is null)
            {
                if (ModelState.IsValid)
                {
                    _produtos.Create(produto);
                    return RedirectToAction("ProdutoDetalhe", "Produto", produto.IdProduto);
                }
                else
                {
                    ModelState.AddModelError("Verifique", "Dados incorretos, verifique todos os campos antes de cadastrar!");
                    return View();
                }
            }
            else
            {
                _produtos.PatchQnt(produto);
                TempData["UpdtQntProd"] = "Produto ja existente, a quantidade no estoque foi aumentada.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult CreateProductByAdm()
        {
            return View();
        }
    }
}
