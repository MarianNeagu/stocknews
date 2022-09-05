using Microsoft.EntityFrameworkCore.Migrations;

namespace StockNews.Migrations
{
    public partial class ChangedNewsSavedNewsToOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SavedNews_NewsId",
                table: "SavedNews");

            migrationBuilder.CreateIndex(
                name: "IX_SavedNews_NewsId",
                table: "SavedNews",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SavedNews_NewsId",
                table: "SavedNews");

            migrationBuilder.CreateIndex(
                name: "IX_SavedNews_NewsId",
                table: "SavedNews",
                column: "NewsId",
                unique: true,
                filter: "[NewsId] IS NOT NULL");
        }
    }
}
