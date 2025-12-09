using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Services
{
    public static class GeometryCalculator
    {
        public static long FindLargestRectangle(List<List<long>> coordinatePairs, int index)
        {
            // Initialising the sorting lists
            List<long> comparisonCoordinates = coordinatePairs[index];
            List<List<long>> otherCoordinates = new List<List<long>>(coordinatePairs);
            otherCoordinates.RemoveAt(index);
            
            // Iterating over the values to find the max rectangle size
            long maxRectangleSize = 0;
            foreach (List<long> coordinatePair in otherCoordinates)
            {
                // Getting the rectangle parameters
                long rectangleHeight = Math.Abs(coordinatePair[0] - comparisonCoordinates[0]) + 1;
                long rectangleWidth = Math.Abs(coordinatePair[1] - comparisonCoordinates[1]) + 1;
                long area = rectangleHeight * rectangleWidth;

                if (area > maxRectangleSize)
                {
                    maxRectangleSize = area;
                }
            }

            return maxRectangleSize;
        }
    }
}
