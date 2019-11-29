using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dietapi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyDiets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<DateTime>(nullable: false),
                    TotalCalories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDiets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deserts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deserts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecommendedCalorieSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<int>(nullable: false),
                    Steps = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendedCalorieSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecommendedStepsDistances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Steps = table.Column<int>(nullable: false),
                    Distance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendedStepsDistances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyDietRecommendations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DailyDietId = table.Column<int>(nullable: false),
                    Steps = table.Column<int>(nullable: false),
                    Distance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDietRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDietRecommendations_DailyDiets_DailyDietId",
                        column: x => x.DailyDietId,
                        principalTable: "DailyDiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyDietSteps",
                columns: table => new
                {
                    DailyDietId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDietSteps", x => x.DailyDietId);
                    table.ForeignKey(
                        name: "FK_DailyDietSteps_DailyDiets_DailyDietId",
                        column: x => x.DailyDietId,
                        principalTable: "DailyDiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MealTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Calories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyDietLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DailyDietId = table.Column<int>(nullable: false),
                    MealTypeId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    DesertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDietLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDietLines_DailyDiets_DailyDietId",
                        column: x => x.DailyDietId,
                        principalTable: "DailyDiets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyDietLines_Deserts_DesertId",
                        column: x => x.DesertId,
                        principalTable: "Deserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyDietLines_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyDietLines_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealDeserts",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false),
                    DesertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDeserts", x => new { x.MealId, x.DesertId });
                    table.UniqueConstraint("AK_MealDeserts_DesertId_MealId", x => new { x.DesertId, x.MealId });
                    table.ForeignKey(
                        name: "FK_MealDeserts_Deserts_DesertId",
                        column: x => x.DesertId,
                        principalTable: "Deserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealDeserts_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyDietLineDeserts",
                columns: table => new
                {
                    DailyDietLineId = table.Column<int>(nullable: false),
                    DesertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDietLineDeserts", x => x.DailyDietLineId);
                    table.ForeignKey(
                        name: "FK_DailyDietLineDeserts_DailyDietLines_DailyDietLineId",
                        column: x => x.DailyDietLineId,
                        principalTable: "DailyDietLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyDietLineDeserts_Deserts_DesertId",
                        column: x => x.DesertId,
                        principalTable: "Deserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietLineDeserts_DesertId",
                table: "DailyDietLineDeserts",
                column: "DesertId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietLines_DailyDietId",
                table: "DailyDietLines",
                column: "DailyDietId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietLines_DesertId",
                table: "DailyDietLines",
                column: "DesertId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietLines_MealId",
                table: "DailyDietLines",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietLines_MealTypeId",
                table: "DailyDietLines",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDietRecommendations_DailyDietId",
                table: "DailyDietRecommendations",
                column: "DailyDietId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals",
                column: "MealTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyDietLineDeserts");

            migrationBuilder.DropTable(
                name: "DailyDietRecommendations");

            migrationBuilder.DropTable(
                name: "DailyDietSteps");

            migrationBuilder.DropTable(
                name: "MealDeserts");

            migrationBuilder.DropTable(
                name: "RecommendedCalorieSteps");

            migrationBuilder.DropTable(
                name: "RecommendedStepsDistances");

            migrationBuilder.DropTable(
                name: "DailyDietLines");

            migrationBuilder.DropTable(
                name: "DailyDiets");

            migrationBuilder.DropTable(
                name: "Deserts");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "MealTypes");
        }
    }
}
