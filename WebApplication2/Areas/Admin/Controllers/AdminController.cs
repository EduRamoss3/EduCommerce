using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
