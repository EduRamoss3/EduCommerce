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
        private readonly IUsuarioService _usuarioService;
        public CadastroController(UserManager<IdentityUser> userManager, IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
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
                var user = new IdentityUser()
                {
                    UserName = usuario.Nome,
                    NormalizedUserName = usuario.Nome.ToUpper(),
                    Email = usuario.Email,
                    NormalizedEmail = usuario.Email.ToUpper(),
                    PhoneNumber = usuario.Telefone

                };
            
            var result = await _userManager.CreateAsync(user, usuario.Senha);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Member");
                await _usuarioService.Add(usuario);
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.ToString());
            }
        }
            return View(usuario);

    }
}
}
