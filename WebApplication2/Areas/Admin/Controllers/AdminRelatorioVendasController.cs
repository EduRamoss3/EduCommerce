using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Areas.Admin.Services;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        
        private readonly RelatorioVendasService _relatorioVendasService;
        public AdminRelatorioVendasController(RelatorioVendasService relatorioVendasService)
        {
            _relatorioVendasService = relatorioVendasService;
        }
        [HttpGet]
        [Route("{controller}/Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("{controller}/RelatorioVendasSimples")]
        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = minDate.Value.ToString("yyyy-MM-dd");
            var result = await _relatorioVendasService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
    }
}
