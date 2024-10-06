using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdataProdutcPictureTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictures_Products_PictuerId",
                table: "ProductPictures");

            migrationBuilder.DropIndex(
                name: "IX_ProductPictures_PictuerId",
                table: "ProductPictures");

            migrationBuilder.DropColumn(
                name: "PictuerId",
                table: "ProductPictures");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_ProductId",
                table: "ProductPictures",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictures_Products_ProductId",
                table: "ProductPictures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictures_Products_ProductId",
                table: "ProductPictures");

            migrationBuilder.DropIndex(
                name: "IX_ProductPictures_ProductId",
                table: "ProductPictures");

            migrationBuilder.AddColumn<int>(
                name: "PictuerId",
                table: "ProductPictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_PictuerId",
                table: "ProductPictures",
                column: "PictuerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictures_Products_PictuerId",
                table: "ProductPictures",
                column: "PictuerId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
