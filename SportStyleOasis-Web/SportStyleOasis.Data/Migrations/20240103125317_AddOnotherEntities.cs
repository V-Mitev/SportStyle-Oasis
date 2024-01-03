#nullable disable

namespace SportStyleOasis.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddOnotherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityOrder = table.Column<int>(type: "int", nullable: false),
                    AvailabeQuantity = table.Column<int>(type: "int", nullable: false),
                    TypeOfClothes = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProteinPowder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityOrder = table.Column<int>(type: "int", nullable: false),
                    AvailabeQuantity = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    TypeOfProtein = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinPowder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProteinPowder_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ClothesId = table.Column<int>(type: "int", nullable: true),
                    ProteinPowderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_ProteinPowder_ProteinPowderId",
                        column: x => x.ProteinPowderId,
                        principalTable: "ProteinPowder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ShoppingCartId",
                table: "Clothes",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProteinPowder_ShoppingCartId",
                table: "ProteinPowder",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ClothesId",
                table: "Review",
                column: "ClothesId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProteinPowderId",
                table: "Review",
                column: "ProteinPowderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "ProteinPowder");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
