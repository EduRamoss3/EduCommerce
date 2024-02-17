using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
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

        public async Task<IActionResult> Create(Produto produto)
        {
            if (produto is not null)
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return new OkObjectResult(produto);
            }
            else
            {
                return new BadRequestObjectResult(produto);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.IdProduto == id);
            if (produto is not null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return new OkObjectResult(produto);
            }
            else
            {
                return new BadRequestObjectResult(produto);
            }
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return produtos;
          
        }

        public async Task<ActionResult<Produto>> GetById(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.IdProduto == id);
            if (produto is not null)
            {
                return produto;
            }
            else
            {
                return new NotFoundObjectResult(produto);
            }
        }

        public async Task<IActionResult> Update(Produto produto)
        {
            if (produto is not null)
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
                return new OkObjectResult(produto);
            }
            else
            {
                return new BadRequestObjectResult(produto);
            }
        }
        
    
        public async Task<IEnumerable<Produto>>  GetByName(string[] searchString)
        {
            IEnumerable<Produto> listNameLike = await GetAll();
            List<Produto> resultProd = new List<Produto>();
            foreach(Produto prod in listNameLike)
            {
                if (Compare(searchString, prod.Nome))
                {
                    resultProd.Add(prod);                 
                }
            }
            if(resultProd is not null)
            {
                return resultProd;
            }
            
            string vectorToString = searchString[0];
            
            return listNameLike.Where(p => p.Nome == vectorToString).ToList();
        }
        public  bool Compare(string[] search, string nameProd)
        {
            string[] wordsProdName = nameProd.Split(" ");  // todas as palavras do nome do produto em um vetor
            string[] compareStrings = new string[search.Count()]; // criação de um vetor para armazenar as palavras de pesquisa

            foreach(string strSearch in search)
            {
              compareStrings = strSearch.Split(" "); //adicionando as palavras de pesquisa no vetor
            }
            if (compareStrings.Length > 1) // se o vetor de pesquisa for maior que 1, ou seja, uma frase, então faremos a comparação:
            {
                for (int i = 0; i < wordsProdName.Length - 1; i++)
                {
                    string wordConc = wordsProdName[i].ToLower() + " " + wordsProdName[i + 1].ToLower();
                    string compareConc = compareStrings[0].ToLower() + " " + compareStrings[1].ToLower();
                    if (wordConc == compareConc) // se as palavras formarem uma frase com pelo menos duas palavras, então, ele retorna esse produto
                    {
                        return true;
                    }
                    
                }
            }
            else
            {
                foreach (string word in wordsProdName) // se for somente uma palavra, então ele faz a comparação:
                {
                    string wordLower = word.ToLower();

                    foreach (string compareStrSearch in compareStrings)
                    {
                        if (wordLower == compareStrSearch) // se alguma  palavra que está no nome for igual a palavra que está na pesquisa, então retornará verdadeiro
                        {
                            return true;
                        }
                    }

                }
            }
            return false;

        }
        public async Task<IEnumerable<Produto>> GetByCategoria(int categoriaId)
        {
            var produto = await _context.Produtos.Where(p => p.IdCategoria == categoriaId).ToListAsync();
            return produto;
        }

        public async Task<IActionResult> PatchQnt(Produto produto)
        {
            var dbProd = await _context.Produtos.FirstOrDefaultAsync(p => p.IdProduto == produto.IdProduto);
            if(dbProd is not null)
            {
                dbProd.Quantidade++;
                _context.Produtos.Update(dbProd);
                await _context.SaveChangesAsync();
                return new OkObjectResult(produto);
            }
            else
            {
                return new NotFoundObjectResult(dbProd);
            }
        }
    }
}
