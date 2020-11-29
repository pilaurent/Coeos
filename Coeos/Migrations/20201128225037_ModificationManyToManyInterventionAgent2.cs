using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class ModificationManyToManyInterventionAgent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterventionAgent");

            migrationBuilder.CreateTable(
                name: "AgentIntervention",
                columns: table => new
                {
                    AgentsId = table.Column<int>(type: "int", nullable: false),
                    InterventionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentIntervention", x => new { x.AgentsId, x.InterventionsId });
                    table.ForeignKey(
                        name: "FK_AgentIntervention_Agent_AgentsId",
                        column: x => x.AgentsId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentIntervention_Intervention_InterventionsId",
                        column: x => x.InterventionsId,
                        principalTable: "Intervention",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentIntervention_InterventionsId",
                table: "AgentIntervention",
                column: "InterventionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentIntervention");

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
    }
}
