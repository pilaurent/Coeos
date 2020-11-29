using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class ModificationInterventions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Intervention");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Intervention",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropIndex(
                name: "IX_Intervention_CategorieId",
                table: "Intervention");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Intervention");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Intervention",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
