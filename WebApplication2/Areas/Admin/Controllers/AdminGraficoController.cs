using EduCommerceWeb.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduCommerceWeb.Areas.Admin.Controllers
{
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasService _graficoVendas;
        public AdminGraficoController(GraficoVendasService graficoVendas)
        {
            _graficoVendas = graficoVendas;
        }
        [HttpGet]
        public IActionResult Index(int dias)
        {
            return View();
        }
        [HttpGet]
        public IActionResult VendasMensal(int dias)
        {
            return View();
        }
        [HttpGet]
        public IActionResult VendasSemanal(int dias)
        {
            return View();
        }
        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = _graficoVendas.GetVendasProdutos(dias);
            return Json(lanchesVendasTotais);
        }
    }
}
 