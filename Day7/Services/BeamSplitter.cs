using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Services
{
    public static class BeamSplitter
    {
        public static void FindBeamSplitters(char[,] splitterLocations)
        {
            // Getting the shape
            int numOfRows = splitterLocations.GetLength(0);
            int numOfCols = splitterLocations.GetLength(1);
            char[,] copiedArray = splitterLocations;

            // Getting the starting coordinates
            var startingCoordinates = FindStartingLocation(splitterLocations, numOfRows, numOfCols);
            int startingRow = startingCoordinates.startingRow;
            int startingCol = startingCoordinates.startingCol;

            // Searching for beams row by row
            List<int> beamColumns = new List<int> { startingCol };
            List<int> numberOfBeamPaths = new List<int>();
            int numOfTimesBeamSplit = 0;

            // Creating a path counter as a dictionary
            var paths = new Dictionary<int, long>();
            paths[startingCol] = 1; 

            for (int row = 0; row < numOfRows; row++)
            {
                // Dictionary of next paths
                var newPaths = new Dictionary<int, long>();

                foreach (var kv in paths)
                {
                    int col = kv.Key;
                    long count = kv.Value; 

                    char cell = splitterLocations[row, col];

                    if (cell == '^')
                    {
                        // this column splits
                        numOfTimesBeamSplit++;

                        Console.WriteLine($"Beam splitter found at ({row}, {col})");

                        // Adding the beam paths to the dictionary
                        AddBeam(newPaths, col - 1, count); 
                        AddBeam(newPaths, col + 1, count); 
                    }
                    else
                    {
                        // beam continues straight down
                        AddBeam(newPaths, col, count);
                    }
                }

                // Move on to the next row
                paths = newPaths;
            }

            Console.WriteLine($"Search Complete, Beam Split {numOfTimesBeamSplit} times");
            Console.WriteLine($"Number of available paths = {paths.Values.Sum()}");

        }

        public static (int startingRow, int startingCol) FindStartingLocation(char[,] characterArray, int numOfRows, int numOfCols)
        {
            int startingRow = 0;
            int startingColumn = 0;

            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCols; j++)
                {
                    if (characterArray[i, j] == 'S')
                    {
                        startingRow = i;
                        startingColumn = j;
                    }
                }
            }
            Console.WriteLine($"Start found at {startingRow} , {startingColumn}");

            return (startingRow, startingColumn);

        }

        public static void AddBeam(Dictionary<int, long> dict, int col, long count)
        {
            if (dict.ContainsKey(col))
                dict[col] += count;
            else
                dict[col] = count;
        }
    }
}
