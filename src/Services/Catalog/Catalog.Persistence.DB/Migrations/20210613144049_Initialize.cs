using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.DB.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 772m },
                    { 73, "Description for product 73", "Product 73", 363m },
                    { 72, "Description for product 72", "Product 72", 455m },
                    { 71, "Description for product 71", "Product 71", 117m },
                    { 70, "Description for product 70", "Product 70", 233m },
                    { 69, "Description for product 69", "Product 69", 281m },
                    { 68, "Description for product 68", "Product 68", 412m },
                    { 67, "Description for product 67", "Product 67", 273m },
                    { 66, "Description for product 66", "Product 66", 642m },
                    { 65, "Description for product 65", "Product 65", 304m },
                    { 64, "Description for product 64", "Product 64", 257m },
                    { 63, "Description for product 63", "Product 63", 751m },
                    { 62, "Description for product 62", "Product 62", 222m },
                    { 61, "Description for product 61", "Product 61", 628m },
                    { 60, "Description for product 60", "Product 60", 846m },
                    { 59, "Description for product 59", "Product 59", 593m },
                    { 58, "Description for product 58", "Product 58", 756m },
                    { 57, "Description for product 57", "Product 57", 813m },
                    { 56, "Description for product 56", "Product 56", 100m },
                    { 55, "Description for product 55", "Product 55", 539m },
                    { 54, "Description for product 54", "Product 54", 389m },
                    { 53, "Description for product 53", "Product 53", 133m },
                    { 74, "Description for product 74", "Product 74", 506m },
                    { 52, "Description for product 52", "Product 52", 712m },
                    { 75, "Description for product 75", "Product 75", 821m },
                    { 77, "Description for product 77", "Product 77", 977m },
                    { 98, "Description for product 98", "Product 98", 637m },
                    { 97, "Description for product 97", "Product 97", 954m },
                    { 96, "Description for product 96", "Product 96", 567m },
                    { 95, "Description for product 95", "Product 95", 995m },
                    { 94, "Description for product 94", "Product 94", 142m },
                    { 93, "Description for product 93", "Product 93", 229m },
                    { 92, "Description for product 92", "Product 92", 266m },
                    { 91, "Description for product 91", "Product 91", 891m },
                    { 90, "Description for product 90", "Product 90", 118m },
                    { 89, "Description for product 89", "Product 89", 213m },
                    { 88, "Description for product 88", "Product 88", 996m },
                    { 87, "Description for product 87", "Product 87", 509m },
                    { 86, "Description for product 86", "Product 86", 118m },
                    { 85, "Description for product 85", "Product 85", 470m },
                    { 84, "Description for product 84", "Product 84", 237m },
                    { 83, "Description for product 83", "Product 83", 186m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 82, "Description for product 82", "Product 82", 159m },
                    { 81, "Description for product 81", "Product 81", 724m },
                    { 80, "Description for product 80", "Product 80", 581m },
                    { 79, "Description for product 79", "Product 79", 323m },
                    { 78, "Description for product 78", "Product 78", 144m },
                    { 76, "Description for product 76", "Product 76", 933m },
                    { 51, "Description for product 51", "Product 51", 355m },
                    { 50, "Description for product 50", "Product 50", 483m },
                    { 49, "Description for product 49", "Product 49", 473m },
                    { 22, "Description for product 22", "Product 22", 772m },
                    { 21, "Description for product 21", "Product 21", 639m },
                    { 20, "Description for product 20", "Product 20", 511m },
                    { 19, "Description for product 19", "Product 19", 130m },
                    { 18, "Description for product 18", "Product 18", 252m },
                    { 17, "Description for product 17", "Product 17", 178m },
                    { 16, "Description for product 16", "Product 16", 940m },
                    { 15, "Description for product 15", "Product 15", 838m },
                    { 14, "Description for product 14", "Product 14", 300m },
                    { 13, "Description for product 13", "Product 13", 965m },
                    { 12, "Description for product 12", "Product 12", 560m },
                    { 11, "Description for product 11", "Product 11", 185m },
                    { 10, "Description for product 10", "Product 10", 934m },
                    { 9, "Description for product 9", "Product 9", 883m },
                    { 8, "Description for product 8", "Product 8", 371m },
                    { 7, "Description for product 7", "Product 7", 682m },
                    { 6, "Description for product 6", "Product 6", 206m },
                    { 5, "Description for product 5", "Product 5", 516m },
                    { 4, "Description for product 4", "Product 4", 204m },
                    { 3, "Description for product 3", "Product 3", 547m },
                    { 2, "Description for product 2", "Product 2", 926m },
                    { 23, "Description for product 23", "Product 23", 213m },
                    { 24, "Description for product 24", "Product 24", 791m },
                    { 25, "Description for product 25", "Product 25", 611m },
                    { 26, "Description for product 26", "Product 26", 669m },
                    { 48, "Description for product 48", "Product 48", 519m },
                    { 47, "Description for product 47", "Product 47", 944m },
                    { 46, "Description for product 46", "Product 46", 129m },
                    { 45, "Description for product 45", "Product 45", 567m },
                    { 44, "Description for product 44", "Product 44", 169m },
                    { 43, "Description for product 43", "Product 43", 794m },
                    { 42, "Description for product 42", "Product 42", 705m },
                    { 41, "Description for product 41", "Product 41", 690m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 40, "Description for product 40", "Product 40", 624m },
                    { 39, "Description for product 39", "Product 39", 889m },
                    { 99, "Description for product 99", "Product 99", 865m },
                    { 38, "Description for product 38", "Product 38", 723m },
                    { 36, "Description for product 36", "Product 36", 704m },
                    { 35, "Description for product 35", "Product 35", 118m },
                    { 34, "Description for product 34", "Product 34", 653m },
                    { 33, "Description for product 33", "Product 33", 386m },
                    { 32, "Description for product 32", "Product 32", 543m },
                    { 31, "Description for product 31", "Product 31", 730m },
                    { 30, "Description for product 30", "Product 30", 726m },
                    { 29, "Description for product 29", "Product 29", 620m },
                    { 28, "Description for product 28", "Product 28", 559m },
                    { 27, "Description for product 27", "Product 27", 578m },
                    { 37, "Description for product 37", "Product 37", 922m },
                    { 100, "Description for product 100", "Product 100", 924m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 14 },
                    { 73, 73, 14 },
                    { 72, 72, 17 },
                    { 71, 71, 4 },
                    { 70, 70, 6 },
                    { 69, 69, 0 },
                    { 68, 68, 9 },
                    { 67, 67, 12 },
                    { 66, 66, 13 },
                    { 65, 65, 8 },
                    { 64, 64, 12 },
                    { 63, 63, 13 },
                    { 62, 62, 13 },
                    { 61, 61, 1 },
                    { 60, 60, 0 },
                    { 59, 59, 16 },
                    { 58, 58, 12 },
                    { 57, 57, 14 },
                    { 56, 56, 0 },
                    { 55, 55, 15 },
                    { 54, 54, 15 },
                    { 53, 53, 6 },
                    { 74, 74, 1 },
                    { 52, 52, 9 },
                    { 75, 75, 1 },
                    { 77, 77, 14 },
                    { 98, 98, 7 },
                    { 97, 97, 12 },
                    { 96, 96, 12 },
                    { 95, 95, 8 },
                    { 94, 94, 2 },
                    { 93, 93, 9 },
                    { 92, 92, 14 },
                    { 91, 91, 19 },
                    { 90, 90, 6 },
                    { 89, 89, 10 },
                    { 88, 88, 7 },
                    { 87, 87, 13 },
                    { 86, 86, 19 },
                    { 85, 85, 9 },
                    { 84, 84, 19 },
                    { 83, 83, 18 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 82, 82, 5 },
                    { 81, 81, 1 },
                    { 80, 80, 3 },
                    { 79, 79, 6 },
                    { 78, 78, 6 },
                    { 76, 76, 17 },
                    { 51, 51, 9 },
                    { 50, 50, 10 },
                    { 49, 49, 3 },
                    { 22, 22, 13 },
                    { 21, 21, 3 },
                    { 20, 20, 8 },
                    { 19, 19, 12 },
                    { 18, 18, 17 },
                    { 17, 17, 3 },
                    { 16, 16, 10 },
                    { 15, 15, 0 },
                    { 14, 14, 6 },
                    { 13, 13, 14 },
                    { 12, 12, 15 },
                    { 11, 11, 13 },
                    { 10, 10, 18 },
                    { 9, 9, 11 },
                    { 8, 8, 3 },
                    { 7, 7, 15 },
                    { 6, 6, 17 },
                    { 5, 5, 15 },
                    { 4, 4, 15 },
                    { 3, 3, 16 },
                    { 2, 2, 7 },
                    { 23, 23, 12 },
                    { 24, 24, 4 },
                    { 25, 25, 19 },
                    { 26, 26, 14 },
                    { 48, 48, 10 },
                    { 47, 47, 12 },
                    { 46, 46, 15 },
                    { 45, 45, 17 },
                    { 44, 44, 5 },
                    { 43, 43, 19 },
                    { 42, 42, 6 },
                    { 41, 41, 6 }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 40, 40, 10 },
                    { 39, 39, 3 },
                    { 99, 99, 17 },
                    { 38, 38, 5 },
                    { 36, 36, 14 },
                    { 35, 35, 6 },
                    { 34, 34, 5 },
                    { 33, 33, 3 },
                    { 32, 32, 0 },
                    { 31, 31, 9 },
                    { 30, 30, 19 },
                    { 29, 29, 9 },
                    { 28, 28, 1 },
                    { 27, 27, 16 },
                    { 37, 37, 6 },
                    { 100, 100, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }

    }
}
