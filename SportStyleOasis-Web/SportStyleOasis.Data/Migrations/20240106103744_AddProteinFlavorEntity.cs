#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddProteinFlavorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AvailabeQuantity",
                table: "ProteinPowder");

            migrationBuilder.DropColumn(
                name: "QuantityOrder",
                table: "ProteinPowder");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "ProteinPowder");

            migrationBuilder.DropColumn(
                name: "QuantityOrder",
                table: "Clothes");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "ProteinPowder",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "ProteinFlavor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlavorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProteinId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinFlavor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProteinFlavor_ProteinPowder_ProteinId",
                        column: x => x.ProteinId,
                        principalTable: "ProteinPowder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProteinFlavor_ProteinId",
                table: "ProteinFlavor",
                column: "ProteinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProteinFlavor");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "ProteinPowder",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AvailabeQuantity",
                table: "ProteinPowder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityOrder",
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
                name: "QuantityOrder",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
