using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMarketService.Migrations
{
    /// <inheritdoc />
    public partial class editFastfoodModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fastfoods_categories_CategoryId",
                table: "fastfoods");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "categories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "fastfoods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_fastfoods_categories_CategoryId",
                table: "fastfoods",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fastfoods_categories_CategoryId",
                table: "fastfoods");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "fastfoods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fastfoods_categories_CategoryId",
                table: "fastfoods",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
