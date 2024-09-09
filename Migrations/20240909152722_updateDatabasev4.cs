using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMarketService.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabasev4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "orderItems",
                newName: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ProductID",
                table: "orderItems",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_products_ProductID",
                table: "orderItems",
                column: "ProductID",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_products_ProductID",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_ProductID",
                table: "orderItems");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "orderItems",
                newName: "PizzaId");
        }
    }
}
