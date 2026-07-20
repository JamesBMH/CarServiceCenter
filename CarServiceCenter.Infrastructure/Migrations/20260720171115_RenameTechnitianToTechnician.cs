using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarServiceCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTechnitianToTechnician : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Technitians_TechnitianId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Technitians",
                newName: "Technicians");

            migrationBuilder.RenameColumn(
                name: "TechnitianId",
                table: "Bookings",
                newName: "TechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TechnitianId",
                table: "Bookings",
                newName: "IX_Bookings_TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Technicians_TechnicianId",
                table: "Bookings",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Technicians_TechnicianId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Technicians",
                newName: "Technitians");

            migrationBuilder.RenameColumn(
                name: "TechnicianId",
                table: "Bookings",
                newName: "TechnitianId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TechnicianId",
                table: "Bookings",
                newName: "IX_Bookings_TechnitianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Technitians_TechnitianId",
                table: "Bookings",
                column: "TechnitianId",
                principalTable: "Technitians",
                principalColumn: "Id");
        }
    }
}