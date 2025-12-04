using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Services
{
    public class ArrayAnalyser
    {
        public static void FindAcceptablePapers(char[,] array)
        {
            int numOfAcceptablePaper = 0;

            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {
                    char c = array[i, j];
                    if (c == '@')
                    {
                        if (isAcceptablePaper(array, i, j))
                        {
                            numOfAcceptablePaper++;
                        }
                    }
                }
            }

            Console.WriteLine($"Acceptable paper locations = {numOfAcceptablePaper}");
        }

        public static bool isAcceptablePaper(char[,] array, int row, int col)
        {
            // Initialising count of surrounding paper
            int count = 0;

            // Sweeping in all directions

            // Top Left
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (array[row - 1, col - 1] == '@')
                {
                    count++;
                }
            }

            // Top
            if (row - 1 >= 0)
            {
                if (array[row - 1, col] == '@')
                {
                    count++;
                }
            }

            // Top Right
            if (row - 1 >= 0 && col + 1 < array.GetLength(1))
            {
                if (array[row - 1, col + 1] == '@')
                {
                    count++;
                }
            }

            // Left
            if (col - 1 >= 0)
            {
                if (array[row, col - 1] == '@')
                {
                    count++;
                }
            }

            // Right
            if (col + 1 < array.GetLength(1))
            {
                if (array[row, col + 1] == '@')
                {
                    count++;
                }
            }

            // Bottom Left
            if (row + 1 < array.GetLength(0) && col - 1 >= 0)
            {
                if (array[row + 1, col - 1] == '@')
                {
                    count++;
                }
            }

            // Bottom
            if (row + 1 < array.GetLength(0))
            {
                if (array[row + 1, col] == '@')
                {
                    count++;
                }
            }

            // Bottom Right
            if (row + 1 < array.GetLength(0) && col + 1 < array.GetLength(1))
            {
                if (array[row + 1, col + 1] == '@')
                {
                    count++;
                }
            }
            
            return count < 4;
        }
    }
}
