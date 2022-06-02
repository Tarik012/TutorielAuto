using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorielAuto.Migrations
{
    public partial class MyfirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutoriel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DCC = table.Column<DateTime>(type: "datetime", nullable: false),
                    Contenu = table.Column<string>(type: "text", nullable: false),
                    VideoLink = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DML = table.Column<DateTime>(type: "datetime", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutoriel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutoriel_Categorie",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tutoriel_CategorieId",
                table: "Tutoriel",
                column: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tutoriel");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
