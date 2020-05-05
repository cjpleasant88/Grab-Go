using Microsoft.EntityFrameworkCore.Migrations;

namespace GrabAndGo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aisle",
                columns: table => new
                {
                    AisleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreID = table.Column<int>(nullable: false),
                    AisleNumber = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aisle", x => x.AisleID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListLine",
                columns: table => new
                {
                    ShoppingListLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListLine", x => x.ShoppingListLineID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ListID = table.Column<int>(nullable: false),
                    ListName = table.Column<string>(nullable: true),
                    StorePref = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

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
                columns: new[] { "ShoppingListLineID", "ListID", "ProductID", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, "Milk", 2 },
                    { 2, 2, 2, "Bread", 3 },
                    { 3, 2, 3, "Eggs", 12 }
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aisle");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShoppingListLine");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
