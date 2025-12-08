using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Services
{
    public static class DataExtractor
    {
        public static char[,] DataFileToCharacterArray(string filePath)
        {
            string[] strings = File.ReadAllLines(filePath);
            int numOfRows = strings.Length;
            int numOfCols = strings[0].Length;
            char[,] characterArray= new char[numOfRows, numOfCols];

            for (int i = 0; i < numOfRows; i++)
            {
                for(int j = 0; j < numOfCols; j++)
                {
                    characterArray[i,j] = strings[i][j];
                }
            }

            return characterArray;
        }
    }
}
