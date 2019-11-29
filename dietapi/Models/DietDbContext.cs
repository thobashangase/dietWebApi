using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class DietDbContext : DbContext
    {
        public DietDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Desert> Deserts { get; set; }
        public DbSet<MealDesert> MealDeserts { get; set; }
        public DbSet<DailyDiet> DailyDiets { get; set; }
        public DbSet<DailyDietLine> DailyDietLines { get; set; }
        public DbSet<DailyDietLineDesert> DailyDietLineDeserts { get; set; }
        public DbSet<DailyDietSteps> DailyDietSteps { get; set; }
        public DbSet<RecommendedCalorieSteps> RecommendedCalorieSteps { get; set; }
        public DbSet<RecommendedStepsDistance> RecommendedStepsDistances { get; set; }
        public DbSet<DailyDietRecommendation> DailyDietRecommendations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealDesert>().HasKey(m => new { m.MealId, m.DesertId });

            modelBuilder.Entity<DailyDietLineDesert>()
                .HasOne(u => u.Desert).WithMany(u => u.DailyDietLineDeserts).IsRequired().OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<DailyDietLine>()
            //    .HasOne(u => u.MealType).WithMany(u => u.DailyDietLines).IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DailyDietRecommendation>()
                .HasOne(u => u.DailyDiet).WithMany(u => u.DailyDietRecommendations).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
