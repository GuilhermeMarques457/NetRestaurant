using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "IsAdmin", "Name", "Password" },
                values: new object[] { 1L, "", "admin@example.com", true, "Admin", "$2a$11$9WS/zBlXUJjDg99SG7AjsOfWdrOENL/dcYj4xliqgCZof6/1CiJYC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
