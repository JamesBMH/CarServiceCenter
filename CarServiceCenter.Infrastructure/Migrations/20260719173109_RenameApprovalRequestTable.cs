using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameApprovalRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequest_Bookings_BookingId",
                table: "ApprovalRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalRequest",
                table: "ApprovalRequest");

            migrationBuilder.RenameTable(
                name: "ApprovalRequest",
                newName: "ApprovalRequests");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalRequest_BookingId",
                table: "ApprovalRequests",
                newName: "IX_ApprovalRequests_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalRequests",
                table: "ApprovalRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequests_Bookings_BookingId",
                table: "ApprovalRequests",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequests_Bookings_BookingId",
                table: "ApprovalRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalRequests",
                table: "ApprovalRequests");

            migrationBuilder.RenameTable(
                name: "ApprovalRequests",
                newName: "ApprovalRequest");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalRequests_BookingId",
                table: "ApprovalRequest",
                newName: "IX_ApprovalRequest_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalRequest",
                table: "ApprovalRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequest_Bookings_BookingId",
                table: "ApprovalRequest",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
