using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("496d4fef-42d6-48ca-b88c-922c34d653c5"), "5/26/2025 1:02:04 AM", "HR", "HR" },
                    { new Guid("9019ba25-b384-49b4-b855-b88483b53a53"), "5/26/2025 1:02:03 AM", "Admin", "ADMIN" },
                    { new Guid("933c72c6-10e8-4d68-9e3c-7063bac3b58c"), "5/26/2025 1:02:05 AM", "Author", "AUTHOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("496d4fef-42d6-48ca-b88c-922c34d653c5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9019ba25-b384-49b4-b855-b88483b53a53"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("933c72c6-10e8-4d68-9e3c-7063bac3b58c"));
        }
    }
}
