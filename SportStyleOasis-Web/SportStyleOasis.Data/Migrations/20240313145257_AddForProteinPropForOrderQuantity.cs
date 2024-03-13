#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddForProteinPropForOrderQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClotheOrderQuantityId",
                table: "ProteinFlavor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProteinOrderQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinOrderQuantities", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 52, 56, 944, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.CreateIndex(
                name: "IX_ProteinFlavor_ClotheOrderQuantityId",
                table: "ProteinFlavor",
                column: "ClotheOrderQuantityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProteinFlavor_ProteinOrderQuantities_ClotheOrderQuantityId",
                table: "ProteinFlavor",
                column: "ClotheOrderQuantityId",
                principalTable: "ProteinOrderQuantities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProteinFlavor_ProteinOrderQuantities_ClotheOrderQuantityId",
                table: "ProteinFlavor");

            migrationBuilder.DropTable(
                name: "ProteinOrderQuantities");

            migrationBuilder.DropIndex(
                name: "IX_ProteinFlavor_ClotheOrderQuantityId",
                table: "ProteinFlavor");

            migrationBuilder.DropColumn(
                name: "ClotheOrderQuantityId",
                table: "ProteinFlavor");

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 174, DateTimeKind.Utc).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 174, DateTimeKind.Utc).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 174, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 175, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 175, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 175, DateTimeKind.Utc).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 175, DateTimeKind.Utc).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 175, DateTimeKind.Utc).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 47, 43, 175, DateTimeKind.Utc).AddTicks(2178));
        }
    }
}
