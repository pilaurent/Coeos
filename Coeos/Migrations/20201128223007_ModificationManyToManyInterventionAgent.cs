using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class ModificationManyToManyInterventionAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Intervention_InterventionId",
                table: "Agent");

            migrationBuilder.DropIndex(
                name: "IX_Agent_InterventionId",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "InterventionId",
                table: "Agent");

            migrationBuilder.CreateTable(
                name: "InterventionAgent",
                columns: table => new
                {
                    InterventionId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterventionAgent", x => new { x.InterventionId, x.AgentId });
                    table.ForeignKey(
                        name: "FK_InterventionAgent_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterventionAgent_Intervention_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Intervention",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterventionAgent_AgentId",
                table: "InterventionAgent",
                column: "AgentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterventionAgent");

            migrationBuilder.AddColumn<int>(
                name: "InterventionId",
                table: "Agent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agent_InterventionId",
                table: "Agent",
                column: "InterventionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Intervention_InterventionId",
                table: "Agent",
                column: "InterventionId",
                principalTable: "Intervention",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
