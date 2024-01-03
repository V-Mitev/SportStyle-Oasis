#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddConfigurationToReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Clothes_ClothesId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ProteinPowder_ProteinPowderId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Clothes_ClothesId",
                table: "Review",
                column: "ClothesId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ProteinPowder_ProteinPowderId",
                table: "Review",
                column: "ProteinPowderId",
                principalTable: "ProteinPowder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Clothes_ClothesId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ProteinPowder_ProteinPowderId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Clothes_ClothesId",
                table: "Review",
                column: "ClothesId",
                principalTable: "Clothes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ProteinPowder_ProteinPowderId",
                table: "Review",
                column: "ProteinPowderId",
                principalTable: "ProteinPowder",
                principalColumn: "Id");
        }
    }
}
