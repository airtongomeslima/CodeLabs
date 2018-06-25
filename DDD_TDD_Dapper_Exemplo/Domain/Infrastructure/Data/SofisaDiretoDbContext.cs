using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using API.Data.SqlServer;
using API.Domain.Infrastructure.Data.Mapping;

namespace API.Domain.Infrastructure.Data
{
    public class TesteDbContext : BaseDbContext
    {
        public TesteDbContext(IConfiguration config) : base(config)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArquiteturaExemploEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

