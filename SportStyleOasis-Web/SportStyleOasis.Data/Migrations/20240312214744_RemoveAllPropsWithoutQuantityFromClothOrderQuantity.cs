#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveAllPropsWithoutQuantityFromClothOrderQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClothId",
                table: "ClotheOrderQuantities");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ClotheOrderQuantities");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ClotheOrderQuantities");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClothId",
                table: "ClotheOrderQuantities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "ClotheOrderQuantities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ClotheOrderQuantities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(1319));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 37, 17, 349, DateTimeKind.Utc).AddTicks(5853));
        }
    }
}
