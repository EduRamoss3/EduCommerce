using EduCommerceWeb.Areas.Admin.Services;
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
        [Route("grafico/index")]
        public IActionResult Index(int dias)
        {
            return View(dias);
        }

        [Route("grafico/vendas-mensais")]  
        public IActionResult VendasMensal()
        {
            return View();
        }
        [HttpGet]
        [Route("grafico/vendas-semanais")]
        public IActionResult VendasSemanal()
        {
            return View();
        }
        [HttpGet]
        [Route("grafico/json")]
        public JsonResult VendasProdutos(int dias)
        {
            var produtosVendasTotais = _graficoVendas.GetVendasProdutos(dias);
            return Json(produtosVendasTotais);
        }
    }
}
 