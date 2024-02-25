using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.Admin.ViewModel;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPedidosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPedidoService _pedidoService;
        private readonly IProductService _productService;

        public AdminPedidosController(AppDbContext context, IPedidoService pedidoService, IProductService productService)
        {
            _context = context;
            _pedidoService = pedidoService;
            _productService = productService;
        }

        [HttpGet]
        [Route("{controller}")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pedidos.ToListAsync());
        }

        [HttpGet]
        [Route("{controller}/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            List<int> Idprodutos = new List<int>();
            List<Produto> AllProd = new List<Produto>();
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }
            
            var pedidoDetalhe = _pedidoService.DetalhePedido(pedido.IdPedido);
            string[] idsPedido = pedidoDetalhe.strPedidos.Split(",");
            foreach(string idProd in idsPedido)
            {
                Idprodutos.Add(Convert.ToInt32(idProd));

            }
            foreach(int idProd in Idprodutos)
            {
                var item = await _productService.GetById(idProd);
                AllProd.Add(item.Value);
            }
            PedidoViewModel pedidoViewModel = new PedidoViewModel()
            {
                _Pedido = pedido,
                _PedidoDetalhe = pedidoDetalhe,
                _ProdutosPedido = AllProd,
            };

            return View(pedidoViewModel);
        }

        [HttpGet]
        [Route("{controller}/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{controller}/Create/{id}")]
        public async Task<IActionResult> Create([Bind("IdPedido,Nome,DataPedido,Rua,Numero,Telefone,TotalItensPedido,TotalPedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        [HttpGet]
        [Route("{controller}/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{controller}/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,Nome,DataPedido,Rua,Numero,Telefone,TotalItensPedido,TotalPedido")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        [HttpGet]
        [Route("{controller}/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("~/Admin/AdminPedidos/DeleteConfirmed/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'AppDbContext.Pedidos'  is null.");
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return _context.Pedidos.Any(e => e.IdPedido == id);
        }
    }
}
