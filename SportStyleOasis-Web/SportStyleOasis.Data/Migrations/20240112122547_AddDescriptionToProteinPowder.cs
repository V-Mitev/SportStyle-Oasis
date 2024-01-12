#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddDescriptionToProteinPowder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProteinPowder",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Test description about protein powder");

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Test description about protein powder");

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Test description about protein powder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProteinPowder");
        }
    }
}
