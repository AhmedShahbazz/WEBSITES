using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBSITES.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "ExpiryDate" },
                values: new object[] { 12, new DateTime(2026, 7, 21, 19, 56, 13, 621, DateTimeKind.Local).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "ExpiryDate" },
                values: new object[] { 12, new DateTime(2025, 7, 21, 19, 56, 13, 621, DateTimeKind.Local).AddTicks(8159) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "ExpiryDate" },
                values: new object[] { 12, new DateTime(2029, 7, 21, 19, 56, 13, 621, DateTimeKind.Local).AddTicks(8162) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "ExpiryDate" },
                values: new object[] { 12, new DateTime(2027, 7, 21, 19, 56, 13, 621, DateTimeKind.Local).AddTicks(8164) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "ExpiryDate" },
                values: new object[] { 1, new DateTime(2026, 7, 21, 19, 49, 57, 334, DateTimeKind.Local).AddTicks(9019) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "ExpiryDate" },
                values: new object[] { 1, new DateTime(2025, 7, 21, 19, 49, 57, 334, DateTimeKind.Local).AddTicks(9034) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "ExpiryDate" },
                values: new object[] { 2, new DateTime(2029, 7, 21, 19, 49, 57, 334, DateTimeKind.Local).AddTicks(9036) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "ExpiryDate" },
                values: new object[] { 3, new DateTime(2027, 7, 21, 19, 49, 57, 334, DateTimeKind.Local).AddTicks(9037) });
        }
    }
}
