using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Migrations
{
    public partial class FixFlight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_FlightId1",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_FlightId2",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Flights_FlightId3",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_FlightId1",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_FlightId2",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_FlightId3",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "FlightId1",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "FlightId2",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "FlightId3",
                table: "Seats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId1",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlightId2",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlightId3",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightId1",
                table: "Seats",
                column: "FlightId1");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightId2",
                table: "Seats",
                column: "FlightId2");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightId3",
                table: "Seats",
                column: "FlightId3");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_FlightId1",
                table: "Seats",
                column: "FlightId1",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_FlightId2",
                table: "Seats",
                column: "FlightId2",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Flights_FlightId3",
                table: "Seats",
                column: "FlightId3",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
