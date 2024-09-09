using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMarketService.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabasev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_fastfoods_ProductId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_fastfoods_ProductId",
                table: "ProductIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fastfoods",
                table: "fastfoods");

            migrationBuilder.RenameTable(
                name: "fastfoods",
                newName: "products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_products_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_products_ProductId",
                table: "ProductIngredients",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_products_ProductId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductIngredients_products_ProductId",
                table: "ProductIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "fastfoods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fastfoods",
                table: "fastfoods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_fastfoods_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "fastfoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIngredients_fastfoods_ProductId",
                table: "ProductIngredients",
                column: "ProductId",
                principalTable: "fastfoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
