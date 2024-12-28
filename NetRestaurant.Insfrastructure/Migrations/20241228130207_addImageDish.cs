using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addImageDish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$dEeQqo32ZLCBwD1UhJIAm.MxyjEnlLZyQ.Bo20I1seXD/Z8zCRpiW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$Um6MxHlLSpvNsWQXkbYqJOdYYNncRq09T2X6phdLTmiiCHzJDPrgm");
        }
    }
}
