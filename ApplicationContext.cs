using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.Models;

namespace Titan
{
    public class ApplicationContext: DbContext
    {
 
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<LojaEntity> Lojas { get; set; }
        public DbSet<SatisfacaoEntity> Satisfacoes { get; set; }
        public DbSet<SecaoEntity> Secoes { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CHAVES
            modelBuilder.Entity<ClienteEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<LojaEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<SatisfacaoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<SecaoEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<UsuarioEntity>().HasKey(t => t.Id);

            //RELACOES
            modelBuilder.Entity<LojaEntity>().HasMany(t => t.Usuarios);
            modelBuilder.Entity<SatisfacaoEntity>().HasOne(t => t.Loja);
            modelBuilder.Entity<SatisfacaoEntity>().HasOne(t => t.Secao);
            modelBuilder.Entity<SecaoEntity>().HasOne(t => t.Loja);
            modelBuilder.Entity<ClienteEntity>().HasOne(t => t.Loja);
            modelBuilder.Entity<ClienteEntity>().HasOne(t => t.Cor);






        }



    }
}
