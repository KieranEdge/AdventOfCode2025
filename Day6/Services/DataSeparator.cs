using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6.Services
{
    public static class DataSeparator
    {
        public static List<string[]> TextFileToDataInputs(string filePath)
        {
            string[] extractedLines = File.ReadAllLines(filePath);
            List<string[]> extractedArrayOfFigures = new List<string[]>();
            foreach (string line in extractedLines)
            {
                string[] extractedFigures = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                extractedArrayOfFigures.Add(extractedFigures);
            }
            return extractedArrayOfFigures;
        }
    }
}
