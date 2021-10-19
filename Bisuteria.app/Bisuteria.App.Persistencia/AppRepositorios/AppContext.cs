using Microsoft.EntityFrameworkCore;
using Bisuteria.App.Dominio;

namespace Bisuteria.App.Persistencia.AppRepositorios
{
    public class AppContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estado_Producto> Estado_Productos { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Talla> Tallas { get; set; }

        //deContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder
           .UseSqlServer("Server=localhost; user id=sa; password=123; Initial Catalog=Bisuteria;");            
            }
        }        
    }
}