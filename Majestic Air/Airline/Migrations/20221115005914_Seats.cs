using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Migrations
{
    public partial class Seats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketClasses_Classid",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetailsTemp");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "Classid",
                table: "Tickets",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Classid",
                table: "Tickets",
                newName: "IX_Tickets_ClassId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TicketClasses",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClasseId = table.Column<int>(type: "int", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    FlightId1 = table.Column<int>(type: "int", nullable: true),
                    FlightId2 = table.Column<int>(type: "int", nullable: true),
                    FlightId3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_Flights_FlightId1",
                        column: x => x.FlightId1,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_Flights_FlightId2",
                        column: x => x.FlightId2,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_Flights_FlightId3",
                        column: x => x.FlightId3,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_TicketClasses_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "TicketClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ClasseId",
                table: "Seats",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightId",
                table: "Seats",
                column: "FlightId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Seats_UserId",
                table: "Seats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketClasses_ClassId",
                table: "Tickets",
                column: "ClassId",
                principalTable: "TicketClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketClasses_ClassId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Tickets",
                newName: "Classid");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ClassId",
                table: "Tickets",
                newName: "IX_Tickets_Classid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TicketClasses",
                newName: "id");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "OrderDetailsTemp",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketClasses_Classid",
                table: "Tickets",
                column: "Classid",
                principalTable: "TicketClasses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
