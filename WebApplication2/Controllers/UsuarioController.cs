using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILoginService _loginService;
        public UsuarioController(ILoginService loginService)
        {
            _loginService = loginService;
        }
   
        public IActionResult Login()
        {
            return View(new UsuarioViewModel());
        }
        [HttpPost]
        public IActionResult Login(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _loginService.RealizarLogin(usuarioViewModel.Usuario, usuarioViewModel.Senha);
                if (!result)
                {
                    ModelState.AddModelError("Erro", "Usuário ou senha incorretos");
                    return View(usuarioViewModel);
                }
                else
                {
                    HttpContext.Session.SetString("Usuario", usuarioViewModel.Usuario);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("ErroFormato", "Formato de dados incorretos!");
                return View(usuarioViewModel);
            }
            
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Deslogado com sucesso!";
            return RedirectToAction("Index","Home");
        }
    }
}
