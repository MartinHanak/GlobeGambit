using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.Data
{
    public class BackendDbContext : IdentityDbContext<IdentityUser>
    {
        public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
        {
            var dbCreater = Database.GetService<IRelationalDatabaseCreator>();

            if (dbCreater != null)
            {
                if (!dbCreater.CanConnect())
                {
                    dbCreater.Create();
                }

                if (!dbCreater.HasTables())
                {
                    dbCreater.CreateTables();
                }
            }
        }

        public DbSet<TestProduct> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestProduct>().HasData(
                new TestProduct() { Id = 1, Name = "Apple iPad", Price = 1000 },
                new TestProduct() { Id = 2, Name = "Samsung Smart TV", Price = 1500 },
                new TestProduct() { Id = 3, Name = "Nokia 130", Price = 1200 }
            );
        }
    }
}
