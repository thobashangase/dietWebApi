﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dietapi.Models;

namespace dietapi.Migrations
{
    [DbContext(typeof(DietDbContext))]
    partial class DietDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dietapi.Models.DailyDiet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Day");

                    b.Property<int>("TotalCalories");

                    b.HasKey("Id");

                    b.ToTable("DailyDiets");
                });

            modelBuilder.Entity("dietapi.Models.DailyDietLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DailyDietId");

                    b.Property<int>("DesertId");

                    b.Property<int>("MealId");

                    b.HasKey("Id");

                    b.HasIndex("DailyDietId");

                    b.HasIndex("DesertId");

                    b.HasIndex("MealId");

                    b.ToTable("DailyDietLines");
                });

            modelBuilder.Entity("dietapi.Models.DailyDietLineDesert", b =>
                {
                    b.Property<int>("DailyDietLineId");

                    b.Property<int>("DesertId");

                    b.HasKey("DailyDietLineId");

                    b.HasIndex("DesertId");

                    b.ToTable("DailyDietLineDeserts");
                });

            modelBuilder.Entity("dietapi.Models.DailyDietRecommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DailyDietId");

                    b.Property<double>("Distance");

                    b.Property<int>("Steps");

                    b.HasKey("Id");

                    b.HasIndex("DailyDietId");

                    b.ToTable("DailyDietRecommendations");
                });

            modelBuilder.Entity("dietapi.Models.DailyDietSteps", b =>
                {
                    b.Property<int>("DailyDietId");

                    b.Property<int>("Count");

                    b.HasKey("DailyDietId");

                    b.ToTable("DailyDietSteps");
                });

            modelBuilder.Entity("dietapi.Models.Desert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Deserts");
                });

            modelBuilder.Entity("dietapi.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories");

                    b.Property<string>("Description");

                    b.Property<int>("MealTypeId");

                    b.HasKey("Id");

                    b.HasIndex("MealTypeId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("dietapi.Models.MealDesert", b =>
                {
                    b.Property<int>("MealId");

                    b.Property<int>("DesertId");

                    b.HasKey("MealId", "DesertId");

                    b.HasAlternateKey("DesertId", "MealId");

                    b.ToTable("MealDeserts");
                });

            modelBuilder.Entity("dietapi.Models.MealType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("MealTypes");
                });

            modelBuilder.Entity("dietapi.Models.RecommendedCalorieSteps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories");

                    b.Property<int>("Steps");

                    b.HasKey("Id");

                    b.ToTable("RecommendedCalorieSteps");
                });

            modelBuilder.Entity("dietapi.Models.RecommendedStepsDistance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Distance");

                    b.Property<int>("Steps");

                    b.HasKey("Id");

                    b.ToTable("RecommendedStepsDistances");
                });

            modelBuilder.Entity("dietapi.Models.DailyDietLine", b =>
                {
                    b.HasOne("dietapi.Models.DailyDiet", "DailyDiet")
                        .WithMany("DailyDietLines")
                        .HasForeignKey("DailyDietId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dietapi.Models.Desert", "Desert")
                        .WithMany("DailyDietLines")
                        .HasForeignKey("DesertId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dietapi.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dietapi.Models.DailyDietLineDesert", b =>
                {
                    b.HasOne("dietapi.Models.DailyDietLine", "DailyDietLine")
                        .WithMany("DailyDietLineDeserts")
                        .HasForeignKey("DailyDietLineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dietapi.Models.Desert", "Desert")
                        .WithMany("DailyDietLineDeserts")
                        .HasForeignKey("DesertId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("dietapi.Models.DailyDietRecommendation", b =>
                {
                    b.HasOne("dietapi.Models.DailyDiet", "DailyDiet")
                        .WithMany("DailyDietRecommendations")
                        .HasForeignKey("DailyDietId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("dietapi.Models.DailyDietSteps", b =>
                {
                    b.HasOne("dietapi.Models.DailyDiet", "DailyDiet")
                        .WithMany()
                        .HasForeignKey("DailyDietId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dietapi.Models.Meal", b =>
                {
                    b.HasOne("dietapi.Models.MealType", "MealType")
                        .WithMany("Meals")
                        .HasForeignKey("MealTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dietapi.Models.MealDesert", b =>
                {
                    b.HasOne("dietapi.Models.Desert", "Desert")
                        .WithMany("MealDeserts")
                        .HasForeignKey("DesertId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dietapi.Models.Meal", "Meal")
                        .WithMany("MealDeserts")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
