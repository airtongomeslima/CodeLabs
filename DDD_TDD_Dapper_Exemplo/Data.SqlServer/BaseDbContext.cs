using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Data.SqlServer
{
    public class BaseDbContext : DbContext
    {
        IConfiguration _config;

        public BaseDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("TesteConnection"));
        }
    }
}

