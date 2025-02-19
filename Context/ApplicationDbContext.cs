using BibliotecaSánchezLobatoGael83.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaSánchezLobatoGael83.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        //Modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        //Semillas de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Gael Lobato",
                    UserName = "Usuario1",
                    Password = "1234",
                    FKRol = 1
                }
                );
            modelBuilder.Entity<Rol>().HasData(
                new Rol { 
                    PkRol = 1,
                    Nombre = "Admin"
                }
                );
        }
    }
}
