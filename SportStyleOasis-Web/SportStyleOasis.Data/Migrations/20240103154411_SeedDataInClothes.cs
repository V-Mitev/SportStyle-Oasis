#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SeedDataInClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "AvailabeQuantity", "Color", "Image", "Name", "Price", "QuantityOrder", "ShoppingCartId", "Size", "TypeOfClothes" },
                values: new object[] { 1, 10, "Gray", "gray_tshirt.jpg", "T-shirt-Gray", 13.99m, 0, null, 2, 0 });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "AvailabeQuantity", "Color", "Image", "Name", "Price", "QuantityOrder", "ShoppingCartId", "Size", "TypeOfClothes" },
                values: new object[] { 2, 10, "Black", "black_tshirt.jpg", "T-shirt-Black", 9.99m, 0, null, 3, 0 });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "AvailabeQuantity", "Color", "Image", "Name", "Price", "QuantityOrder", "ShoppingCartId", "Size", "TypeOfClothes" },
                values: new object[] { 3, 10, "White", "white_tshirt.jpg", "T-shirt-White", 10.99m, 0, null, 4, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
