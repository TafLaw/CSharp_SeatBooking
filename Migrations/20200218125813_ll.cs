using Microsoft.EntityFrameworkCore.Migrations;

namespace Csharp_Seat_Booking_System.Migrations
{
    public partial class ll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "Cart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "ShoppingCart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");
        }
    }
}
