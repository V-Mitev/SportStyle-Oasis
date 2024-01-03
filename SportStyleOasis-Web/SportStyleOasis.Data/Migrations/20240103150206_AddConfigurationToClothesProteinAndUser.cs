using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    public partial class AddConfigurationToClothesProteinAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Clothes_ClothesId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ProteinPowder_ProteinPowderId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingCartId",
                table: "AspNetUsers",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingCarts_ShoppingCartId",
                table: "AspNetUsers",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Clothes_ClothesId",
                table: "Review",
                column: "ClothesId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ProteinPowder_ProteinPowderId",
                table: "Review",
                column: "ProteinPowderId",
                principalTable: "ProteinPowder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCarts_ShoppingCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Clothes_ClothesId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ProteinPowder_ProteinPowderId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShoppingCartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Clothes_ClothesId",
                table: "Review",
                column: "ClothesId",
                principalTable: "Clothes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ProteinPowder_ProteinPowderId",
                table: "Review",
                column: "ProteinPowderId",
                principalTable: "ProteinPowder",
                principalColumn: "Id");
        }
    }
}
