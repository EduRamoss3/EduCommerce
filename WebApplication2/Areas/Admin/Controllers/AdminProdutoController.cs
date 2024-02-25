using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.Admin.ViewModel;
using WebApplication2.Context;
using WebApplication2.Enums;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.Repository.Services;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    
    public class AdminProdutoController : Controller
    {
        private readonly IProductService _productService;
        public AdminProdutoController(IProductService productService)
        {
            _productService = productService;
        }

       
        [HttpGet]
        [Route("{controller}/Index")]
        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetAll();
           return View(list.Value);
        }

        [HttpGet]
        [Route("{controller}/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _productService.GetById(id);
            return View(produto);
        }

        [HttpGet]
        [Route("{controller}/Create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{controller}/Create")]
        public async Task<IActionResult> Create([Bind("IdProduto,Nome,Preco,DataEntrada,Tipos,Quantidade,ImagemUrl,DescricaoCurta,AntigoPreco,AVista,PrecoSecundario,MaxVezes,IdCategoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(produto);
                return RedirectToAction("Index");
                
            }
            return View(produto);
        }

        [HttpGet]
        [Route("{controller}/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {


            var produto = await _productService.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            
         
            return View(produto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{controller}/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduto,Nome,Preco,DataEntrada,Tipos,Quantidade,ImagemUrl,DescricaoCurta,AntigoPreco,AVista,PrecoSecundario,MaxVezes,IdCategoria")] Produto produto)
        {
            if (id != produto.IdProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.Update(produto, id);
                    RedirectToAction("AdminProduto", "Index");
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    new NotFoundObjectResult("Objeto não encontrado!");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [HttpGet]
        [Route("{controller}/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var produto = await _productService.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("{controller}/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _productService.GetById(id) == null)
            {
                return Problem("Entity set 'AppDbContext.Produtos'  is null.");
            }
            var produto = await _productService.GetById(id);
            if (produto != null)
            {
               await  _productService.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoExists(int id)
        {
            return await _productService.Any(id);
        }
    }
}
