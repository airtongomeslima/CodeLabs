using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModeloDDD.Dominio.Entitades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeloDDD.Infra.Dados.Contexto
{
    public partial class ContextoEF : DbContext
    {
        IConfiguration _config;

        public ContextoEF(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("ModeloDDDConnection"));
        }

        public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //A regra padrão para quando houver tentativa de deletar registro com relação
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
            
        }

    }
}
