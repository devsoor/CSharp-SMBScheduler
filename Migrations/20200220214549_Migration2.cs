using Microsoft.EntityFrameworkCore.Migrations;

namespace massage.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeslotId",
                table: "Reservation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TimeslotId",
                table: "Reservation",
                column: "TimeslotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Timeslot_TimeslotId",
                table: "Reservation",
                column: "TimeslotId",
                principalTable: "Timeslot",
                principalColumn: "TimeslotId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Timeslot_TimeslotId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_TimeslotId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "TimeslotId",
                table: "Reservation");
        }
    }
}
