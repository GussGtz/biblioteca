using BibliotecaGustavoGtz.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaGustavoGtz.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        //Modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UsuarioBook> UsuarioBooks { get; set; }

        //Semillas de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Instancia de PasswordHasher
            var passwordHasher = new PasswordHasher<Usuario>();

            //Semilla de usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1004,
                    Nombre = "Gus",
                    UserName = "Admin1",
                    Password = passwordHasher.HashPassword(null, "12345"), // Hashear correctamente "12345"
                    FKRol = 1
                }
            );


            // Semilla de los tres roles principales del sistema
            modelBuilder.Entity<Rol>().HasData(
                new Rol { 
                    PkRol = 1,
                    Nombre = "Admin"
                },
                new Rol
                {
                    PkRol = 2,
                    Nombre = "User"
                },
                new Rol
                {
                    PkRol = 3,
                    Nombre = "Guest"
                }
                );

            // Semilla de temeticas
            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    PkTopic = 1,
                    Name_topic = "Sin tema"
                },
                new Topic
                {
                    PkTopic = 2,
                    Name_topic = "Tecnología"
                },
                new Topic
                {
                    PkTopic = 3,
                    Name_topic = "Ciencia"
                },
                new Topic
                {
                    PkTopic = 4,
                    Name_topic = "Entretenimiento"
                },
                new Topic
                {
                    PkTopic = 5,
                    Name_topic = "Terror"
                }
            );

            // Semilla de autores
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    PkAuthor = 1,
                    Name_author = "Sin autor",
                    Birth_date = DateTime.MinValue,
                    Description_author = "Sin descripción",
                    Num_works = 0,
                    Origin = "Sin origen"
                },
                new Author
                {
                    PkAuthor = 2,
                    Name_author = "Gabriel García Márquez",
                    Birth_date = new DateTime(1927, 3, 6),
                    Description_author = "Escritor colombiano, autor de 'Cien años de soledad'.",
                    Num_works = 30,
                    Origin = "Colombia"
                },
                new Author
                {
                    PkAuthor = 3,
                    Name_author = "Jane Austen",
                    Birth_date = new DateTime(1775, 12, 16),
                    Description_author = "Novelista británica, autora de 'Orgullo y prejuicio'.",
                    Num_works = 6,
                    Origin = "Reino Unido"
                },
                new Author
                {
                    PkAuthor = 4,
                    Name_author = "Isaac Asimov",
                    Birth_date = new DateTime(1920, 1, 2),
                    Description_author = "Escritor y bioquímico ruso-estadounidense, pionero de la ciencia ficción.",
                    Num_works = 500,
                    Origin = "Rusia / Estados Unidos"
                },
                new Author
                {
                    PkAuthor = 5,
                    Name_author = "Haruki Murakami",
                    Birth_date = new DateTime(1949, 1, 12),
                    Description_author = "Escritor japonés contemporáneo, autor de 'Tokio Blues'.",
                    Num_works = 15,
                    Origin = "Japón"
                }
            );


            // Semilla de colecciones
            modelBuilder.Entity<Collection>().HasData(
                new Collection
                {
                    PkCollection = 1,
                    Name_collection = "Sin colección",
                    FKAuthor = 1,  
                    FKTopic = 1,   
                    Pieces = 0
                },
                new Collection
                {
                    PkCollection = 2,
                    Name_collection = "Realismo Mágico",
                    FKAuthor = 2,  // Gabriel García Márquez
                    FKTopic = 2,   // Tecnología 
                    Pieces = 10
                },
                new Collection
                {
                    PkCollection = 3,
                    Name_collection = "Novelas Clásicas",
                    FKAuthor = 3,  // Jane Austen
                    FKTopic = 3,   // Ciencia
                    Pieces = 6
                },
                new Collection
                {
                    PkCollection = 4,
                    Name_collection = "Ciencia Ficción",
                    FKAuthor = 4,  // Isaac Asimov
                    FKTopic = 4,   // Entretenimiento
                    Pieces = 20
                },
                new Collection
                {
                    PkCollection = 5,
                    Name_collection = "Literatura Contemporánea",
                    FKAuthor = 5,  // Haruki Murakami
                    FKTopic = 5,   // Deportes
                    Pieces = 12
                }
            );

            // Semilla de libros
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    PkBook = 1,
                    Name_book = "Cien años de soledad",
                    FKTopic = 3,  // Ciencia
                    FKCollection = 2,  // Realismo Mágico
                    FKAuthors = 2,  // Gabriel García Márquez
                    Year_published = new DateTime(1967, 5, 30),
                    Num_pages = 417,
                    Stock = 10,
                    Sold_out = false
                },
                new Book
                {
                    PkBook = 2,
                    Name_book = "Orgullo y prejuicio",
                    FKTopic = 3,  // Ciencia
                    FKCollection = 3,  // Novelas Clásicas
                    FKAuthors = 3,  // Jane Austen
                    Year_published = new DateTime(1813, 1, 28),
                    Num_pages = 279,
                    Stock = 15,
                    Sold_out = false
                },
                new Book
                {
                    PkBook = 3,
                    Name_book = "Fundación",
                    FKTopic = 4,  // Entretenimiento
                    FKCollection = 4,  // Ciencia Ficción
                    FKAuthors = 4,  // Isaac Asimov
                    Year_published = new DateTime(1951, 6, 1),
                    Num_pages = 255,
                    Stock = 5,
                    Sold_out = false
                },
                new Book
                {
                    PkBook = 4,
                    Name_book = "Tokio Blues",
                    FKTopic = 5,  // Terror
                    FKCollection = 5,  // Literatura Contemporánea
                    FKAuthors = 5,  // Haruki Murakami
                    Year_published = new DateTime(1987, 4, 1),
                    Num_pages = 387,
                    Stock = 8,
                    Sold_out = false
                },
                new Book
                {
                    PkBook = 5,
                    Name_book = "La casa de los espíritus",
                    FKTopic = 2,  // Tecnología
                    FKCollection = 2,  // Realismo Mágico
                    FKAuthors = 2,  // Gabriel García Márquez
                    Year_published = new DateTime(1982, 1, 1),
                    Num_pages = 400,
                    Stock = 20,
                    Sold_out = false
                }
            );


            // Configuración de relaciones y eliminación en cascada

            // Configurar la relación entre Book y Topic para no tener eliminación en cascada
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Topics)
                .WithMany()  // Asumiendo que Topic no tiene relación inversa con Book
                .HasForeignKey(b => b.FKTopic)
                .OnDelete(DeleteBehavior.Restrict);  // Evitar eliminación en cascada

            // Configurar la relación entre Book y Collection para no tener eliminación en cascada
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Collections)
                .WithMany()  // Asumiendo que Collection no tiene relación inversa con Book
                .HasForeignKey(b => b.FKCollection)
                .OnDelete(DeleteBehavior.Restrict);  // Evitar eliminación en cascada

            // Configurar la relación entre Book y Author para permitir eliminación en cascada
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Authors)
                .WithMany()  // Asumiendo que Author no tiene relación inversa con Book
                .HasForeignKey(b => b.FKAuthors)
                .OnDelete(DeleteBehavior.Cascade);  // Permitir eliminación en cascada

            // Configurar la relación entre Collection y Author para eliminación en cascada
            modelBuilder.Entity<Collection>()
                .HasOne(c => c.Authors)
                .WithMany()  // Asumiendo que Author no tiene relación inversa con Collection
                .HasForeignKey(c => c.FKAuthor)
                .OnDelete(DeleteBehavior.Cascade);  // Permitir eliminación en cascada solo si se borra el Author

            // Configurar la relación entre Collection y Topic para no tener eliminación en cascada
            modelBuilder.Entity<Collection>()
                .HasOne(c => c.Topics)
                .WithMany()  // Asumiendo que Topic no tiene relación inversa con Collection
                .HasForeignKey(c => c.FKTopic)
                .OnDelete(DeleteBehavior.Restrict);  // Evitar eliminación en cascada

            base.OnModelCreating(modelBuilder);
        }
    }
}
