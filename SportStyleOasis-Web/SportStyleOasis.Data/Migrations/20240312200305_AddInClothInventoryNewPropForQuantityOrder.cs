#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddInClothInventoryNewPropForQuantityOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClotheOrderQuantityId",
                table: "ClotheInventories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClotheOrderQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    ClothId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClotheOrderQuantities", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 944, DateTimeKind.Utc).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 944, DateTimeKind.Utc).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 944, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 20, 3, 3, 945, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.CreateIndex(
                name: "IX_ClotheInventories_ClotheOrderQuantityId",
                table: "ClotheInventories",
                column: "ClotheOrderQuantityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClotheInventories_ClotheOrderQuantities_ClotheOrderQuantityId",
                table: "ClotheInventories",
                column: "ClotheOrderQuantityId",
                principalTable: "ClotheOrderQuantities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClotheInventories_ClotheOrderQuantities_ClotheOrderQuantityId",
                table: "ClotheInventories");

            migrationBuilder.DropTable(
                name: "ClotheOrderQuantities");

            migrationBuilder.DropIndex(
                name: "IX_ClotheInventories_ClotheOrderQuantityId",
                table: "ClotheInventories");

            migrationBuilder.DropColumn(
                name: "ClotheOrderQuantityId",
                table: "ClotheInventories");

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 10, 43, 38, 590, DateTimeKind.Utc).AddTicks(9839));
        }
    }
}
