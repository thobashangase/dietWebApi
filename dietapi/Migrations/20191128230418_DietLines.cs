using Microsoft.EntityFrameworkCore.Migrations;

namespace dietapi.Migrations
{
    public partial class DietLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyDietLines_MealTypes_MealTypeId",
                table: "DailyDietLines");

            migrationBuilder.DropIndex(
                name: "IX_DailyDietLines_MealTypeId",
                table: "DailyDietLines");

            migrationBuilder.DropColumn(
                name: "MealTypeId",
                table: "DailyDietLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealTypeId",
                table: "DailyDietLines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietLines_MealTypeId",
                table: "DailyDietLines",
                column: "MealTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDietLines_MealTypes_MealTypeId",
                table: "DailyDietLines",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
