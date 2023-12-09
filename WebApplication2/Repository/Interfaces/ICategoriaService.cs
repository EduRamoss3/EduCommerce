using WebApplication2.Enums;
using WebApplication2.Migrations;
using WebApplication2.Models;
using Categoria = WebApplication2.Models.Categoria;

namespace WebApplication2.Repository.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAllCategorias();
        IEnumerable<Produto> GetByCategoria(int id);
    }
}
