using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Migrations
{
    public partial class FlightNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "Classid",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Tickets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "FlightNumberid",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlightNumbers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightNumbers", x => x.id);
                    table.ForeignKey(
                        name: "FK_FlightNumbers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketClasses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketClasses", x => x.id);
                    table.ForeignKey(
                        name: "FK_TicketClasses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Classid",
                table: "Tickets",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FlightNumberid",
                table: "Flights",
                column: "FlightNumberid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightNumbers_UserId",
                table: "FlightNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketClasses_UserId",
                table: "TicketClasses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightNumbers_FlightNumberid",
                table: "Flights",
                column: "FlightNumberid",
                principalTable: "FlightNumbers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketClasses_Classid",
                table: "Tickets",
                column: "Classid",
                principalTable: "TicketClasses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightNumbers_FlightNumberid",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketClasses_Classid",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "FlightNumbers");

            migrationBuilder.DropTable(
                name: "TicketClasses");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Classid",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Flights_FlightNumberid",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Classid",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FlightNumberid",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
