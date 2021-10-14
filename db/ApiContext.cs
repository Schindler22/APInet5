using APInet5;
using Microsoft.EntityFrameworkCore;

namespace APInet5
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options){ }

        public DbSet<Cliente> Clientes { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
        }
        
    }
}