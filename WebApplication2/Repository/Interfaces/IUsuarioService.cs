using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interfaces
{
    public  interface IUsuarioService
    {
        Task<ActionResult<Usuario>> GetById(int id);
        Task<ActionResult<IEnumerable<Usuario>>> GetAll();  
        Task<IActionResult> DeleteById(int id);
        Task<IActionResult> Update(int id, Usuario usuario);
        Task<ActionResult<Usuario>> GetByUserToLogin(string user);
        Task<ActionResult<bool>> VerifyPassword(string password, Usuario usuario);
        Task<ActionResult> Add(Usuario usuario);
    }
}
