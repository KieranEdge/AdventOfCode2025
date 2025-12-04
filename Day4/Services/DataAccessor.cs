using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4.Services
{
    public class DataAccessor
    {
        public static char[,] TextFileToArrayOfCharacters(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int cols = lines[0].Length;
            Console.WriteLine($"Initialising array of {rows} rows, and {cols} columns");

            char[,] charactersArray = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] tempCharactersArray = lines[i].ToCharArray();

                for (int j = 0; j < cols; j++) 
                {
                    charactersArray[i, j] = tempCharactersArray[j]; 
                }
            }
            
            return charactersArray;
        }
    }
}
