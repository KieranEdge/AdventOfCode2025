using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Services
{
    public static class TextAnalyser
    {
        public static List<long> FindInvalidPatterns(List<long> patterns)
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
    }
}
