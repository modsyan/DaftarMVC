using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaftarMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddCartModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MonthlyPrice",
                table: "Teacher",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyPrice",
                table: "Teacher");
        }
    }
}
