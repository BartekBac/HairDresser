using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class ScheduleTableV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Schedule_Id",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Friday_Begin",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Friday_End",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Monday_Begin",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Monday_End",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Saturday_Begin",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Saturday_End",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Sunday_Begin",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Sunday_End",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Thursday_Begin",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Thursday_End",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Tuesday_Begin",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Tuesday_End",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Wednesday_Begin",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Wednesday_End",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Schedule_Id",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Friday_Begin",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Friday_End",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Monday_Begin",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Monday_End",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Saturday_Begin",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Saturday_End",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Sunday_Begin",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Sunday_End",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Thursday_Begin",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Thursday_End",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Tuesday_Begin",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Tuesday_End",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Wednesday_Begin",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Schedule_Wednesday_End",
                table: "Salons");

            migrationBuilder.CreateTable(
                name: "Schedule<Salon>",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    Monday_Begin = table.Column<TimeSpan>(nullable: true),
                    Monday_End = table.Column<TimeSpan>(nullable: true),
                    Tuesday_Begin = table.Column<TimeSpan>(nullable: true),
                    Tuesday_End = table.Column<TimeSpan>(nullable: true),
                    Wednesday_Begin = table.Column<TimeSpan>(nullable: true),
                    Wednesday_End = table.Column<TimeSpan>(nullable: true),
                    Thursday_Begin = table.Column<TimeSpan>(nullable: true),
                    Thursday_End = table.Column<TimeSpan>(nullable: true),
                    Friday_Begin = table.Column<TimeSpan>(nullable: true),
                    Friday_End = table.Column<TimeSpan>(nullable: true),
                    Saturday_Begin = table.Column<TimeSpan>(nullable: true),
                    Saturday_End = table.Column<TimeSpan>(nullable: true),
                    Sunday_Begin = table.Column<TimeSpan>(nullable: true),
                    Sunday_End = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule<Salon>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule<Salon>_Salons_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule<Worker>",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    Monday_Begin = table.Column<TimeSpan>(nullable: true),
                    Monday_End = table.Column<TimeSpan>(nullable: true),
                    Tuesday_Begin = table.Column<TimeSpan>(nullable: true),
                    Tuesday_End = table.Column<TimeSpan>(nullable: true),
                    Wednesday_Begin = table.Column<TimeSpan>(nullable: true),
                    Wednesday_End = table.Column<TimeSpan>(nullable: true),
                    Thursday_Begin = table.Column<TimeSpan>(nullable: true),
                    Thursday_End = table.Column<TimeSpan>(nullable: true),
                    Friday_Begin = table.Column<TimeSpan>(nullable: true),
                    Friday_End = table.Column<TimeSpan>(nullable: true),
                    Saturday_Begin = table.Column<TimeSpan>(nullable: true),
                    Saturday_End = table.Column<TimeSpan>(nullable: true),
                    Sunday_Begin = table.Column<TimeSpan>(nullable: true),
                    Sunday_End = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule<Worker>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule<Worker>_Workers_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule<Salon>_EntityId",
                table: "Schedule<Salon>",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule<Worker>_EntityId",
                table: "Schedule<Worker>",
                column: "EntityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule<Salon>");

            migrationBuilder.DropTable(
                name: "Schedule<Worker>");

            migrationBuilder.AddColumn<Guid>(
                name: "Schedule_Id",
                table: "Workers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Friday_Begin",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Friday_End",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Monday_Begin",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Monday_End",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Saturday_Begin",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Saturday_End",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Sunday_Begin",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Sunday_End",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Thursday_Begin",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Thursday_End",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Tuesday_Begin",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Tuesday_End",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Wednesday_Begin",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Wednesday_End",
                table: "Workers",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Schedule_Id",
                table: "Salons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Friday_Begin",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Friday_End",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Monday_Begin",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Monday_End",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Saturday_Begin",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Saturday_End",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Sunday_Begin",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Sunday_End",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Thursday_Begin",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Thursday_End",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Tuesday_Begin",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Tuesday_End",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Wednesday_Begin",
                table: "Salons",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule_Wednesday_End",
                table: "Salons",
                type: "time",
                nullable: true);
        }
    }
}
