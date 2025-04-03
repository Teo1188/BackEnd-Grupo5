using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtraHours.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExtraHourTypeConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraHours_ExtraHourTypes_ExtraHourTypeId",
                table: "ExtraHours");

            migrationBuilder.DropColumn(
                name: "RateMultiplier",
                table: "ExtraHourTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ExtraHourTypes",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExtraHourTypes",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ExtraHourTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraHours_ExtraHourTypes_ExtraHourTypeId",
                table: "ExtraHours",
                column: "ExtraHourTypeId",
                principalTable: "ExtraHourTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraHours_ExtraHourTypes_ExtraHourTypeId",
                table: "ExtraHours");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ExtraHourTypes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExtraHourTypes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ExtraHourTypes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<decimal>(
                name: "RateMultiplier",
                table: "ExtraHourTypes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraHours_ExtraHourTypes_ExtraHourTypeId",
                table: "ExtraHours",
                column: "ExtraHourTypeId",
                principalTable: "ExtraHourTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
