using Microsoft.EntityFrameworkCore;
using MiniMercado.Controllers;
using MiniMercado.Model;

namespace MiniMercado.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {     
        }

        public DbSet<Usuario>? Usuarios {  get; set; }
        public DbSet<Produto>? Produtos { get; set; }

    }
}
