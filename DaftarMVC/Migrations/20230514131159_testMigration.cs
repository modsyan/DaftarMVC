using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaftarMVC.Migrations
{
    /// <inheritdoc />
    public partial class testMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgae",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "UserLikesId",
                table: "Favorites",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Favorites",
                newName: "UserLikesId");

            migrationBuilder.AddColumn<string>(
                name: "imgae",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
