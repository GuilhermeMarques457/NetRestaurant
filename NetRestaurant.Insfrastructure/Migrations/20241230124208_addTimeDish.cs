using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTimeDish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "MaximunTime",
                table: "Dishes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MinimunTime",
                table: "Dishes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$eRgQhBpj6dD3wBDyMBOnVOJdN2jxt/PWWhguv5i0gow/3vYuoCyHK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximunTime",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MinimunTime",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$dEeQqo32ZLCBwD1UhJIAm.MxyjEnlLZyQ.Bo20I1seXD/Z8zCRpiW");
        }
    }
}
