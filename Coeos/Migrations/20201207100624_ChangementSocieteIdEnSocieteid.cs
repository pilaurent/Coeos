using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class ChangementSocieteIdEnSocieteid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Societe",
                newName: "SocieteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SocieteId",
                table: "Societe",
                newName: "Id");
        }
    }
}
