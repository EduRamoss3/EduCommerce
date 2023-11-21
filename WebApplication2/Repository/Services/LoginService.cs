using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Repository.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;
        public LoginService(AppDbContext context)
        {
            _context = context;
        }
        public bool Cadastrar(Usuario usuario)
        {
            if (usuario is not null)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }
        public bool Deslogar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool RealizarLogin(string username, string password)
        {
            var possibleUser = _context.Usuarios.FirstOrDefault(u => u.Nome == username && u.Senha == password);
            if (possibleUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
