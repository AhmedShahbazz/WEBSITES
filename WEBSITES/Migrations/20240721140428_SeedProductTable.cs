using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBSITES.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2026, 7, 21, 19, 4, 26, 920, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 7, 21, 19, 4, 26, 920, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2029, 7, 21, 19, 4, 26, 920, DateTimeKind.Local).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2027, 7, 21, 19, 4, 26, 920, DateTimeKind.Local).AddTicks(837));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2026, 7, 21, 19, 0, 47, 692, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 7, 21, 19, 0, 47, 692, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2029, 7, 21, 19, 0, 47, 692, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2027, 7, 21, 19, 0, 47, 692, DateTimeKind.Local).AddTicks(1596));
        }
    }
}
