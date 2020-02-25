using Microsoft.EntityFrameworkCore.Migrations;

namespace Csharp_Seat_Booking_System.Migrations
{
    public partial class Initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cart",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cart",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
