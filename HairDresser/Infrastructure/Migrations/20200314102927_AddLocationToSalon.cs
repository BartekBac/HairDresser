using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddLocationToSalon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Location_Latitude",
                table: "Salons",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Location_Longitude",
                table: "Salons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Latitude",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Location_Longitude",
                table: "Salons");
        }
    }
}
