using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class AddAgentIntervention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentIntervention");

            migrationBuilder.CreateTable(
                name: "AgentInterventions",
                columns: table => new
                {
                    InterventionID = table.Column<int>(type: "int", nullable: false),
                    AgentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentInterventions", x => new { x.AgentID, x.InterventionID });
                    table.ForeignKey(
                        name: "FK_AgentInterventions_Agent_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentInterventions_Intervention_InterventionID",
                        column: x => x.InterventionID,
                        principalTable: "Intervention",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentInterventions_InterventionID",
                table: "AgentInterventions",
                column: "InterventionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentInterventions");

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
    }
}
