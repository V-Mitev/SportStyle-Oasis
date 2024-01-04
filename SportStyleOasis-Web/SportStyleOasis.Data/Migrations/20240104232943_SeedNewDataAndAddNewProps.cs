#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SeedNewDataAndAddNewProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProteinPowderBrands",
                table: "ProteinPowder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Taste",
                table: "ProteinPowder",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClothesBrands",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClothesForGender",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clothes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "This is test description about this tshirt");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClothesBrands", "Description" },
                values: new object[] { 3, "This is test description about this tshirt" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClothesBrands", "ClothesForGender", "Description" },
                values: new object[] { 1, 1, "This is test description about this tshirt" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProteinPowderBrands",
                table: "ProteinPowder");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "ProteinPowder");

            migrationBuilder.DropColumn(
                name: "ClothesBrands",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "ClothesForGender",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clothes");
        }
    }
}
