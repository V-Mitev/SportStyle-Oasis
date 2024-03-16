#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 350, DateTimeKind.Utc).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 350, DateTimeKind.Utc).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 350, DateTimeKind.Utc).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 351, DateTimeKind.Utc).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 351, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 351, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 351, DateTimeKind.Utc).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 351, DateTimeKind.Utc).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 10, 54, 1, 351, DateTimeKind.Utc).AddTicks(6901));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 171, DateTimeKind.Utc).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 171, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "ProteinPowder",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeForAddFlavor",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 171, DateTimeKind.Utc).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 173, DateTimeKind.Utc).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 173, DateTimeKind.Utc).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 173, DateTimeKind.Utc).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 173, DateTimeKind.Utc).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 173, DateTimeKind.Utc).AddTicks(2919));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 17, 45, 13, 173, DateTimeKind.Utc).AddTicks(2922));
        }
    }
}
