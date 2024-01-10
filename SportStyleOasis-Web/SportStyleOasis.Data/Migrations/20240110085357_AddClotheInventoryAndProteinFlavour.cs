#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddClotheInventoryAndProteinFlavour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClotheInventory_Clothes_ClothId",
                table: "ClotheInventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClotheInventory",
                table: "ClotheInventory");

            migrationBuilder.RenameTable(
                name: "ClotheInventory",
                newName: "ClotheInventories");

            migrationBuilder.RenameIndex(
                name: "IX_ClotheInventory_ClothId",
                table: "ClotheInventories",
                newName: "IX_ClotheInventories_ClothId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClotheInventories",
                table: "ClotheInventories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClotheInventories_Clothes_ClothId",
                table: "ClotheInventories",
                column: "ClothId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClotheInventories_Clothes_ClothId",
                table: "ClotheInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClotheInventories",
                table: "ClotheInventories");

            migrationBuilder.RenameTable(
                name: "ClotheInventories",
                newName: "ClotheInventory");

            migrationBuilder.RenameIndex(
                name: "IX_ClotheInventories_ClothId",
                table: "ClotheInventory",
                newName: "IX_ClotheInventory_ClothId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClotheInventory",
                table: "ClotheInventory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClotheInventory_Clothes_ClothId",
                table: "ClotheInventory",
                column: "ClothId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
