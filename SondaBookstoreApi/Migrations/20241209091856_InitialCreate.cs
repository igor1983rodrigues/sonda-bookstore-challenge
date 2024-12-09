using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SondaBookstoreApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    codAs = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.codAs);
                });

            migrationBuilder.CreateTable(
                name: "AUTOR",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTOR", x => x.CodAu);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Codl = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Editora = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Edicao = table.Column<int>(type: "integer", nullable: false),
                    AnoPublicacao = table.Column<int>(type: "integer", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Codl);
                });

            migrationBuilder.CreateTable(
                name: "BookSubjects",
                columns: table => new
                {
                    Livro_Codl = table.Column<int>(type: "integer", nullable: false),
                    Autor_CodAu = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubjects", x => new { x.Livro_Codl, x.Autor_CodAu });
                    table.ForeignKey(
                        name: "FK_BookSubjects_Assunto_Autor_CodAu",
                        column: x => x.Autor_CodAu,
                        principalTable: "Assunto",
                        principalColumn: "codAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSubjects_Livro_Livro_Codl",
                        column: x => x.Livro_Codl,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Autor",
                columns: table => new
                {
                    Livro_Codl = table.Column<int>(type: "integer", nullable: false),
                    Autor_CodAu = table.Column<int>(type: "integer", nullable: false),
                    Autor_CodAu_FK = table.Column<int>(type: "integer", nullable: false),
                    Livro_Codl_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro_Autor", x => new { x.Livro_Codl, x.Autor_CodAu });
                    table.ForeignKey(
                        name: "FK_Livro_Autor_AUTOR_Autor_CodAu",
                        column: x => x.Autor_CodAu,
                        principalTable: "AUTOR",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_Livro_Livro_Codl",
                        column: x => x.Livro_Codl,
                        principalTable: "Livro",
                        principalColumn: "Codl",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookSubjects_Autor_CodAu",
                table: "BookSubjects",
                column: "Autor_CodAu");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Autor_Autor_CodAu",
                table: "Livro_Autor",
                column: "Autor_CodAu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSubjects");

            migrationBuilder.DropTable(
                name: "Livro_Autor");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "AUTOR");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
