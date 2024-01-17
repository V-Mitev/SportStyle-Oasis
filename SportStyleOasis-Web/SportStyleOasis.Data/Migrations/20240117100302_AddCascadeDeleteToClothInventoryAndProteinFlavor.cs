#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddCascadeDeleteToClothInventoryAndProteinFlavor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 17, 10, 3, 1, 268, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 17, 10, 3, 1, 268, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 17, 10, 3, 1, 268, DateTimeKind.Utc).AddTicks(7802));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 15, 14, 53, 15, 377, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 15, 14, 53, 15, 377, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 1, 15, 14, 53, 15, 377, DateTimeKind.Utc).AddTicks(4685));
        }
    }
}
