using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Repository.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<ActionResult> Add(Usuario usuario)
        {
            if(usuario is Usuario)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return new OkObjectResult($"Usuário{usuario.Nome} adicionado com sucesso!");
            }
            else
            {
                return new BadRequestObjectResult(usuario);
            }
        }
        public async Task<ActionResult<bool>> VerifyPassword(string password, Usuario usuario)
        {
            var verifyExist = await _context.Usuarios.FirstOrDefaultAsync(p => p.IdPessoa == usuario.IdPessoa);
            if(verifyExist is null) { return false; }
            return usuario.PasswordIsValid(password);
        }
        public async Task<ActionResult<Usuario>> GetByUserToLogin(string user)
        {
            var findUser = await _context.Usuarios.FirstOrDefaultAsync(p => p.Nome == user);
            if(findUser is null) { return new BadRequestObjectResult(this); }
            return findUser;
        }
        public async Task<IActionResult> DeleteById(int id)
        {
            var takeUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdPessoa == id);
            if(takeUser == null) { return new NotFoundObjectResult(this); }
            _context.Usuarios.Remove(takeUser);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deletado com sucesso!");
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var verifyExist = _context.Usuarios.FirstOrDefaultAsync(p => p.IdPessoa == id);
            if(verifyExist == null) { return new NotFoundObjectResult(this); }
            return await verifyExist;
        }

        public async Task<IActionResult> Update(int id, Usuario usuario)
        {

            var takeUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdPessoa == id);
            if(takeUser == null) { return new NotFoundObjectResult(this); }
            takeUser = usuario;
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
