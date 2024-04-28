using Microsoft.EntityFrameworkCore;
using Cork_Technical.Models;

namespace Cork_Technical.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Asset> Assets { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
    }
}
