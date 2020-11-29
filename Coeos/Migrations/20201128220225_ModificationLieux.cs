using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class ModificationLieux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lieu_Intervention_InterventionId",
                table: "Lieu");

            migrationBuilder.AlterColumn<int>(
                name: "InterventionId",
                table: "Lieu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lieu_Intervention_InterventionId",
                table: "Lieu",
                column: "InterventionId",
                principalTable: "Intervention",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lieu_Intervention_InterventionId",
                table: "Lieu");

            migrationBuilder.AlterColumn<int>(
                name: "InterventionId",
                table: "Lieu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lieu_Intervention_InterventionId",
                table: "Lieu",
                column: "InterventionId",
                principalTable: "Intervention",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
