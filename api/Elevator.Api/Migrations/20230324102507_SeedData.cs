using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elevator.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Elevators",
                columns: new[] { "Id", "LocationId", "ManufacturerName", "MetaDataSourceInfoId", "OpenStreetMapId", "OperatorId", "Properties", "SerialNumber" },
                values: new object[] { new Guid("b1a0e7f4-14fe-4919-8705-105d8b3844be"), null, "Bosch", null, null, null, "{}", "A-1732-B-" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elevators",
                keyColumn: "Id",
                keyValue: new Guid("b1a0e7f4-14fe-4919-8705-105d8b3844be"));
        }
    }
}
