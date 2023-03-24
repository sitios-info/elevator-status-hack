using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elevator.Api.Migrations
{
    /// <inheritdoc />
    public partial class Added_Elevator_OpChEv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationChangeEvent_Elevators_ElevatorId",
                table: "OperationChangeEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationChangeEvent_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "OperationChangeEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationChangeEvent",
                table: "OperationChangeEvent");

            migrationBuilder.RenameTable(
                name: "OperationChangeEvent",
                newName: "OperationChangedEvents");

            migrationBuilder.RenameIndex(
                name: "IX_OperationChangeEvent_MetaDataSourceInfoId",
                table: "OperationChangedEvents",
                newName: "IX_OperationChangedEvents_MetaDataSourceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_OperationChangeEvent_ElevatorId",
                table: "OperationChangedEvents",
                newName: "IX_OperationChangedEvents_ElevatorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ElevatorId",
                table: "OperationChangedEvents",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationChangedEvents",
                table: "OperationChangedEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChangedEvents_Elevators_ElevatorId",
                table: "OperationChangedEvents",
                column: "ElevatorId",
                principalTable: "Elevators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChangedEvents_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "OperationChangedEvents",
                column: "MetaDataSourceInfoId",
                principalTable: "MetaDataSourceInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationChangedEvents_Elevators_ElevatorId",
                table: "OperationChangedEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationChangedEvents_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "OperationChangedEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationChangedEvents",
                table: "OperationChangedEvents");

            migrationBuilder.RenameTable(
                name: "OperationChangedEvents",
                newName: "OperationChangeEvent");

            migrationBuilder.RenameIndex(
                name: "IX_OperationChangedEvents_MetaDataSourceInfoId",
                table: "OperationChangeEvent",
                newName: "IX_OperationChangeEvent_MetaDataSourceInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_OperationChangedEvents_ElevatorId",
                table: "OperationChangeEvent",
                newName: "IX_OperationChangeEvent_ElevatorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ElevatorId",
                table: "OperationChangeEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationChangeEvent",
                table: "OperationChangeEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChangeEvent_Elevators_ElevatorId",
                table: "OperationChangeEvent",
                column: "ElevatorId",
                principalTable: "Elevators",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChangeEvent_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "OperationChangeEvent",
                column: "MetaDataSourceInfoId",
                principalTable: "MetaDataSourceInfo",
                principalColumn: "Id");
        }
    }
}
