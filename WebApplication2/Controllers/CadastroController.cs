using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [AllowAnonymous]
    public class CadastroController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioService _usuarioService;

        public CadastroController(UserManager<IdentityUser> userManager, IUsuarioService usuarioService)
        {

            _userManager = userManager;
            _usuarioService = usuarioService;
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
                    var id_User = user.Id;
                    usuario.Id_User = id_User;
                    await _usuarioService.Add(usuario);
                    return RedirectToAction("Login", "Account");
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
