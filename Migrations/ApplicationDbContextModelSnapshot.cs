﻿// <auto-generated />
using BibliotecaSánchezLobatoGael83.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaSánchezLobatoGael83.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotecaSánchezLobatoGael83.Models.Domain.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            PkRol = 1,
                            Nombre = "Admin"
                        });
                });

            modelBuilder.Entity("BibliotecaSánchezLobatoGael83.Models.Domain.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkUsuario"));

                    b.Property<int>("FKRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FKRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            PkUsuario = 1,
                            FKRol = 1,
                            Nombre = "Gael Lobato",
                            Password = "1234",
                            UserName = "Usuario1"
                        });
                });

            modelBuilder.Entity("BibliotecaSánchezLobatoGael83.Models.Domain.Usuario", b =>
                {
                    b.HasOne("BibliotecaSánchezLobatoGael83.Models.Domain.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FKRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
