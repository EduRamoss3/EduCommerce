﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Context;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231105171204_AlterSizeDescription")]
    partial class AlterSizeDescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Carrinho", b =>
                {
                    b.Property<string>("IdCarrinho")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("QuantidadeTotal")
                        .HasColumnType("int");

                    b.HasKey("IdCarrinho");

                    b.ToTable("Carrinhos");
                });

            modelBuilder.Entity("WebApplication2.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"));

                    b.Property<decimal>("AVista")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("AntigoPreco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CarrinhoIdCarrinho")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoCurta")
                        .IsRequired()
                        .HasMaxLength(208)
                        .HasColumnType("nvarchar(208)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaxVezes")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Preco")
                        .HasMaxLength(100000)
                        .HasColumnType("float");

                    b.Property<decimal>("PrecoSecundario")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(999)
                        .HasColumnType("int");

                    b.Property<int>("Tipos")
                        .HasColumnType("int");

                    b.Property<int?>("VendasVendaId")
                        .HasColumnType("int");

                    b.HasKey("IdProduto");

                    b.HasIndex("CarrinhoIdCarrinho");

                    b.HasIndex("VendasVendaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("WebApplication2.Models.Usuario", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPessoa"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DateNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCarrinho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_CarrinhoIdCarrinho")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdPessoa");

                    b.HasIndex("_CarrinhoIdCarrinho");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApplication2.Models.Vendas", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendaId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("VendaId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("WebApplication2.Models.Produto", b =>
                {
                    b.HasOne("WebApplication2.Models.Carrinho", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CarrinhoIdCarrinho");

                    b.HasOne("WebApplication2.Models.Vendas", null)
                        .WithMany("Produtos")
                        .HasForeignKey("VendasVendaId");
                });

            modelBuilder.Entity("WebApplication2.Models.Usuario", b =>
                {
                    b.HasOne("WebApplication2.Models.Carrinho", "_Carrinho")
                        .WithMany()
                        .HasForeignKey("_CarrinhoIdCarrinho");

                    b.Navigation("_Carrinho");
                });

            modelBuilder.Entity("WebApplication2.Models.Carrinho", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("WebApplication2.Models.Vendas", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
