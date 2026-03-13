using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreBookCodeFirstDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddPublisherAndYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "tblBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "tblBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "tblBooks");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "tblBooks");
        }
    }
}
