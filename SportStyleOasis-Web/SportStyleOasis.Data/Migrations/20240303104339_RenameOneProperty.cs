#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameOneProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
