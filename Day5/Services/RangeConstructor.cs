using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Services
{
    public class RangeConstructor
    {
        public static void RangesListToMapOfCombinedRanges(List<List<long>> rangeList)
        {
            // Search parameters
            long rangeSizes = 0;
            bool overlaps = true;

            // Performing initial run
            Console.WriteLine("Performing initial run");
            var rangeSearchInformation = RangeUpdater(rangeList);
            overlaps = rangeSearchInformation.overlapsFound;
            List<List<long>> updatedRange = rangeSearchInformation.newRanges;
            Console.WriteLine(updatedRange.Count);
            Console.WriteLine(updatedRange[0].Count);

            // Iterating over the list to search for overlaps and update until no further overlaps are found
            while (overlaps)
            {
                var newRangeSearchInformation = RangeUpdater(updatedRange);
                overlaps = newRangeSearchInformation.overlapsFound;
                updatedRange = newRangeSearchInformation.newRanges;
                foreach(long rangestart in updatedRange[0])
                {
                    Console.WriteLine(rangestart);
                }
            }

            for (int i = 0; i < updatedRange[0].Count; i++)
            {
                rangeSizes += (updatedRange[1][i] - updatedRange[0][i]);
            }

            Console.WriteLine($"Total number of possible ids = {rangeSizes}");

        }

        public static (List<List<long>> newRanges, bool overlapsFound) RangeUpdater(List<List<long>> rangeList)
        {
            // Initialising the parameters
            List<long> startingRanges = rangeList[0];
            List<long> endRanges = rangeList[1];
            List<long> newStarts = new List<long>();
            List<long> newEnds = new List<long>();
            List<List<long>> newRanges = new List<List<long>>();
            int overlappingRanges = 0;

            // Getting the overlapping ranges and outputting the list
            for (int i = 0; i < startingRanges.Count; i++)
            {
                // Check if the range is fully encapsulated in another range
                if (!IsRangeEncapsulated(startingRanges, endRanges, i))
                {
                    Console.WriteLine("Range overlaps or stands alone");
                    // Check for overlaps and modify the range if so
                    var overlappingInformation = IsRangeOverlapping(startingRanges, endRanges, i);
                    if (overlappingInformation.doesOverlap)
                    {
                        overlappingRanges++;
                    }

                    // Adding the new range data to a new list
                    newStarts.Add(overlappingInformation.newStart);
                    newEnds.Add(overlappingInformation.newEnd);
                }
            }

            // Creating the new ranges
            newRanges.Add(newStarts);
            newRanges.Add(newEnds);

            return (newRanges, overlappingRanges > 0);
        }

        /// <summary>
        /// Determines whether or not the first range overlaps with the second range either from above or below
        /// </summary>
        /// <param name="range1Start"></param>
        /// <param name="range1End"></param>
        /// <param name="range2Start"></param>
        /// <param name="range2End"></param>
        /// <returns>Boolean to specify it is overlapping or not</returns>
        public static (bool doesOverlap, long newStart, long newEnd) IsRangeOverlapping(List<long> startingRanges, List<long> endRanges, int index)
        {
            // Initialising the parameters
            List<long> tempStartingRanges = startingRanges;
            List<long> tempEndRanges = endRanges;
            tempStartingRanges.RemoveAt(index);
            tempEndRanges.RemoveAt(index);
            long rangeStart = startingRanges[index];
            long rangeEnd = endRanges[index];

            for(int i = 0; i < tempStartingRanges.Count; i++)
            {
                // Extending the beginning if overlaps from in to out
                if (rangeStart >= tempStartingRanges[i] && rangeStart <= tempEndRanges[i])
                {
                    Console.WriteLine($"Range: {rangeStart} - {rangeEnd} found overlapping with range {tempStartingRanges[i]} - {tempEndRanges[i]}");
                    return (true, tempStartingRanges[i], rangeEnd);
                }
                // Extending the end if overlaps from out to in
                else if (rangeEnd >= tempStartingRanges[i] && rangeEnd <= tempEndRanges[i])
                {
                    return (true, rangeStart, tempEndRanges[i]);
                }
                // Returning the original numbers if there is no overlaps
                else 
                {
                    return (false, rangeStart, rangeEnd); 
                }
            }

            return (false, rangeStart, rangeEnd);
        }

        /// <summary>
        /// Determines whether the first range is fully encapsulated within any existing ranges
        /// </summary>
        /// <param name="range1Start"></param>
        /// <param name="range1End"></param>
        /// <param name="range2Start"></param>
        /// <param name="range2End"></param>
        /// <returns>bool of whether or not encapsulation is complete</returns>
        public static bool IsRangeEncapsulated(List<long> startingRanges, List<long> endRanges, int index)
        {
            // Initialising a temporary list and removing the index of the value
            List<long> tempStartingRanges = startingRanges;
            List<long> tempEndRanges = endRanges;
            tempStartingRanges.RemoveAt(index);
            tempEndRanges.RemoveAt(index);
            long rangeStart = startingRanges[index];
            long rangeEnd = endRanges[index];

            for (int i = 0; i < tempStartingRanges.Count; i++)
            {
                if (rangeStart >= tempStartingRanges[i] && rangeEnd <= tempEndRanges[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
