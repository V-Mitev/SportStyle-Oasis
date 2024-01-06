#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SeedNewProteinAndProteinFlavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProteinPowder",
                columns: new[] { "Id", "Image", "Name", "Price", "ProteinPowderBrands", "ShoppingCartId", "TypeOfProtein", "Weight" },
                values: new object[] { 1, "impact_whey_protein.jpg", "Impact Whey Protein", 33.99m, 3, null, 0, 1000 });

            migrationBuilder.InsertData(
                table: "ProteinPowder",
                columns: new[] { "Id", "Image", "Name", "Price", "ProteinPowderBrands", "ShoppingCartId", "TypeOfProtein", "Weight" },
                values: new object[] { 2, "bulk_isolate_protein.jpg", "Pure Whey Protein Isolate", 54.99m, 0, null, 2, 1000 });

            migrationBuilder.InsertData(
                table: "ProteinPowder",
                columns: new[] { "Id", "Image", "Name", "Price", "ProteinPowderBrands", "ShoppingCartId", "TypeOfProtein", "Weight" },
                values: new object[] { 3, "proteinWorks_vegan_protein.jpg", "Vegan Protein", 11.99m, 5, null, 1, 1000 });

            migrationBuilder.InsertData(
                table: "ProteinFlavor",
                columns: new[] { "Id", "FlavorName", "ProteinId", "Quantity" },
                values: new object[,]
                {
                    { 1, "Iced Late", 2, 10 },
                    { 2, "Salted Caramel", 2, 10 },
                    { 3, "Pistachio Ice Cream", 2, 10 },
                    { 4, "Banana", 1, 10 },
                    { 5, "Cookies & Cream", 3, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProteinFlavor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProteinFlavor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProteinFlavor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProteinFlavor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProteinFlavor",
                keyColumn: "Id",
                keyValue: 5);

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
