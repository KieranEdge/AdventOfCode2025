using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Services
{
    public static class RowAnalyser
    {
        public static int MaxJoltageCalculatorPart1(List<int> joltages)
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

            return Convert.ToInt32(maxJoltageString);
        }

        public static long MaxJoltageCalculatorPart2(List<int> joltages)
        {
            // Starting the variables
            int maxJoltageInRow = 0;
            int maxJoltageStartingIndex = 0;
            int stringLengthModifier = 11;
            string concatenatedValues = "";
            List<int> maxJoltageValues = new List<int>();

            // Populating the 12 values
            for(int j = 0; j < 12; ++j)
            { 
                // Getting the largest digit and its index
                List<int> tempDigitList = FindNextLongestNumber(maxJoltageStartingIndex, stringLengthModifier, joltages);

                // Adding to the list
                maxJoltageValues.Add(tempDigitList[0]);

                // Updating the search parameters
                maxJoltageStartingIndex = tempDigitList[1] + 1;
                stringLengthModifier--;
                
            }

            foreach(int digit in maxJoltageValues)
            {
                concatenatedValues += digit.ToString();
            }
            

            return (long)Convert.ToDouble(concatenatedValues);
        }

        public static List<int> FindNextLongestNumber(int startingIndex, int stringLengthModifier, List<int> joltages)
        {
            int maxDigit = 0;
            int maxDigitIndex = 0;
            List<int> maxDigitInformation = new List<int>();
            
            // Scanning the values to get the max numbers
            for (int i = startingIndex; i < joltages.Count - stringLengthModifier; i++)
            {
                if (joltages[i] > maxDigit)
                {
                    maxDigit = joltages[i];
                    maxDigitIndex = i;
                }
            }

            // Returning the max digit and its index as a list
            maxDigitInformation.Add(maxDigit);
            maxDigitInformation.Add(maxDigitIndex);
            return maxDigitInformation;
            
        }
    }
}
