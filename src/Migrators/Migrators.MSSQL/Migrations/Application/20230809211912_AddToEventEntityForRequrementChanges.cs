using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class AddToEventEntityForRequrementChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventRegistrationNumber",
                schema: "Event",
                table: "Participants",
                newName: "TicketDownloadLink");

            migrationBuilder.RenameColumn(
                name: "QrCode",
                schema: "Event",
                table: "EventSettings",
                newName: "EventQrCode");

            migrationBuilder.AddColumn<string>(
                name: "TickectReferenceNumber",
                schema: "Event",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TicketQrCode",
                schema: "Event",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_EventSettings_EventId",
                schema: "Event",
                table: "EventSettings",
                column: "EventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSettings_Events_EventId",
                schema: "Event",
                table: "EventSettings",
                column: "EventId",
                principalSchema: "Event",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventSettings_Events_EventId",
                schema: "Event",
                table: "EventSettings");

            migrationBuilder.DropIndex(
                name: "IX_EventSettings_EventId",
                schema: "Event",
                table: "EventSettings");

            migrationBuilder.DropColumn(
                name: "TickectReferenceNumber",
                schema: "Event",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "TicketQrCode",
                schema: "Event",
                table: "Participants");

            migrationBuilder.RenameColumn(
                name: "TicketDownloadLink",
                schema: "Event",
                table: "Participants",
                newName: "EventRegistrationNumber");

            migrationBuilder.RenameColumn(
                name: "EventQrCode",
                schema: "Event",
                table: "EventSettings",
                newName: "QrCode");

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
        }
    }
}
