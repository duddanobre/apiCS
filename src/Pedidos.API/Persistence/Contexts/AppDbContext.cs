using Microsoft.EntityFrameworkCore;
using Pedidos.API.Domain.Models;
using System.Collections.Generic;
using System;

namespace Pedidos.API.Persistence.Contexts{
    public class AppDbContext: DbContext{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Pedido> Pedidos{get; set;}

        public DbSet<Product> Products {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<Product> ().ToTable("Produtos");
            builder.Entity<Product> ().HasKey(p => p.ProdutoId);
            builder.Entity<Product> ().Property(p => p.ProdutoId).IsRequired ().ValueGeneratedOnAdd();
            builder.Entity<Product> ().Property(p => p.Nome).IsRequired ().HasMaxLength(30);
            builder.Entity<Product> ().Property(p => p.Descricao).IsRequired ().HasMaxLength(50);
            builder.Entity<Product> ().Property(p => p.Valor).IsRequired ();
            builder.Entity<Product> ().HasOne(p => p.Pedido).WithMany(p => p.Produtos).HasForeignKey (p => p.IdPedido);
            
            builder.Entity<Product> ().HasData(
                new Product {ProdutoId =2, Nome = "Skate", Descricao  = "Skate preto oficial Justin Bieber", IdPedido = 001, Valor = 55}
            );

            builder.Entity<Pedido> ().ToTable("Pedidos");
            builder.Entity<Pedido> ().HasKey(p => p.Id);
            builder.Entity<Pedido> ().Property(p => p.Id).IsRequired ().ValueGeneratedOnAdd();
            builder.Entity<Pedido> ().Property(p => p.Endereco).IsRequired ().HasMaxLength(100);
            builder.Entity<Pedido> ().HasMany(p => p.Produtos).WithOne(p => p.Pedido).HasForeignKey (p => p.IdPedido);

            builder.Entity<Pedido> ().HasData(
                new Pedido {Id = 001, Data_create = new System.DateTime(2022, 02, 15), Data_entrega = new System.DateTime(2022, 03, 01), Endereco = "Rua das Laranjas",
                },
                new Pedido {Id = 002, Data_create = new System.DateTime(2022, 02, 16), Data_entrega = new System.DateTime(2022, 03, 05), Endereco = "Rua das Oliveiras, Fortaleza, Aldeota",
                }
            );
        
        }

    }
}