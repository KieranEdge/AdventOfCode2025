using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Services
{
    public static class RowAnalyser
    {
        public static int MaxJoltageCalculator(List<int> joltages)
        {
            // Starting the variables
            int maxJoltageStart = 0;
            int maxJoltageEnd = 0;
            int maxJoltageStartingIndex = 0;

            // Scanning the values to get the first number
            for(int i = 0; i < joltages.Count - 1; i++) 
            {
                if (joltages[i] > maxJoltageStart)
                {
                    maxJoltageStart = joltages[i];
                    maxJoltageStartingIndex = i;
                }
            }

            // Scanning the values to get the second number
            for (int i = maxJoltageStartingIndex + 1; i < joltages.Count; ++i)
            {
                if (joltages[i] > maxJoltageEnd)
                {
                    maxJoltageEnd = joltages[i];
                }
            }

            // Concatenating the values and returning
            string maxJoltageString = maxJoltageStart.ToString() + maxJoltageEnd.ToString();
            //Console.WriteLine($"Max joltage first digit: {maxJoltageStart}");
            //Console.WriteLine($"Max joltage second digit: {maxJoltageEnd}");
            //Console.WriteLine($"Max joltage: {maxJoltageString}");
            //Thread.Sleep(1000);

            return Convert.ToInt32(maxJoltageString);
        }
    }
}
