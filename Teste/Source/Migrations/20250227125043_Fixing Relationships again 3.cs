using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class FixingRelationshipsagain3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Meals_MealId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Meals_MealId1",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Orders_OrderId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Orders_OrderId1",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MealId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MealId1",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_OrderId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_OrderId1",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MealId1",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.CreateTable(
                name: "OrderAdditionalIngredients",
                columns: table => new
                {
                    AdditionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAdditionalIngredients", x => new { x.AdditionalId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderAdditionalIngredients_Ingredients_AdditionalId",
                        column: x => x.AdditionalId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAdditionalIngredients_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRemovedIngredients",
                columns: table => new
                {
                    Order1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemovedIngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRemovedIngredients", x => new { x.Order1Id, x.RemovedIngredientsId });
                    table.ForeignKey(
                        name: "FK_OrderRemovedIngredients_Ingredients_RemovedIngredientsId",
                        column: x => x.RemovedIngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRemovedIngredients_Orders_Order1Id",
                        column: x => x.Order1Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderAdditionalIngredients_OrderId",
                table: "OrderAdditionalIngredients",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRemovedIngredients_RemovedIngredientsId",
                table: "OrderRemovedIngredients",
                column: "RemovedIngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderAdditionalIngredients");

            migrationBuilder.DropTable(
                name: "OrderRemovedIngredients");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Meals");

            migrationBuilder.AddColumn<Guid>(
                name: "MealId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MealId1",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId1",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MealId",
                table: "Ingredients",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MealId1",
                table: "Ingredients",
                column: "MealId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_OrderId",
                table: "Ingredients",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_OrderId1",
                table: "Ingredients",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Meals_MealId",
                table: "Ingredients",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Meals_MealId1",
                table: "Ingredients",
                column: "MealId1",
                principalTable: "Meals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Orders_OrderId",
                table: "Ingredients",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Orders_OrderId1",
                table: "Ingredients",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
