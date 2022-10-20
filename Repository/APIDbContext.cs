using CrudLocacao.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudLocacao.Repository
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        public DbSet<Imoveis> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imoveis>()
                .HasData(
                new Imoveis { Id = 1, Name = "casaMG", Cep = "39745180" },
                new Imoveis { Id = 2, Name = "casaGO", Cep = "13745180" },
                new Imoveis { Id = 3, Name = "casaSP", Cep = "12745180" });

        }
    }
}
