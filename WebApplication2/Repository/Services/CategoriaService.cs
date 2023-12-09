using WebApplication2.Context;
using WebApplication2.Enums;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Repository.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;
        public CategoriaService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IEnumerable<Categoria> GetAllCategorias()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Produto> GetByCategoria(int idCategoria)
        {
            return _context.Produtos.Where(t => t.IdCategoria == idCategoria).ToList();
        }
    }
}
