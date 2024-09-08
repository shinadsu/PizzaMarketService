using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMarketService.Migrations
{
    /// <inheritdoc />
    public partial class editFastfoodModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fastfoods_categories_CategoryId",
                table: "fastfoods");

            migrationBuilder.DropIndex(
                name: "IX_fastfoods_CategoryId",
                table: "fastfoods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "fastfoods");

            migrationBuilder.AddColumn<int>(
                name: "FastfoodId",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_FastfoodId",
                table: "categories",
                column: "FastfoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_fastfoods_FastfoodId",
                table: "categories",
                column: "FastfoodId",
                principalTable: "fastfoods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_fastfoods_FastfoodId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_FastfoodId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "FastfoodId",
                table: "categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "fastfoods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fastfoods_CategoryId",
                table: "fastfoods",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_fastfoods_categories_CategoryId",
                table: "fastfoods",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
