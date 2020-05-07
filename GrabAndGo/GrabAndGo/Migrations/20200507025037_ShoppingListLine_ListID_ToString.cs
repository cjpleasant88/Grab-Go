using Microsoft.EntityFrameworkCore.Migrations;

namespace GrabAndGo.Migrations
{
    public partial class ShoppingListLine_ListID_ToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ListID",
                table: "ShoppingListLine",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 1,
                column: "ListID",
                value: "1");

            migrationBuilder.UpdateData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 2,
                column: "ListID",
                value: "2");

            migrationBuilder.UpdateData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 3,
                column: "ListID",
                value: "2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ListID",
                table: "ShoppingListLine",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 1,
                column: "ListID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 2,
                column: "ListID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 3,
                column: "ListID",
                value: 2);
        }
    }
}
