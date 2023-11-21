using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interfaces
{
    public interface ILoginService
    {
        bool RealizarLogin(string username, string password);
        bool Deslogar(Usuario usuario); 
        bool Cadastrar(Usuario usuario);    

    }
}
