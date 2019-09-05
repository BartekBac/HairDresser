using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class ScheduleMovedToOwnTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Visits_VisitId",
                table: "VisitServices");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerServices_Workers_WorkerId",
                table: "WorkerServices");

            migrationBuilder.AddColumn<Guid>(
                name: "Schedule_Id",
                table: "Workers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Schedule_Id",
                table: "Salons",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServices_Visits_VisitId",
                table: "VisitServices",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerServices_Workers_WorkerId",
                table: "WorkerServices",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Visits_VisitId",
                table: "VisitServices");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerServices_Workers_WorkerId",
                table: "WorkerServices");

            migrationBuilder.DropColumn(
                name: "Schedule_Id",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Id",
                table: "Salons");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServices_Visits_VisitId",
                table: "VisitServices",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerServices_Workers_WorkerId",
                table: "WorkerServices",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
