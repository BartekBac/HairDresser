using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class ScheduleDayIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Friday_IsActive",
                table: "Schedule<Worker>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Monday_IsActive",
                table: "Schedule<Worker>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Saturday_IsActive",
                table: "Schedule<Worker>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sunday_IsActive",
                table: "Schedule<Worker>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Thursday_IsActive",
                table: "Schedule<Worker>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Tuesday_IsActive",
                table: "Schedule<Worker>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Wednesday_IsActive",
                table: "Schedule<Worker>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Friday_IsActive",
                table: "Schedule<Salon>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Monday_IsActive",
                table: "Schedule<Salon>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Saturday_IsActive",
                table: "Schedule<Salon>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sunday_IsActive",
                table: "Schedule<Salon>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Thursday_IsActive",
                table: "Schedule<Salon>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Tuesday_IsActive",
                table: "Schedule<Salon>",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Wednesday_IsActive",
                table: "Schedule<Salon>",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friday_IsActive",
                table: "Schedule<Worker>");

            migrationBuilder.DropColumn(
                name: "Monday_IsActive",
                table: "Schedule<Worker>");

            migrationBuilder.DropColumn(
                name: "Saturday_IsActive",
                table: "Schedule<Worker>");

            migrationBuilder.DropColumn(
                name: "Sunday_IsActive",
                table: "Schedule<Worker>");

            migrationBuilder.DropColumn(
                name: "Thursday_IsActive",
                table: "Schedule<Worker>");

            migrationBuilder.DropColumn(
                name: "Tuesday_IsActive",
                table: "Schedule<Worker>");

            migrationBuilder.DropColumn(
                name: "Wednesday_IsActive",
                table: "Schedule<Worker>");

            migrationBuilder.DropColumn(
                name: "Friday_IsActive",
                table: "Schedule<Salon>");

            migrationBuilder.DropColumn(
                name: "Monday_IsActive",
                table: "Schedule<Salon>");

            migrationBuilder.DropColumn(
                name: "Saturday_IsActive",
                table: "Schedule<Salon>");

            migrationBuilder.DropColumn(
                name: "Sunday_IsActive",
                table: "Schedule<Salon>");

            migrationBuilder.DropColumn(
                name: "Thursday_IsActive",
                table: "Schedule<Salon>");

            migrationBuilder.DropColumn(
                name: "Tuesday_IsActive",
                table: "Schedule<Salon>");

            migrationBuilder.DropColumn(
                name: "Wednesday_IsActive",
                table: "Schedule<Salon>");
        }
    }
}
