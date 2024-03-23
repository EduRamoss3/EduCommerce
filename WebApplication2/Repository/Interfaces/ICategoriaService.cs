using Microsoft.AspNetCore.Mvc;
using WebApplication2.Migrations;
using WebApplication2.Models;
using Categoria = WebApplication2.Models.Categoria;

namespace WebApplication2.Repository.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAllCategorias();
        Task<ActionResult<IEnumerable<Produto>>> GetByCategoria(int id);
        IQueryable<Categoria> PaginationCategoria();
        string GetNomeCategoriaById(int id);
    }
}
