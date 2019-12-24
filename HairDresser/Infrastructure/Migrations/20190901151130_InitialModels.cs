using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdminId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_HouseNumber = table.Column<int>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Schedule_Monday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Monday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Tuesday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Tuesday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Wednesday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Wednesday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Thursday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Thursday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Friday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Friday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Saturday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Saturday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Sunday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Sunday_End = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salons_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityImage<Client>",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    ImageData = table.Column<byte[]>(nullable: true)
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
                name: "ClientSalons",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    SalonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSalons", x => new { x.ClientId, x.SalonId });
                    table.ForeignKey(
                        name: "FK_ClientSalons_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientSalons_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityImage<Salon>",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    ImageData = table.Column<byte[]>(nullable: true)
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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    SalonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    SalonId = table.Column<Guid>(nullable: false),
                    Schedule_Monday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Monday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Tuesday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Tuesday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Wednesday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Wednesday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Thursday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Thursday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Friday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Friday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Saturday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Saturday_End = table.Column<TimeSpan>(nullable: true),
                    Schedule_Sunday_Begin = table.Column<TimeSpan>(nullable: true),
                    Schedule_Sunday_End = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityImage<Worker>",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    ImageData = table.Column<byte[]>(nullable: true)
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
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    WorkerId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Rate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opinions_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    WorkerId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Term = table.Column<DateTime>(nullable: false),
                    TotalTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerServices",
                columns: table => new
                {
                    WorkerId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerServices", x => new { x.WorkerId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_WorkerServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerServices_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EntityImage<Opinion>",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EntityId = table.Column<Guid>(nullable: false),
                    ImageData = table.Column<byte[]>(nullable: true)
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
                name: "VisitServices",
                columns: table => new
                {
                    VisitId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitServices", x => new { x.VisitId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_VisitServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitServices_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSalons_SalonId",
                table: "ClientSalons",
                column: "SalonId");

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
                name: "IX_Opinions_ClientId",
                table: "Opinions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_WorkerId",
                table: "Opinions",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_AdminId",
                table: "Salons",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SalonId",
                table: "Services",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ClientId",
                table: "Visits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_WorkerId",
                table: "Visits",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitServices_ServiceId",
                table: "VisitServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_SalonId",
                table: "Workers",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerServices_ServiceId",
                table: "WorkerServices",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientSalons");

            migrationBuilder.DropTable(
                name: "EntityImage<Client>");

            migrationBuilder.DropTable(
                name: "EntityImage<Opinion>");

            migrationBuilder.DropTable(
                name: "EntityImage<Salon>");

            migrationBuilder.DropTable(
                name: "EntityImage<Worker>");

            migrationBuilder.DropTable(
                name: "VisitServices");

            migrationBuilder.DropTable(
                name: "WorkerServices");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Salons");
        }
    }
}
