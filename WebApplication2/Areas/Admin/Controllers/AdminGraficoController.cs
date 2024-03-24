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
        [Route("{controller}/Index")]
        public IActionResult Index(int dias)
        {
            return View(dias);
        }
        [HttpGet]
        [Route("{controller}/VendasMensal")]
        public IActionResult VendasMensal()
        {
            return View();
        }
        [HttpGet]
        [Route("{controller}/VendasSemanal/")]
        public IActionResult VendasSemanal()
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
 