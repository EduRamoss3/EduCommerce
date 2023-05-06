using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class BancodeDados : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinho_ { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=GestorOS;Integrated Security=True");
        }


    }
}
