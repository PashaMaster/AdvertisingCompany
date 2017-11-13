using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdvertisingCompany.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalServises",
                columns: table => new
                {
                    AdditionalServiseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscriptionAdditionalServise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAdditionalServise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServises", x => x.AdditionalServiseID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "ResponsibleOfficers",
                columns: table => new
                {
                    ResponsibleOfficerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameResponsibleOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsibleOfficers", x => x.ResponsibleOfficerID);
                });

            migrationBuilder.CreateTable(
                name: "TypeAdvertisings",
                columns: table => new
                {
                    TypeAdvertisingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscriptionTypeAdvertising = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameTypeAdvertising = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAdvertisings", x => x.TypeAdvertisingID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalServiseID = table.Column<int>(type: "int", nullable: false),
                    LocationT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeAdvertisingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_AdditionalServises_AdditionalServiseID",
                        column: x => x.AdditionalServiseID,
                        principalTable: "AdditionalServises",
                        principalColumn: "AdditionalServiseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_TypeAdvertisings_TypeAdvertisingID",
                        column: x => x.TypeAdvertisingID,
                        principalTable: "TypeAdvertisings",
                        principalColumn: "TypeAdvertisingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    PaymentNote = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ResponsibleOfficerID = table.Column<int>(type: "int", nullable: false),
                    Servise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ResponsibleOfficers_ResponsibleOfficerID",
                        column: x => x.ResponsibleOfficerID,
                        principalTable: "ResponsibleOfficers",
                        principalColumn: "ResponsibleOfficerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AdditionalServiseID",
                table: "Locations",
                column: "AdditionalServiseID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TypeAdvertisingID",
                table: "Locations",
                column: "TypeAdvertisingID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientID",
                table: "Orders",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationID",
                table: "Orders",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ResponsibleOfficerID",
                table: "Orders",
                column: "ResponsibleOfficerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ResponsibleOfficers");

            migrationBuilder.DropTable(
                name: "AdditionalServises");

            migrationBuilder.DropTable(
                name: "TypeAdvertisings");
        }
    }
}
