using Graphql.Models;
using Microsoft.EntityFrameworkCore;

namespace Graphql.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
                 
        }
        public DbSet<Platform> Platforms { get; set; }
    }
}
