using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ILoginService _loginService;
        public CadastroController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid && usuario is not null)
            {
                var result =_loginService.Cadastrar(usuario);
                if (result)
                {
                    TempData["Sucesso"] = "Sucesso ao cadastrar!";
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                ModelState.AddModelError("Cadastro", "Falha ao realizar o cadastro");
            }
            return View(usuario);

        }
    }
}
