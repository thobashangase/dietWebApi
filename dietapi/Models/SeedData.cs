using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public static class SeedData
    {
        public static void InitializeMealTypes(IServiceProvider serviceProvider)
        {
            using (var context = new DietDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DietDbContext>>()))
            {
                if (context.MealTypes.Any())
                {
                    return;   // DB has been seeded
                }

                context.MealTypes.AddRange(
                    new MealType
                    {
                        Description = "Breakfast"
                    },

                    new MealType
                    {
                        Description = "Lunch"
                    },

                    new MealType
                    {
                        Description = "Dinner"
                    }
                );
                context.SaveChanges();
            }
        }

        public static void InitializeMeals(IServiceProvider serviceProvider)
        {
            using (var context = new DietDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DietDbContext>>()))
            {
                if (context.Meals.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meals.AddRange(
                    new Meal
                    {
                        Description = "Eggs & bacon", 
                        MealTypeId = 1,
                        Calories = 250
                    },

                    new Meal
                    {
                        Description = "Cereal",
                        MealTypeId = 1,
                        Calories = 300
                    },

                    new Meal
                    {
                        Description = "Greek salad",
                        MealTypeId = 2,
                        Calories = 150
                    },

                    new Meal
                    {
                        Description = "Burger & chips",
                        MealTypeId = 2,
                        Calories = 600
                    },

                    new Meal
                    {
                        Description = "Boiled chicken fillet",
                        MealTypeId = 3,
                        Calories = 120
                    },

                    new Meal
                    {
                        Description = "Braai meat & pap",
                        MealTypeId = 3,
                        Calories = 700
                    }
                );
                context.SaveChanges();
            }
        }

        public static void InitializeDeserts(IServiceProvider serviceProvider)
        {
            using (var context = new DietDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DietDbContext>>()))
            {

                if (context.Deserts.Any())
                {
                    return;   // DB has been seeded
                }

                context.Deserts.AddRange(
                    new Desert
                    {
                        Description = "Water",
                        Calories = 50
                    },

                    new Desert
                    {
                        Description = "Fruit juice",
                        Calories = 80
                    },

                    new Desert
                    {
                        Description = "Coke",
                        Calories = 300
                    },

                    new Desert
                    {
                        Description = "Cake slice",
                        Calories = 200
                    },

                    new Desert
                    {
                        Description = "No desert",
                        Calories = 0
                    }
                );
                context.SaveChanges();
            }
        }

        public static void InitializeRecommendedCalorieSteps(IServiceProvider serviceProvider)
        {
            using (var context = new DietDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DietDbContext>>()))
            {
                if (context.RecommendedCalorieSteps.Any())
                {
                    return;   // DB has been seeded
                }

                context.RecommendedCalorieSteps.AddRange(
                    new RecommendedCalorieSteps
                    {
                        Calories = 100,
                        Steps = 2000
                    }
                );
                context.SaveChanges();
            }
        }

        public static void InitializeRecommendedCalorieDistances(IServiceProvider serviceProvider)
        {
            using (var context = new DietDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DietDbContext>>()))
            {
                if (context.RecommendedStepsDistances.Any())
                {
                    return;   // DB has been seeded
                }

                context.RecommendedStepsDistances.AddRange(
                    new RecommendedStepsDistance
                    {
                        Steps = 2000,
                        Distance = 1.52
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
