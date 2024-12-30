using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addColorCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$PKR10zvIxRkM5oju9vzkRO5KoG0NzdG1yfHdex8pF4xHH4jIAV6Jy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$eRgQhBpj6dD3wBDyMBOnVOJdN2jxt/PWWhguv5i0gow/3vYuoCyHK");
        }
    }
}
