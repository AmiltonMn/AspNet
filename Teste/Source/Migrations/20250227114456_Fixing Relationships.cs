using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class FixingRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ClientId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DrinkOrder");

            migrationBuilder.DropTable(
                name: "IngredientMeal");

            migrationBuilder.DropTable(
                name: "MealOrder");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "FinalOrderId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderedDrinkId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderedMealId",
                table: "Orders",
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

            migrationBuilder.CreateTable(
                name: "FinalOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalOrder_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FinalOrderId",
                table: "Orders",
                column: "FinalOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderedDrinkId",
                table: "Orders",
                column: "OrderedDrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderedMealId",
                table: "Orders",
                column: "OrderedMealId");

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

            migrationBuilder.CreateIndex(
                name: "IX_FinalOrder_ClientId",
                table: "FinalOrder",
                column: "ClientId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drinks_OrderedDrinkId",
                table: "Orders",
                column: "OrderedDrinkId",
                principalTable: "Drinks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FinalOrder_FinalOrderId",
                table: "Orders",
                column: "FinalOrderId",
                principalTable: "FinalOrder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Meals_OrderedMealId",
                table: "Orders",
                column: "OrderedMealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Meals_MealId1",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Orders_OrderId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Orders_OrderId1",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drinks_OrderedDrinkId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FinalOrder_FinalOrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Meals_OrderedMealId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "FinalOrder");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FinalOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderedDrinkId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderedMealId",
                table: "Orders");

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
                name: "FinalOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderedDrinkId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderedMealId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MealId1",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Ingredients");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DrinkOrder",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedDrinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkOrder", x => new { x.OrderId, x.OrderedDrinksId });
                    table.ForeignKey(
                        name: "FK_DrinkOrder_Drinks_OrderedDrinksId",
                        column: x => x.OrderedDrinksId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientMeal",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeal", x => new { x.IngredientsId, x.MealId });
                    table.ForeignKey(
                        name: "FK_IngredientMeal_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMeal_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealOrder",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedMealsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOrder", x => new { x.OrderId, x.OrderedMealsId });
                    table.ForeignKey(
                        name: "FK_MealOrder_Meals_OrderedMealsId",
                        column: x => x.OrderedMealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkOrder_OrderedDrinksId",
                table: "DrinkOrder",
                column: "OrderedDrinksId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMeal_MealId",
                table: "IngredientMeal",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOrder_OrderedMealsId",
                table: "MealOrder",
                column: "OrderedMealsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
