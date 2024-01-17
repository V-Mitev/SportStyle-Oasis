#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddUserNameAndCreatedAtForReviewsAndSeedSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Review",
                newName: "Comment");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Review",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "ClothesId", "Comment", "CreatedAt", "ProteinPowderId", "Rating", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "I really like the design and comfort of this gray T-shirt. Perfect for casual wear.", new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5577), null, 4.5, "TestUserName" },
                    { 2, 2, "The black T-shirt fits well and has a nice price. Great for everyday use.", new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5584), null, 4.0, "TestUserName" },
                    { 3, 3, "Absolutely love the style and feel of this white T-shirt. It's a must-have for any wardrobe!", new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5586), null, 5.0, "TestUserName" },
                    { 4, null, "Great taste and mixes well. Impact Whey is my go-to protein for post-workout recovery.", new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5588), 1, 5.0, "TestUserName" },
                    { 5, null, "Bulk Isolate Protein delivers excellent results. It's a bit pricey, but the quality is worth it.", new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5594), 2, 4.7999999999999998, "TestUserName" },
                    { 6, null, "As a vegan, I love ProteinWorks' Vegan Protein. Tastes great and meets my nutritional needs perfectly.", new DateTime(2024, 1, 17, 10, 56, 20, 930, DateTimeKind.Utc).AddTicks(5596), 3, 4.9000000000000004, "TestUserName" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Review",
                newName: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
    }
}
