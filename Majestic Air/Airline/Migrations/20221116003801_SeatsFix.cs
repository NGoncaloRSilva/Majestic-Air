using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Migrations
{
    public partial class SeatsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_FlightId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Seats",
                newName: "FlightNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_FlightId",
                table: "Seats",
                newName: "IX_Seats_FlightNameId");

            migrationBuilder.AddColumn<string>(
                name: "Seat",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_FlightNameId",
                table: "Seats",
                column: "FlightNameId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_FlightNameId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "FlightNameId",
                table: "Seats",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_FlightNameId",
                table: "Seats",
                newName: "IX_Seats_FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_FlightId",
                table: "Seats",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
