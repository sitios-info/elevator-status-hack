using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elevator.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    OpenStreetMaPlaceId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AddressText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaDataSourceInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    License = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SourceType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDataSourceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ContactPhone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elevators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OpenStreetMapId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: false),
                    LocationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ManufacturerName = table.Column<string>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OperatorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MetaDataSourceInfoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elevators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elevators_GeoLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "GeoLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elevators_MetaDataSourceInfo_MetaDataSourceInfoId",
                        column: x => x.MetaDataSourceInfoId,
                        principalTable: "MetaDataSourceInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Elevators_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperationChangeEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChangedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    OperationMode = table.Column<string>(type: "TEXT", nullable: false),
                    ElevatorId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationChangeEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationChangeEvent_Elevators_ElevatorId",
                        column: x => x.ElevatorId,
                        principalTable: "Elevators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elevators_LocationId",
                table: "Elevators",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Elevators_MetaDataSourceInfoId",
                table: "Elevators",
                column: "MetaDataSourceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Elevators_OperatorId",
                table: "Elevators",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationChangeEvent_ElevatorId",
                table: "OperationChangeEvent",
                column: "ElevatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationChangeEvent");

            migrationBuilder.DropTable(
                name: "Elevators");

            migrationBuilder.DropTable(
                name: "GeoLocation");

            migrationBuilder.DropTable(
                name: "MetaDataSourceInfo");

            migrationBuilder.DropTable(
                name: "Operator");
        }
    }
}
