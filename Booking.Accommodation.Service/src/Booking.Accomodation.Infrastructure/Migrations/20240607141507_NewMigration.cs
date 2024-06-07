using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.AccommodationNS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "AccomodationId",
                schema: "accomodaton",
                table: "Reservation",
                newName: "AccommodationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_AccomodationId",
                schema: "accomodaton",
                table: "Reservation",
                newName: "IX_Reservation_AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Accommodation_AccommodationId",
                schema: "accomodaton",
                table: "Reservation",
                column: "AccommodationId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Accommodation_AccommodationId",
                schema: "accomodaton",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "AccommodationId",
                schema: "accomodaton",
                table: "Reservation",
                newName: "AccomodationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_AccommodationId",
                schema: "accomodaton",
                table: "Reservation",
                newName: "IX_Reservation_AccomodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "Reservation",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
