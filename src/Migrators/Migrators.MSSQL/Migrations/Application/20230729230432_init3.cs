using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "Event",
                table: "EventSettings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationStartDate",
                schema: "Event",
                table: "EventSettings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationEndDate",
                schema: "Event",
                table: "EventSettings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckInStartDate",
                schema: "Event",
                table: "EventSettings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "EventSettingsId",
                schema: "Event",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventSettingsId",
                schema: "Event",
                table: "Events",
                column: "EventSettingsId",
                unique: true,
                filter: "[EventSettingsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventSettings_EventSettingsId",
                schema: "Event",
                table: "Events",
                column: "EventSettingsId",
                principalSchema: "Event",
                principalTable: "EventSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventSettings_EventSettingsId",
                schema: "Event",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventSettingsId",
                schema: "Event",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventSettingsId",
                schema: "Event",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationStartDate",
                schema: "Event",
                table: "EventSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationEndDate",
                schema: "Event",
                table: "EventSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckInStartDate",
                schema: "Event",
                table: "EventSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                schema: "Event",
                table: "EventSettings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
