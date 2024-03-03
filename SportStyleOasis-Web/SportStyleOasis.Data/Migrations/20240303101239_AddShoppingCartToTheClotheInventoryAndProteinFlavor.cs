#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddShoppingCartToTheClotheInventoryAndProteinFlavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothesShoppingCart");

            migrationBuilder.DropTable(
                name: "ProteinPowderShoppingCart");

            migrationBuilder.CreateTable(
                name: "ClotheInventoryShoppingCart",
                columns: table => new
                {
                    ClotheInventoriesId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClotheInventoryShoppingCart", x => new { x.ClotheInventoriesId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_ClotheInventoryShoppingCart_ClotheInventories_ClotheInventoriesId",
                        column: x => x.ClotheInventoriesId,
                        principalTable: "ClotheInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClotheInventoryShoppingCart_ShoppingCarts_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProteinFlavorShoppingCart",
                columns: table => new
                {
                    ProteinFlavorsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinFlavorShoppingCart", x => new { x.ProteinFlavorsId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_ProteinFlavorShoppingCart_ProteinFlavor_ProteinFlavorsId",
                        column: x => x.ProteinFlavorsId,
                        principalTable: "ProteinFlavor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProteinFlavorShoppingCart_ShoppingCarts_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 911, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 911, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 911, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 912, DateTimeKind.Utc).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 912, DateTimeKind.Utc).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 912, DateTimeKind.Utc).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 912, DateTimeKind.Utc).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 912, DateTimeKind.Utc).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 12, 37, 912, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.CreateIndex(
                name: "IX_ClotheInventoryShoppingCart_ShoppingCartsId",
                table: "ClotheInventoryShoppingCart",
                column: "ShoppingCartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteinFlavorShoppingCart_ShoppingCartsId",
                table: "ProteinFlavorShoppingCart",
                column: "ShoppingCartsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClotheInventoryShoppingCart");

            migrationBuilder.DropTable(
                name: "ProteinFlavorShoppingCart");

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

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5594));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5596));

            migrationBuilder.CreateIndex(
                name: "IX_ClothesShoppingCart_ShoppingCartsId",
                table: "ClothesShoppingCart",
                column: "ShoppingCartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteinPowderShoppingCart_ShoppingCartsId",
                table: "ProteinPowderShoppingCart",
                column: "ShoppingCartsId");
        }
    }
}
