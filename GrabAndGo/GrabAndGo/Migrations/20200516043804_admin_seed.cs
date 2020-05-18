using Microsoft.EntityFrameworkCore.Migrations;

namespace GrabAndGo.Migrations
{
    public partial class admin_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aisle",
                keyColumn: "AisleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aisle",
                keyColumn: "AisleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aisle",
                keyColumn: "AisleID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoppingListLine",
                keyColumn: "ShoppingListLineID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "StoreID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsAtStore",
                table: "ShoppingListLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAtStore",
                table: "ShoppingListLine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Aisle",
                columns: new[] { "AisleID", "AisleNumber", "CategoryID", "StoreID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 3, 1 },
                    { 3, 1, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Dairy" },
                    { 2, "Bakery" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "CategoryID", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "Milk" },
                    { 2, 2, "Bread" },
                    { 3, 3, "Eggs" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingListLine",
                columns: new[] { "ShoppingListLineID", "IsAtStore", "ListID", "ProductID", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, false, "1", 1, "Milk", 2 },
                    { 2, false, "2", 2, "Bread", 3 },
                    { 3, false, "2", 3, "Eggs", 12 }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreID", "City", "State", "StoreName", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Ocenaside", "CA", "Target", "123 BeachTime", 12345 },
                    { 2, "Vista", "CA", "Ralphs", "456 ImHungry", 98765 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "LastName", "ListID", "ListName", "Password", "StorePref" },
                values: new object[,]
                {
                    { 1, "test123@456.com", "Test User", "Test Last", 123, "Test List", "superSecret", 1 },
                    { 2, "john@grabandgo.com", "John", "Smith", 3, "John's List", "johnnyrocks", 2 }
                });
        }
    }
}
