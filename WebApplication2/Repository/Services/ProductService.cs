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
        public async Task<bool> Any(int id)
        {
            var produto =  _context.Produtos.Any(p => p.IdProduto == id);
            return produto;
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

        public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
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

            return new NotFoundObjectResult("Produto não encontrado!");
        }

        public async Task<IActionResult> Update(Produto produto, int id)
        {
            var productExist = await _context.Produtos.FirstOrDefaultAsync(p => p.IdProduto == id);
            if (productExist is not null)
            {
                productExist.IdProduto = id;
                productExist.AVista = produto.AVista;
                productExist.DataEntrada = produto.DataEntrada;
                productExist.DescricaoCurta = produto.DescricaoCurta;
                productExist.IdCategoria = produto.IdCategoria;
                productExist.ImagemUrl = produto.ImagemUrl;
                productExist.AntigoPreco = produto.AntigoPreco;
                productExist.PrecoSecundario = produto.PrecoSecundario;
                productExist.Quantidade = produto.Quantidade;
                productExist.Nome = produto.Nome;
                productExist.Preco = produto.Preco;
                productExist.Tipos = produto.Tipos;
                
                _context.Produtos.Update(productExist);
                await _context.SaveChangesAsync();
                return new OkObjectResult(productExist);
            }

            else
            {
                return new BadRequestObjectResult(produto);
            }
        }


        public async Task<IEnumerable<Produto>> GetByName(string searchString)
        {
            var find = await GetAll();
            ActionResult<IEnumerable<Produto>> listNameLike = find;
            IEnumerable<Produto> listNameEmpty = Enumerable.Empty<Produto>();
            List<Produto> resultProd = new List<Produto>();
            foreach (Produto prod in listNameLike.Value)
            {
                if (Compare(searchString, prod.Nome))
                {
                    resultProd.Add(prod);
                }
            }
            if (resultProd is not null)
            {
                return resultProd;
            }
            return listNameEmpty;
        }
        public bool Compare(string search, string nameProd)
        {
            string[] wordsProdName = nameProd.Split(" ");  // todas as palavras do nome do produto em um vetor
            string[] compareStrings = search.Split(" "); // criação de um vetor para armazenar as palavras de pesquisa
            if (compareStrings.Length > 1) // se o vetor de pesquisa for maior que 1, ou seja, uma frase, então faremos a comparação:
            {
                for (int i = 1; i < wordsProdName.Length; i++)
                {
                    string wordConc = wordsProdName[i - 1].ToLower() + " " + wordsProdName[i].ToLower();
                    string compareConc = compareStrings[0].ToLower() + " " + compareStrings[1].ToLower();
                    if (wordConc == compareConc) // se as palavras formarem uma frase com pelo menos duas palavras, então, ele retorna esse produto
                    {
                        return true;
                    }
                }
            }
            foreach (string word in wordsProdName) // se for somente uma palavra, então ele faz a comparação:
            {
                foreach (string compareStrSearch in compareStrings)
                {
                    string wordProdLower = word.ToLower();
                    string wordSearchLower = compareStrSearch.ToLower();
                    if (wordProdLower == wordSearchLower) // se alguma  palavra que está no nome for igual a palavra que está na pesquisa, então retornará verdadeiro
                    {
                        return true;
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
            if (dbProd is not null)
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
