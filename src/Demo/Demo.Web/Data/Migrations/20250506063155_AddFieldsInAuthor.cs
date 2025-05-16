using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsInAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Authors");
        }
    }
}
