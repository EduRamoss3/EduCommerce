﻿using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using WebApplication2.Migrations;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly Carrinho _carrinhoCompra;
        private readonly IProductService _productService;
        public CarrinhoController(Carrinho carrinhoCompra, IProductService productService)
        {
            _carrinhoCompra = carrinhoCompra;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetItemCarrinhos();
            _carrinhoCompra.ItensCarrinhos = itens;
            var  carrinhoViewModel = new CarrinhoViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetTotalCarrinho()
            };
            return View(carrinhoViewModel);

        }
        public IActionResult AdicionarNoCarrinho(int Idproduto)
        {
            var produtoSelecionado = _productService.GetById(Idproduto);
            if(produtoSelecionado is not null)
            {
                _carrinhoCompra.AdicionarNoCarrinho(produtoSelecionado.Value);
               return RedirectToAction("Index");
            }
            else
            {
                return produtoSelecionado.Result;
            }
            
        }
        public IActionResult RemoverItemNoCarrinhoCompra(int Idproduto)
        {
            var produtoSelecionado = _productService.GetById(Idproduto);
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
        public IActionResult LimparCarrinho()
        {
            _carrinhoCompra.LimparCarrinho();
            return RedirectToAction("Index");
        }
    }
}
