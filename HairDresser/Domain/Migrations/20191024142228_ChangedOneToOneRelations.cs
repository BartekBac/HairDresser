using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class ChangedOneToOneRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule<Worker>_Workers_EntityId",
                table: "Schedule<Worker>");

            migrationBuilder.DropTable(
                name: "EntityImage<Client>");

            migrationBuilder.DropTable(
                name: "EntityImage<Opinion>");

            migrationBuilder.DropTable(
                name: "EntityImage<Salon>");

            migrationBuilder.DropTable(
                name: "EntityImage<Worker>");

            migrationBuilder.DropTable(
                name: "Schedule<Salon>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule<Worker>",
                table: "Schedule<Worker>");

            migrationBuilder.DropIndex(
                name: "IX_Schedule<Worker>_EntityId",
                table: "Schedule<Worker>");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Schedule<Worker>");

            migrationBuilder.RenameTable(
                name: "Schedule<Worker>",
                newName: "Schedule");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Workers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                table: "Workers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Salons",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleId",
                table: "Salons",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Opinions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Source = table.Column<byte[]>(nullable: true),
                    Header = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ImageId",
                table: "Workers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ScheduleId",
                table: "Workers",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_ImageId",
                table: "Salons",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_ScheduleId",
                table: "Salons",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_ImageId",
                table: "Opinions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ImageId",
                table: "Clients",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Images_ImageId",
                table: "Clients",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Images_ImageId",
                table: "Opinions",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salons_Images_ImageId",
                table: "Salons",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salons_Schedule_ScheduleId",
                table: "Salons",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Images_ImageId",
                table: "Workers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Schedule_ScheduleId",
                table: "Workers",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Images_ImageId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Images_ImageId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Salons_Images_ImageId",
                table: "Salons");

            migrationBuilder.DropForeignKey(
                name: "FK_Salons_Schedule_ScheduleId",
                table: "Salons");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Images_ImageId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Schedule_ScheduleId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Workers_ImageId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_ScheduleId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Salons_ImageId",
                table: "Salons");

            migrationBuilder.DropIndex(
                name: "IX_Salons_ScheduleId",
                table: "Salons");

            migrationBuilder.DropIndex(
                name: "IX_Opinions_ImageId",
                table: "Opinions");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ImageId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Opinions");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedule<Worker>");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "Schedule<Worker>",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule<Worker>",
                table: "Schedule<Worker>",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EntityImage<Client>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityImage<Client>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityImage<Client>_Clients_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityImage<Opinion>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityImage<Opinion>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityImage<Opinion>_Opinions_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Opinions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityImage<Salon>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityImage<Salon>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityImage<Salon>_Salons_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityImage<Worker>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityImage<Worker>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityImage<Worker>_Workers_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule<Salon>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Friday_Begin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Friday_End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Friday_IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Monday_Begin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Monday_End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Monday_IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Saturday_Begin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Saturday_End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Saturday_IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Sunday_Begin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Sunday_End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Sunday_IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Thursday_Begin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Thursday_End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Thursday_IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Tuesday_Begin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Tuesday_End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Tuesday_IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Wednesday_Begin = table.Column<TimeSpan>(type: "time", nullable: true),
                    Wednesday_End = table.Column<TimeSpan>(type: "time", nullable: true),
                    Wednesday_IsActive = table.Column<bool>(type: "bit", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Schedule<Worker>_EntityId",
                table: "Schedule<Worker>",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityImage<Client>_EntityId",
                table: "EntityImage<Client>",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityImage<Opinion>_EntityId",
                table: "EntityImage<Opinion>",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityImage<Salon>_EntityId",
                table: "EntityImage<Salon>",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntityImage<Worker>_EntityId",
                table: "EntityImage<Worker>",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule<Salon>_EntityId",
                table: "Schedule<Salon>",
                column: "EntityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule<Worker>_Workers_EntityId",
                table: "Schedule<Worker>",
                column: "EntityId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
