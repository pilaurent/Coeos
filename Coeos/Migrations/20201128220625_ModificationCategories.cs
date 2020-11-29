using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class ModificationCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorie_Intervention_InterventionId",
                table: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Categorie_InterventionId",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "InterventionId",
                table: "Categorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterventionId",
                table: "Categorie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_InterventionId",
                table: "Categorie",
                column: "InterventionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorie_Intervention_InterventionId",
                table: "Categorie",
                column: "InterventionId",
                principalTable: "Intervention",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
