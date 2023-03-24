using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elevator.Api.Migrations
{
    /// <inheritdoc />
    public partial class Updated_DbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elevators_GeoLocation_LocationId",
                table: "Elevators");

            migrationBuilder.DropForeignKey(
                name: "FK_Elevators_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "Elevators");

            migrationBuilder.DropForeignKey(
                name: "FK_Elevators_Operator_OperatorId",
                table: "Elevators");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationChangedEvents_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "OperationChangedEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operator",
                table: "Operator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaDataSourceInfo",
                table: "MetaDataSourceInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeoLocation",
                table: "GeoLocation");

            migrationBuilder.RenameTable(
                name: "Operator",
                newName: "Operators");

            migrationBuilder.RenameTable(
                name: "MetaDataSourceInfo",
                newName: "MetaDataSourceInfos");

            migrationBuilder.RenameTable(
                name: "GeoLocation",
                newName: "GeoLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operators",
                table: "Operators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaDataSourceInfos",
                table: "MetaDataSourceInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeoLocations",
                table: "GeoLocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elevators_GeoLocations_LocationId",
                table: "Elevators",
                column: "LocationId",
                principalTable: "GeoLocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elevators_MetaDataSourceInfos_MetaDataSourceInfoId",
                table: "Elevators",
                column: "MetaDataSourceInfoId",
                principalTable: "MetaDataSourceInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elevators_Operators_OperatorId",
                table: "Elevators",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChangedEvents_MetaDataSourceInfos_MetaDataSourceInfoId",
                table: "OperationChangedEvents",
                column: "MetaDataSourceInfoId",
                principalTable: "MetaDataSourceInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elevators_GeoLocations_LocationId",
                table: "Elevators");

            migrationBuilder.DropForeignKey(
                name: "FK_Elevators_MetaDataSourceInfos_MetaDataSourceInfoId",
                table: "Elevators");

            migrationBuilder.DropForeignKey(
                name: "FK_Elevators_Operators_OperatorId",
                table: "Elevators");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationChangedEvents_MetaDataSourceInfos_MetaDataSourceInfoId",
                table: "OperationChangedEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operators",
                table: "Operators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaDataSourceInfos",
                table: "MetaDataSourceInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeoLocations",
                table: "GeoLocations");

            migrationBuilder.RenameTable(
                name: "Operators",
                newName: "Operator");

            migrationBuilder.RenameTable(
                name: "MetaDataSourceInfos",
                newName: "MetaDataSourceInfo");

            migrationBuilder.RenameTable(
                name: "GeoLocations",
                newName: "GeoLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operator",
                table: "Operator",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaDataSourceInfo",
                table: "MetaDataSourceInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeoLocation",
                table: "GeoLocation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elevators_GeoLocation_LocationId",
                table: "Elevators",
                column: "LocationId",
                principalTable: "GeoLocation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elevators_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "Elevators",
                column: "MetaDataSourceInfoId",
                principalTable: "MetaDataSourceInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elevators_Operator_OperatorId",
                table: "Elevators",
                column: "OperatorId",
                principalTable: "Operator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChangedEvents_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "OperationChangedEvents",
                column: "MetaDataSourceInfoId",
                principalTable: "MetaDataSourceInfo",
                principalColumn: "Id");
        }
    }
}
