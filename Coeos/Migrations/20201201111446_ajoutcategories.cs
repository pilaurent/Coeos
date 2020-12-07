using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class ajoutcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Intervention",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intervention_CategorieId",
                table: "Intervention",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Categorie_CategorieId",
                table: "Intervention",
                column: "CategorieId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Categorie_CategorieId",
                table: "Intervention");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Intervention_CategorieId",
                table: "Intervention");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Intervention");
        }
    }
}
