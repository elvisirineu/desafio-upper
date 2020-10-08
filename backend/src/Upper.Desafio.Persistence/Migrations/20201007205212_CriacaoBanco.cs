using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Upper.Desafio.Persistence.Migrations
{
    public partial class CriacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colheita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Informacao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    PesoBruto = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colheita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arvore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    EspecieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arvore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arvore_Especie_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColheitaArvore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArvoreId = table.Column<int>(nullable: false),
                    ColheitaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColheitaArvore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColheitaArvore_Arvore_ArvoreId",
                        column: x => x.ArvoreId,
                        principalTable: "Arvore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColheitaArvore_Colheita_ColheitaId",
                        column: x => x.ColheitaId,
                        principalTable: "Colheita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoArvore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArvoreId = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoArvore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoArvore_Arvore_ArvoreId",
                        column: x => x.ArvoreId,
                        principalTable: "Arvore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoArvore_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arvore_EspecieId",
                table: "Arvore",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_ColheitaArvore_ArvoreId",
                table: "ColheitaArvore",
                column: "ArvoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ColheitaArvore_ColheitaId",
                table: "ColheitaArvore",
                column: "ColheitaId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoArvore_ArvoreId",
                table: "GrupoArvore",
                column: "ArvoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoArvore_GrupoId",
                table: "GrupoArvore",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColheitaArvore");

            migrationBuilder.DropTable(
                name: "GrupoArvore");

            migrationBuilder.DropTable(
                name: "Colheita");

            migrationBuilder.DropTable(
                name: "Arvore");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "Especie");
        }
    }
}
