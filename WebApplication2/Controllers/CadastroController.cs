using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CadastroController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public CadastroController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = usuario.Nome };
                var result = await _userManager.CreateAsync(user, usuario.Senha);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Usuario");
                }
                else
                {
                    this.ModelState.AddModelError("", "Erro ao realizar o cadastro!");
                }
            }
            return View(usuario);

        }
    }
}
