using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elevator.Api.Migrations
{
    /// <inheritdoc />
    public partial class Added_PlannedMaintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elevators",
                keyColumn: "Id",
                keyValue: new Guid("b1a0e7f4-14fe-4919-8705-105d8b3844be"));

            migrationBuilder.CreateTable(
                name: "PlannedMaintenances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: true),
                    ExpectedOperationStatus = table.Column<string>(type: "TEXT", nullable: true),
                    ElevatorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedMaintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedMaintenances_Elevators_ElevatorId",
                        column: x => x.ElevatorId,
                        principalTable: "Elevators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Elevators",
                columns: new[] { "Id", "LocationId", "ManufacturerName", "MetaDataSourceInfoId", "OpenStreetMapId", "OperatorId", "Properties", "SerialNumber" },
                values: new object[] { new Guid("3ecc6e8e-fb6e-45ff-9d59-49d250882ba0"), null, "Bosch", null, null, null, "{}", "A-1732-B-" });

            migrationBuilder.CreateIndex(
                name: "IX_PlannedMaintenances_ElevatorId",
                table: "PlannedMaintenances",
                column: "ElevatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlannedMaintenances");

            migrationBuilder.DeleteData(
                table: "Elevators",
                keyColumn: "Id",
                keyValue: new Guid("3ecc6e8e-fb6e-45ff-9d59-49d250882ba0"));

            migrationBuilder.InsertData(
                table: "Elevators",
                columns: new[] { "Id", "LocationId", "ManufacturerName", "MetaDataSourceInfoId", "OpenStreetMapId", "OperatorId", "Properties", "SerialNumber" },
                values: new object[] { new Guid("b1a0e7f4-14fe-4919-8705-105d8b3844be"), null, "Bosch", null, null, null, "{}", "A-1732-B-" });
        }
    }
}
