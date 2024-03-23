using EduCommerceWeb.Configuration.ConfigImages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EduCommerceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminImagensController(IWebHostEnvironment hostingEnvironment, IOptions<ConfigurationImagens> myConfiguration)
        {
            _myConfig = myConfiguration.Value;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        [Route("{controller}")]
        public IActionResult Index()
        {

            return View();
        }
    }
}
