using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Infra.Data.Sql.Commands.Migrations
{
    /// <inheritdoc />
    public partial class changedeletebehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsCategoryMapping_Categories_CategoryId",
                table: "NewsCategoryMapping");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCategoryMapping_Categories_CategoryId",
                table: "NewsCategoryMapping",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsCategoryMapping_Categories_CategoryId",
                table: "NewsCategoryMapping");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCategoryMapping_Categories_CategoryId",
                table: "NewsCategoryMapping",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
