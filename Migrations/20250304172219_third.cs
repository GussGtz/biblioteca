using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BibliotecaSánchezLobatoGael83.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    PkAuthor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description_author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Num_works = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Added_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.PkAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Added_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    PkTopic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Added_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.PkTopic);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKRol = table.Column<int>(type: "int", nullable: false),
                    Added_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FKRol",
                        column: x => x.FKRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    PkCollection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_collection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKAuthor = table.Column<int>(type: "int", nullable: false),
                    FKTopic = table.Column<int>(type: "int", nullable: false),
                    Pieces = table.Column<int>(type: "int", nullable: false),
                    Added_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.PkCollection);
                    table.ForeignKey(
                        name: "FK_Collections_Authors_FKAuthor",
                        column: x => x.FKAuthor,
                        principalTable: "Authors",
                        principalColumn: "PkAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collections_Topics_FKTopic",
                        column: x => x.FKTopic,
                        principalTable: "Topics",
                        principalColumn: "PkTopic",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    PkBook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_book = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKTopic = table.Column<int>(type: "int", nullable: false),
                    FKCollection = table.Column<int>(type: "int", nullable: true),
                    FKAuthors = table.Column<int>(type: "int", nullable: false),
                    Year_published = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Num_pages = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Sold_out = table.Column<bool>(type: "bit", nullable: false),
                    Added_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.PkBook);
                    table.ForeignKey(
                        name: "FK_Books_Authors_FKAuthors",
                        column: x => x.FKAuthors,
                        principalTable: "Authors",
                        principalColumn: "PkAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Collections_FKCollection",
                        column: x => x.FKCollection,
                        principalTable: "Collections",
                        principalColumn: "PkCollection",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Topics_FKTopic",
                        column: x => x.FKTopic,
                        principalTable: "Topics",
                        principalColumn: "PkTopic",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioBooks",
                columns: table => new
                {
                    PkUsuarioBook = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKUsuario = table.Column<int>(type: "int", nullable: false),
                    FKBook = table.Column<int>(type: "int", nullable: false),
                    Added_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioBooks", x => x.PkUsuarioBook);
                    table.ForeignKey(
                        name: "FK_UsuarioBooks_Books_FKBook",
                        column: x => x.FKBook,
                        principalTable: "Books",
                        principalColumn: "PkBook",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioBooks_Usuarios_FKUsuario",
                        column: x => x.FKUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "PkUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "PkAuthor", "Added_on", "Birth_date", "Description_author", "Name_author", "Num_works", "Origin", "Updated_on" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sin descripción", "Sin autor", 0, "Sin origen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escritor colombiano, autor de 'Cien años de soledad'.", "Gabriel García Márquez", 30, "Colombia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Novelista británica, autora de 'Orgullo y prejuicio'.", "Jane Austen", 6, "Reino Unido", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1920, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escritor y bioquímico ruso-estadounidense, pionero de la ciencia ficción.", "Isaac Asimov", 500, "Rusia / Estados Unidos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1949, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escritor japonés contemporáneo, autor de 'Tokio Blues'.", "Haruki Murakami", 15, "Japón", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "Added_on", "Nombre", "Updated_on" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guest", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "PkTopic", "Added_on", "Name_topic", "Updated_on" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sin tema", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tecnología", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciencia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entretenimiento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "PkCollection", "Added_on", "FKAuthor", "FKTopic", "Name_collection", "Pieces", "Updated_on" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Sin colección", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Realismo Mágico", 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Novelas Clásicas", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Ciencia Ficción", 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "Literatura Contemporánea", 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PkUsuario", "Added_on", "FKRol", "Nombre", "Password", "Updated_on", "UserName" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Gael Lobato", "qwerty", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lobato" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "PkBook", "Added_on", "FKAuthors", "FKCollection", "FKTopic", "Name_book", "Num_pages", "Sold_out", "Stock", "Updated_on", "Year_published" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 3, "Cien años de soledad", 417, false, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1967, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 3, "Orgullo y prejuicio", 279, false, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, 4, "Fundación", 255, false, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1951, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 5, "Tokio Blues", 387, false, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, "La casa de los espíritus", 400, false, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_FKAuthors",
                table: "Books",
                column: "FKAuthors");

            migrationBuilder.CreateIndex(
                name: "IX_Books_FKCollection",
                table: "Books",
                column: "FKCollection");

            migrationBuilder.CreateIndex(
                name: "IX_Books_FKTopic",
                table: "Books",
                column: "FKTopic");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_FKAuthor",
                table: "Collections",
                column: "FKAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_FKTopic",
                table: "Collections",
                column: "FKTopic");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioBooks_FKBook",
                table: "UsuarioBooks",
                column: "FKBook");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioBooks_FKUsuario",
                table: "UsuarioBooks",
                column: "FKUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FKRol",
                table: "Usuarios",
                column: "FKRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
