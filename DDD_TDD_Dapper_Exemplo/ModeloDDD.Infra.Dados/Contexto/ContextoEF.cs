using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModeloDDD.Dominio.Entitades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeloDDD.Infra.Dados.Contexto
{
    public partial class CONTEXTOEF : DbContext
    {
        DbContextOptions<CONTEXTOEF> _options;

        public CONTEXTOEF(IConfiguration config)
            //: base(options)
        {
            _options = null; // TODO: ???
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
