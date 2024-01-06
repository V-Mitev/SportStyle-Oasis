using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    public partial class AddInventoryForClothes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailabeQuantity",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Clothes");

            migrationBuilder.AlterColumn<string>(
                name: "FlavorName",
                table: "ProteinFlavor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ClotheInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothesSize = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    ClothId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClotheInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClotheInventory_Clothes_ClothId",
                        column: x => x.ClothId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClotheInventory",
                columns: new[] { "Id", "AvailableQuantity", "ClothId", "ClothesSize" },
                values: new object[,]
                {
                    { 1, 10, 1, 4 },
                    { 2, 10, 2, 3 },
                    { 3, 10, 3, 0 },
                    { 4, 10, 3, 1 },
                    { 5, 10, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClotheInventory_ClothId",
                table: "ClotheInventory",
                column: "ClothId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClotheInventory");

            migrationBuilder.AlterColumn<string>(
                name: "FlavorName",
                table: "ProteinFlavor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "AvailabeQuantity",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailabeQuantity", "Size" },
                values: new object[] { 10, 2 });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailabeQuantity", "Size" },
                values: new object[] { 10, 3 });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailabeQuantity", "Size" },
                values: new object[] { 10, 4 });
        }
    }
}
