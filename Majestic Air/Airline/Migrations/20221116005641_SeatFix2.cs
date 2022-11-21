using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Migrations
{
    public partial class SeatFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_FlightNameId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_FlightNameId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "FlightNameId",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightId",
                table: "Seats",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_FlightId",
                table: "Seats",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_FlightId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_FlightId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "FlightNameId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightNameId",
                table: "Seats",
                column: "FlightNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_FlightNameId",
                table: "Seats",
                column: "FlightNameId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
