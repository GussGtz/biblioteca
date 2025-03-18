﻿// <auto-generated />
using System;
using BibliotecaGustavoGtz.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaGustavoGtz.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250304172219_third")]
    partial class third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Author", b =>
                {
                    b.Property<int>("PkAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkAuthor"));

                    b.Property<DateTime>("Added_on")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Birth_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description_author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_works")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_on")
                        .HasColumnType("datetime2");

                    b.HasKey("PkAuthor");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            PkAuthor = 1,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Birth_date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description_author = "Sin descripción",
                            Name_author = "Sin autor",
                            Num_works = 0,
                            Origin = "Sin origen",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkAuthor = 2,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Birth_date = new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description_author = "Escritor colombiano, autor de 'Cien años de soledad'.",
                            Name_author = "Gabriel García Márquez",
                            Num_works = 30,
                            Origin = "Colombia",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkAuthor = 3,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Birth_date = new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description_author = "Novelista británica, autora de 'Orgullo y prejuicio'.",
                            Name_author = "Jane Austen",
                            Num_works = 6,
                            Origin = "Reino Unido",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkAuthor = 4,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Birth_date = new DateTime(1920, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description_author = "Escritor y bioquímico ruso-estadounidense, pionero de la ciencia ficción.",
                            Name_author = "Isaac Asimov",
                            Num_works = 500,
                            Origin = "Rusia / Estados Unidos",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkAuthor = 5,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Birth_date = new DateTime(1949, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description_author = "Escritor japonés contemporáneo, autor de 'Tokio Blues'.",
                            Name_author = "Haruki Murakami",
                            Num_works = 15,
                            Origin = "Japón",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Book", b =>
                {
                    b.Property<int>("PkBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkBook"));

                    b.Property<DateTime>("Added_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("FKAuthors")
                        .HasColumnType("int");

                    b.Property<int?>("FKCollection")
                        .HasColumnType("int");

                    b.Property<int>("FKTopic")
                        .HasColumnType("int");

                    b.Property<string>("Name_book")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_pages")
                        .HasColumnType("int");

                    b.Property<bool>("Sold_out")
                        .HasColumnType("bit");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_on")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Year_published")
                        .HasColumnType("datetime2");

                    b.HasKey("PkBook");

                    b.HasIndex("FKAuthors");

                    b.HasIndex("FKCollection");

                    b.HasIndex("FKTopic");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            PkBook = 1,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthors = 2,
                            FKCollection = 2,
                            FKTopic = 3,
                            Name_book = "Cien años de soledad",
                            Num_pages = 417,
                            Sold_out = false,
                            Stock = 10,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year_published = new DateTime(1967, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkBook = 2,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthors = 3,
                            FKCollection = 3,
                            FKTopic = 3,
                            Name_book = "Orgullo y prejuicio",
                            Num_pages = 279,
                            Sold_out = false,
                            Stock = 15,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year_published = new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkBook = 3,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthors = 4,
                            FKCollection = 4,
                            FKTopic = 4,
                            Name_book = "Fundación",
                            Num_pages = 255,
                            Sold_out = false,
                            Stock = 5,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year_published = new DateTime(1951, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkBook = 4,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthors = 5,
                            FKCollection = 5,
                            FKTopic = 5,
                            Name_book = "Tokio Blues",
                            Num_pages = 387,
                            Sold_out = false,
                            Stock = 8,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year_published = new DateTime(1987, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkBook = 5,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthors = 2,
                            FKCollection = 2,
                            FKTopic = 2,
                            Name_book = "La casa de los espíritus",
                            Num_pages = 400,
                            Sold_out = false,
                            Stock = 20,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Year_published = new DateTime(1982, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Collection", b =>
                {
                    b.Property<int>("PkCollection")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkCollection"));

                    b.Property<DateTime>("Added_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("FKAuthor")
                        .HasColumnType("int");

                    b.Property<int>("FKTopic")
                        .HasColumnType("int");

                    b.Property<string>("Name_collection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pieces")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_on")
                        .HasColumnType("datetime2");

                    b.HasKey("PkCollection");

                    b.HasIndex("FKAuthor");

                    b.HasIndex("FKTopic");

                    b.ToTable("Collections");

                    b.HasData(
                        new
                        {
                            PkCollection = 1,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthor = 1,
                            FKTopic = 1,
                            Name_collection = "Sin colección",
                            Pieces = 0,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkCollection = 2,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthor = 2,
                            FKTopic = 2,
                            Name_collection = "Realismo Mágico",
                            Pieces = 10,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkCollection = 3,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthor = 3,
                            FKTopic = 3,
                            Name_collection = "Novelas Clásicas",
                            Pieces = 6,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkCollection = 4,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthor = 4,
                            FKTopic = 4,
                            Name_collection = "Ciencia Ficción",
                            Pieces = 20,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkCollection = 5,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKAuthor = 5,
                            FKTopic = 5,
                            Name_collection = "Literatura Contemporánea",
                            Pieces = 12,
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRol"));

                    b.Property<DateTime>("Added_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_on")
                        .HasColumnType("datetime2");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            PkRol = 1,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Admin",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkRol = 2,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "User",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkRol = 3,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Guest",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Topic", b =>
                {
                    b.Property<int>("PkTopic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkTopic"));

                    b.Property<DateTime>("Added_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name_topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_on")
                        .HasColumnType("datetime2");

                    b.HasKey("PkTopic");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            PkTopic = 1,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name_topic = "Sin tema",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkTopic = 2,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name_topic = "Tecnología",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkTopic = 3,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name_topic = "Ciencia",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkTopic = 4,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name_topic = "Entretenimiento",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            PkTopic = 5,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name_topic = "Terror",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkUsuario"));

                    b.Property<DateTime>("Added_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("FKRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FKRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            PkUsuario = 1004,
                            Added_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FKRol = 1,
                            Nombre = "Gus",
                            Password = "12345",
                            Updated_on = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "Admin1"
                        });
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.UsuarioBook", b =>
                {
                    b.Property<int>("PkUsuarioBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkUsuarioBook"));

                    b.Property<DateTime>("Added_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("FKBook")
                        .HasColumnType("int");

                    b.Property<int>("FKUsuario")
                        .HasColumnType("int");

                    b.HasKey("PkUsuarioBook");

                    b.HasIndex("FKBook");

                    b.HasIndex("FKUsuario");

                    b.ToTable("UsuarioBooks");
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Book", b =>
                {
                    b.HasOne("BibliotecaGustavoGtz.Models.Domain.Author", "Authors")
                        .WithMany()
                        .HasForeignKey("FKAuthors")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaGustavoGtz.Models.Domain.Collection", "Collections")
                        .WithMany()
                        .HasForeignKey("FKCollection")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BibliotecaGustavoGtz.Models.Domain.Topic", "Topics")
                        .WithMany()
                        .HasForeignKey("FKTopic")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Authors");

                    b.Navigation("Collections");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Collection", b =>
                {
                    b.HasOne("BibliotecaGustavoGtz.Models.Domain.Author", "Authors")
                        .WithMany()
                        .HasForeignKey("FKAuthor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaGustavoGtz.Models.Domain.Topic", "Topics")
                        .WithMany()
                        .HasForeignKey("FKTopic")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Authors");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Usuario", b =>
                {
                    b.HasOne("BibliotecaGustavoGtz.Models.Domain.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FKRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.UsuarioBook", b =>
                {
                    b.HasOne("BibliotecaGustavoGtz.Models.Domain.Book", "Book")
                        .WithMany("UsuarioBooks")
                        .HasForeignKey("FKBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaGustavoGtz.Models.Domain.Usuario", "Usuario")
                        .WithMany("UsuarioBooks")
                        .HasForeignKey("FKUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Book", b =>
                {
                    b.Navigation("UsuarioBooks");
                });

            modelBuilder.Entity("BibliotecaGustavoGtz.Models.Domain.Usuario", b =>
                {
                    b.Navigation("UsuarioBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
