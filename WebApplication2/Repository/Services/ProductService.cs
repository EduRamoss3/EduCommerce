using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Repository.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Create(Produto produto)
        {
            if (produto is not null)
            {
                _context.Produtos.Add(produto);
                _context.SaveChangesAsync();
                return new OkObjectResult(produto);
            }
            else
            {
                return new BadRequestObjectResult(produto);
            }
        }

        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
            if (produto is not null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChangesAsync();
                return new OkObjectResult(produto);
            }
            else
            {
                return new BadRequestObjectResult(produto);
            }
        }

        public IEnumerable<Produto> GetAll()
        {
            var produtos = _context.Produtos.ToList();
            return produtos;
          
        }

        public ActionResult<Produto> GetById(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
            if (produto is not null)
            {
                return produto;
            }
            else
            {
                return new NotFoundObjectResult(produto);
            }
        }

        public ActionResult Update(Produto produto)
        {
            if (produto is not null)
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return new OkObjectResult(produto);
            }
            else
            {
                return new BadRequestObjectResult(produto);
            }
        }
        public IEnumerable<Produto> GetByName(string searchString)
        {
            var produto = _context.Produtos.Where(p => p.Nome == searchString).ToList();
            return produto;
        }

        public IEnumerable<Produto> GetByCategoria(int categoriaId)
        {
            var produto = _context.Produtos.Where(p => p.IdCategoria == categoriaId).ToList();
            return produto;
        }

        public ActionResult PatchQnt(Produto produto)
        {
            var dbProd = _context.Produtos.FirstOrDefault(p => p.IdProduto == produto.IdProduto);
            if(dbProd is not null)
            {
                dbProd.Quantidade++;
                _context.Produtos.Update(dbProd);
                _context.SaveChanges();
                return new OkObjectResult(produto);
            }
            else
            {
                return new NotFoundObjectResult(dbProd);
            }
        }
    }
}
