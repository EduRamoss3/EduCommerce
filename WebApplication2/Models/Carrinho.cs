using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using WebApplication2.Context;

namespace WebApplication2.Models
{
    public class Carrinho
    {
        private readonly AppDbContext _context;
        public Carrinho(AppDbContext context)
        {
            _context = context;
        }
        [Key]
        public string IdCarrinho { get; set; }
        public List<ItemCarrinho> ItensCarrinhos { get; set; }
        public int QuantidadeTotal { get; set; }
        public static Carrinho GetCarrinho(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string carrinhoId = session.GetString("IdCarrinho") ?? Guid.NewGuid().ToString();
            session.SetString("IdCarrinho", carrinhoId);
            return new Carrinho(context)
            {
                IdCarrinho = carrinhoId,
            };

        }
        public void AdicionarNoCarrinho(Produto produto)
        {
            var itemCarrinho = _context.ItemCarrinhos.SingleOrDefault(p => p.Produto.IdProduto == produto.IdProduto
            && p.IdCarrinho == IdCarrinho);
            if (itemCarrinho is not null)
            {
                itemCarrinho.QntProduto++;
                _context.SaveChanges();
            }
            else
            {
              
                ItemCarrinho itemCompras = new ItemCarrinho()
                {
                    IdItensCarrinho = Guid.NewGuid().ToString(),
                    Produto = produto,
                    QntProduto = 1,
                    IdCarrinho = IdCarrinho

                };
                _context.ItemCarrinhos.Add(itemCompras);
                _context.SaveChanges();
            }
           
        }
        public int GetTotalItens()
        {
            int total = 0;
            foreach(ItemCarrinho i in ItensCarrinhos)
            {
                total += i.QntProduto;
            }
            return total;
        }
        public List<ItemCarrinho> GetItemCarrinhos()
        {
            return ItensCarrinhos ??= _context.ItemCarrinhos
                .Where(p => p.IdCarrinho == IdCarrinho)
                .Include(p => p.Produto)
                .ToList();

        }
        public void RemoverDoCarrinho(Produto produto)
        {
            var itemCarrinho = _context.ItemCarrinhos.SingleOrDefault(p => p.Produto.IdProduto == produto.IdProduto && p.IdCarrinho == IdCarrinho);
            if (itemCarrinho is not null && itemCarrinho.QntProduto > 1)
            {
                itemCarrinho.QntProduto--;
            }
            else if (itemCarrinho.QntProduto == 0)
            {
                _context.ItemCarrinhos.Remove(itemCarrinho);
            }
            _context.SaveChanges();

        }
        public void LimparCarrinho()
        {
            var carrinhoItens = _context.ItemCarrinhos.Where(i => i.IdCarrinho == IdCarrinho);
            _context.ItemCarrinhos.RemoveRange(carrinhoItens);
            _context.SaveChanges();


        }
        public double GetTotalCarrinho()
        {
            var total = _context.ItemCarrinhos.Where(p => p.IdCarrinho == IdCarrinho)
                .Select(p => p.Produto.Preco * p.QntProduto)
                .Sum();
            return total;

        }

    }
}
