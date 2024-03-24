﻿using EduCommerceWeb.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduCommerceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService _graficoVendas;
        public AdminGraficoController(GraficoVendasService graficoVendas)
        {
            _graficoVendas = graficoVendas;
        }
        [HttpGet]
        [Route("{controller}/Index")]
        public IActionResult Index(int dias)
        {
            return View(dias);
        }
        [HttpGet]
        [Route("{controller}/VendasMensal/{dias}")]
        public IActionResult VendasMensal(int dias)
        {
            return View();
        }
        [HttpGet]
        [Route("{controller}/VendasSemanal/{dias}")]
        public IActionResult VendasSemanal(int dias)
        {
            return View();
        }
        [HttpGet]
        [Route("{controller}/VendasProdutos")]
        public JsonResult VendasProdutos(int dias)
        {
            var produtosVendasTotais = _graficoVendas.GetVendasProdutos(dias);
            return Json(produtosVendasTotais);
        }
    }
}
 