using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elevator.Api.Migrations
{
    /// <inheritdoc />
    public partial class Added_MetaDataInfo_OpChEv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MetaDataSourceInfoId",
                table: "OperationChangeEvent",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationChangeEvent_MetaDataSourceInfoId",
                table: "OperationChangeEvent",
                column: "MetaDataSourceInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChangeEvent_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "OperationChangeEvent",
                column: "MetaDataSourceInfoId",
                principalTable: "MetaDataSourceInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationChangeEvent_MetaDataSourceInfo_MetaDataSourceInfoId",
                table: "OperationChangeEvent");

            migrationBuilder.DropIndex(
                name: "IX_OperationChangeEvent_MetaDataSourceInfoId",
                table: "OperationChangeEvent");

            migrationBuilder.DropColumn(
                name: "MetaDataSourceInfoId",
                table: "OperationChangeEvent");
        }
    }
}
