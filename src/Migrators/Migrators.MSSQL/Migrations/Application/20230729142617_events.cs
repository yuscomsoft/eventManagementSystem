using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "Group",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.EnsureSchema(
                name: "Event");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Catalog",
                newName: "Products",
                newSchema: "Event");

            migrationBuilder.RenameTable(
                name: "Brands",
                schema: "Catalog",
                newName: "Brands",
                newSchema: "Event");

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventYear = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventSettings",
                schema: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QrCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    IsRegistrationActive = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "Event",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                schema: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParticipantType = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tiltle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckedIn = table.Column<bool>(type: "bit", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "Event",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentResponses",
                schema: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentResponses_Comments_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "Event",
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentResponses_CommentId",
                schema: "Event",
                table: "CommentResponses",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventId",
                schema: "Event",
                table: "Comments",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventName",
                schema: "Event",
                table: "Events",
                column: "EventName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_EventId",
                schema: "Event",
                table: "Participants",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentResponses",
                schema: "Event");

            migrationBuilder.DropTable(
                name: "EventSettings",
                schema: "Event");

            migrationBuilder.DropTable(
                name: "Participants",
                schema: "Event");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "Event");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "Event");

            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Event",
                newName: "Products",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Brands",
                schema: "Event",
                newName: "Brands",
                newSchema: "Catalog");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Identity",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                schema: "Identity",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                schema: "Identity",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                schema: "Identity",
                table: "RoleClaims",
                type: "datetime2",
                nullable: true);
        }
    }
}
