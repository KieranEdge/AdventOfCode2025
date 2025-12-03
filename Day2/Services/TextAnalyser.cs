using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Services
{
    public static class TextAnalyser
    {
        public static List<long> FindInvalidPatternsPart1(List<long> patterns)
        {
            List<long> invalidIds = new List<long>();
            foreach (long pattern in patterns)
            {
                // Converting to string and doubling it
                string patternStr = pattern.ToString();

                if (patternStr.Length % 2 == 0)
                {
                    // Split the string in two and compare the two halves
                    int stringLength = patternStr.Length;
                    string halfOne = patternStr.Substring(0, stringLength / 2);
                    string halfTwo = patternStr.Substring(stringLength/2, stringLength/2);

                    if (halfOne == halfTwo)
                    {
                        invalidIds.Add(pattern);
                    }
                    
                }
                
            }

            return invalidIds;
        }

        public static List<long> FindInvalidPatternsPart2(List<long> patterns)
        {
            List<long> invalidIds = new List<long>();
            
            foreach (long pattern in patterns)
            {
                // Boolean for continuing
                bool isInvalid = false;
                
                // Converting to string
                string patternStr = pattern.ToString();
                int stringLength = patternStr.Length;

                // Iterating over the factors in a string to break it into chunks to compare
                for (int i = 2; i <= stringLength; i++)
                {
                    // Checking if we've found a matching pattern
                    if (!isInvalid)
                    {
                        // Checking if the string is divisible by the current factor
                        if (stringLength % i == 0)
                        {
                            // Checking if the string is made of multiple repeating patterns
                            isInvalid = StringSeparationAndComparison(patternStr, i);

                            // Adding invalidIds to the list
                            if (isInvalid)
                            {
                                invalidIds.Add(pattern);
                            }
                        }
                    }
                    
                }
                
            }
            return invalidIds;
        }

        public static bool StringSeparationAndComparison(string str, int chunks)
        {
            // Separating the string into even chunks
            List<string> stringChunks = new List<string>();
            int factor = str.Length / chunks;

            for (int i = 0; i < str.Length; i += factor)
            {
                stringChunks.Add(str.Substring(i, factor));
            }

            return stringChunks.Distinct().Count() == 1;
        }
    }
}
