using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Services
{
    public class MatrixCreator
    {
        public static char[,] MatrixFromTextStyle(List<List<long>> coordinatePairs)
        {
            long maxRow = 0;
            long maxCol = 0;

            // Initialising the array
            foreach (List<long> coordinatePair in coordinatePairs)
            {
                if (coordinatePair[0] >  maxRow) maxRow = coordinatePair[0];
                if (coordinatePair[1] > maxCol) maxCol = coordinatePair[1];
            }

            char[,] arrayOfCharacters = new char[maxRow, maxCol];

            // Populating with .
            for (int i = 0; i < maxRow; i++)
            {
                for (int j = 0; j < maxCol; j++)
                {
                    arrayOfCharacters[i, j] = '.';
                }
            }

            // Populating the red tiles
            foreach(List<long> coordinatePair in coordinatePairs)
            {
                arrayOfCharacters[coordinatePair[0], coordinatePair[1]] = '#';
            }

            // Writing the array to a text file
            MatrixToTextFile(arrayOfCharacters);


            return arrayOfCharacters;
        }

        public static void MatrixToTextFile(char[,] matrix)
        {
            // Writing the values
            using var writer = new StreamWriter("output.txt");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    writer.Write(matrix[i, j]);
                }

                writer.WriteLine();
            }
        }
    }
}
