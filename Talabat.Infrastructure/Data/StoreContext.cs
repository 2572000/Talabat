using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Talabat.Core.Entities;

namespace Talabat.Infrastructure.Data
{
    public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
    }
}
