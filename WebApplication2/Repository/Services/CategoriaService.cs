using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
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
        public string GetNomeCategoriaById(int id)
        {
            try
            {
                var categoriaNome = _context.Categorias.FirstOrDefault(p => p.IdCategoria == id);
                return categoriaNome.CategoriaNome;
            }
            catch(NullReferenceException)
            {
                return "Categoria não foi encontrada";
            }
            catch (ArgumentNullException)
            {
                return "Categoria não foi encontrada";
            }
           
        }
        public IEnumerable<Categoria> GetAllCategorias()
        {
            try
            {
                return _context.Categorias.ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<Categoria>();   
            }
        
        }

        public async Task<ActionResult<IEnumerable<Produto>>> GetByCategoria(int idCategoria)
        {
            try
            {
                var list = await _context.Produtos.Where(p => p.IdCategoria == idCategoria).ToListAsync();
                if (list is not null)
                {
                    return list;
                }
                return new NotFoundObjectResult("Sem categorias nesse id");
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("Erro ao carregar a lista de produtos");
            }
            
        }
        public IQueryable<Categoria> PaginationCategoria()
        {
            var ctg = _context.Categorias.AsNoTracking().AsQueryable();
            return ctg;
        }
    }
}
