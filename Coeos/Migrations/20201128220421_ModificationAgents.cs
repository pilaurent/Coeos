﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Coeos.Migrations
{
    public partial class ModificationAgents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Intervention_InterventionId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Societe_SocieteId",
                table: "Agent");

            migrationBuilder.AlterColumn<int>(
                name: "SocieteId",
                table: "Agent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InterventionId",
                table: "Agent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Intervention_InterventionId",
                table: "Agent",
                column: "InterventionId",
                principalTable: "Intervention",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Societe_SocieteId",
                table: "Agent",
                column: "SocieteId",
                principalTable: "Societe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Intervention_InterventionId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Societe_SocieteId",
                table: "Agent");

            migrationBuilder.AlterColumn<int>(
                name: "SocieteId",
                table: "Agent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InterventionId",
                table: "Agent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Intervention_InterventionId",
                table: "Agent",
                column: "InterventionId",
                principalTable: "Intervention",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Societe_SocieteId",
                table: "Agent",
                column: "SocieteId",
                principalTable: "Societe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
