#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddConfigForProtein : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProteinPowder",
                columns: new[] { "Id", "AvailabeQuantity", "Image", "Name", "Price", "ProteinPowderBrands", "QuantityOrder", "ShoppingCartId", "Taste", "TypeOfProtein", "Weight" },
                values: new object[] { 1, 10, "impact_whey_protein.jpg", "Impact Whey Protein", 33.99m, 3, 0, null, "Banana", 0, 1000.0 });

            migrationBuilder.InsertData(
                table: "ProteinPowder",
                columns: new[] { "Id", "AvailabeQuantity", "Image", "Name", "Price", "ProteinPowderBrands", "QuantityOrder", "ShoppingCartId", "Taste", "TypeOfProtein", "Weight" },
                values: new object[] { 2, 10, "bulk_isolate_protein.jpg", "Pure Whey Protein Isolate", 54.99m, 0, 0, null, "Iced Late", 2, 1000.0 });

            migrationBuilder.InsertData(
                table: "ProteinPowder",
                columns: new[] { "Id", "AvailabeQuantity", "Image", "Name", "Price", "ProteinPowderBrands", "QuantityOrder", "ShoppingCartId", "Taste", "TypeOfProtein", "Weight" },
                values: new object[] { 3, 10, "proteinWorks_vegan_protein.jpg", "Vegan Protein", 11.99m, 5, 0, null, "Cookies & Cream", 1, 1000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
