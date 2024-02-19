using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ActionResult<IEnumerable<Produto>>> GetByCategoria(int idCategoria)
        {
            var list = await _context.Produtos.Where(p => p.IdCategoria == idCategoria).ToListAsync();
            if(list is not null)
            {
                return list;
            }
            return new NotFoundObjectResult("Sem categorias nesse id");
        }
    }
}
