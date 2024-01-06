#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ShoppingCarts_ShoppingCartId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProteinPowder_ShoppingCarts_ShoppingCartId",
                table: "ProteinPowder");

            migrationBuilder.DropIndex(
                name: "IX_ProteinPowder_ShoppingCartId",
                table: "ProteinPowder");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_ShoppingCartId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ProteinPowder");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Clothes");

            migrationBuilder.CreateTable(
                name: "ClothesShoppingCart",
                columns: table => new
                {
                    ClothesId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothesShoppingCart", x => new { x.ClothesId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_ClothesShoppingCart_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothesShoppingCart_ShoppingCarts_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProteinPowderShoppingCart",
                columns: table => new
                {
                    ProteinPowdersId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinPowderShoppingCart", x => new { x.ProteinPowdersId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_ProteinPowderShoppingCart_ProteinPowder_ProteinPowdersId",
                        column: x => x.ProteinPowdersId,
                        principalTable: "ProteinPowder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProteinPowderShoppingCart_ShoppingCarts_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothesShoppingCart_ShoppingCartsId",
                table: "ClothesShoppingCart",
                column: "ShoppingCartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteinPowderShoppingCart_ShoppingCartsId",
                table: "ProteinPowderShoppingCart",
                column: "ShoppingCartsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothesShoppingCart");

            migrationBuilder.DropTable(
                name: "ProteinPowderShoppingCart");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "ProteinPowder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Clothes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProteinPowder_ShoppingCartId",
                table: "ProteinPowder",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ShoppingCartId",
                table: "Clothes",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ShoppingCarts_ShoppingCartId",
                table: "Clothes",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProteinPowder_ShoppingCarts_ShoppingCartId",
                table: "ProteinPowder",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
