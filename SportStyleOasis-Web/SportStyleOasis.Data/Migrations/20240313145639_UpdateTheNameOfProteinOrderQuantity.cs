#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateTheNameOfProteinOrderQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProteinFlavor_ProteinOrderQuantities_ClotheOrderQuantityId",
                table: "ProteinFlavor");

            migrationBuilder.RenameColumn(
                name: "ClotheOrderQuantityId",
                table: "ProteinFlavor",
                newName: "ProteinOrderQuantityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProteinFlavor_ClotheOrderQuantityId",
                table: "ProteinFlavor",
                newName: "IX_ProteinFlavor_ProteinOrderQuantityId");

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 56, 38, 937, DateTimeKind.Utc).AddTicks(9960));

            migrationBuilder.AddForeignKey(
                name: "FK_ProteinFlavor_ProteinOrderQuantities_ProteinOrderQuantityId",
                table: "ProteinFlavor",
                column: "ProteinOrderQuantityId",
                principalTable: "ProteinOrderQuantities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProteinFlavor_ProteinOrderQuantities_ProteinOrderQuantityId",
                table: "ProteinFlavor");

            migrationBuilder.RenameColumn(
                name: "ProteinOrderQuantityId",
                table: "ProteinFlavor",
                newName: "ClotheOrderQuantityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProteinFlavor_ProteinOrderQuantityId",
                table: "ProteinFlavor",
                newName: "IX_ProteinFlavor_ClotheOrderQuantityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProteinFlavor_ProteinOrderQuantities_ClotheOrderQuantityId",
                table: "ProteinFlavor",
                column: "ClotheOrderQuantityId",
                principalTable: "ProteinOrderQuantities",
                principalColumn: "Id");
        }
    }
}
