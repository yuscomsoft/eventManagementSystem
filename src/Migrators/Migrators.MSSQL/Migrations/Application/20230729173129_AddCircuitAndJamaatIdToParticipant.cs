using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class AddCircuitAndJamaatIdToParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CircuitId",
                schema: "Event",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JamaatId",
                schema: "Event",
                table: "Participants",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CircuitId",
                schema: "Event",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "JamaatId",
                schema: "Event",
                table: "Participants");
        }
    }
}
