using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$Um6MxHlLSpvNsWQXkbYqJOdYYNncRq09T2X6phdLTmiiCHzJDPrgm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$9WS/zBlXUJjDg99SG7AjsOfWdrOENL/dcYj4xliqgCZof6/1CiJYC");
        }
    }
}
