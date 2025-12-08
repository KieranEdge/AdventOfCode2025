using System;
using System.Collections.Generic;
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

            // Getting the starting coordinates
            var startingCoordinates = FindStartingLocation(splitterLocations, numOfRows, numOfCols);
            int startingRow = startingCoordinates.startingRow;
            int startingCol = startingCoordinates.startingCol;

            // Searching for beams row by row
            List<int> beamColumns = new List<int> {startingCol };

            int numOfTimesBeamSplit = 0;

            for (int i = 0; i < numOfRows; i++)
            {
                List<int> listOfNewBeams = new List<int>();

                foreach(int searchColumn in beamColumns)
                {
                    if (splitterLocations[i, searchColumn] == '^')
                    {
                        // Adding beams to the left and right
                        Console.WriteLine($"Beam splitter found at ({i}, {searchColumn})");
                        // Console.ReadLine();
                        listOfNewBeams.Add(searchColumn - 1);
                        listOfNewBeams.Add(searchColumn + 1);
                        numOfTimesBeamSplit++;
                    }
                    else
                    {
                        // Retaining the beam for the next run if a splitter isn't found
                        listOfNewBeams.Add(searchColumn);
                    }
                }
                beamColumns = listOfNewBeams.Distinct().ToList();
            }

            Console.WriteLine($"Search Complete, Beam Split {numOfTimesBeamSplit} times");

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
    }
}
