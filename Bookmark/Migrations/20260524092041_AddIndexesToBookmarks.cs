using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmark.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexesToBookmarks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookmarkItems_Category",
                table: "BookmarkItems",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_BookmarkItems_Favorite",
                table: "BookmarkItems",
                column: "Favorite");

            migrationBuilder.CreateIndex(
                name: "IX_BookmarkItems_CreatedAt",
                table: "BookmarkItems",
                column: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookmarkItems_Category",
                table: "BookmarkItems");

            migrationBuilder.DropIndex(
                name: "IX_BookmarkItems_Favorite",
                table: "BookmarkItems");

            migrationBuilder.DropIndex(
                name: "IX_BookmarkItems_CreatedAt",
                table: "BookmarkItems");
        }
    }
}
