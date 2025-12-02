using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2.Services
{
    public static class DataProcessor
    {
        public static List<List<long>> DataTextToListsOfInts(string filePath)
        {
            // Initialising the lists
            List<List<long>> rangeLists = new List<List<long>>();
            List<long> startingRange = new List<long>();
            List<long> endingRange = new List<long>();

            // Reading the data
            string rawData = File.ReadAllText(filePath);
            var rawRanges = rawData.Split(',');
            
            // Splitting out each line and storing the values in the lists
            foreach ( var range in rawRanges)
            {
                long rangeStart = (long)Convert.ToDouble(range.Split('-')[0]);
                long rangeEnd = (long)Convert.ToDouble(range.Split('-')[1]);

                startingRange.Add(rangeStart);
                endingRange.Add(rangeEnd);
            }
            
            rangeLists.Add(startingRange);
            rangeLists.Add(endingRange);

            return rangeLists;
        }

        public static List<long> RangeConstructor(long start, long end)
        {
            List<long> rangeList = new List<long>();
            
            while (start <= end)
            {
                rangeList.Add(start);
                start++;
            }
            return rangeList;
        }

        public static long ReturnSumOfMatchingPatterns(List<long> MatchingPatterns)
        {
            long runningScore = 0;

            foreach (long pattern in MatchingPatterns)
            {
                runningScore += pattern;
            }

            return runningScore;
        }
    }
}
