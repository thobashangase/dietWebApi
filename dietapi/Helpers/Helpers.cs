using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Helpers
{
    public static class Helpers
    {
        private static int dailySteps = 2000;
        private static double dailyDistance = 1.52;
        //private static int dailyCalories = 100;

        public static int CalculateSteps(int calories)
        {
            return calories * dailySteps;
        }

        public static double CalculateDistance(int calories)
        {
            return calories * dailyDistance;
        }
    }
}
