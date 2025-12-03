using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Services
{
    public static class DataProcessor
    {
        public static List<List<int>> TextFileToListOfListOfInts(string filePath)
        {
            List<List<int>> batteryRows = new List<List<int>>();
            
            List<string> fileLines = File.ReadLines(filePath).ToList();

            foreach (string line in fileLines)
            {
                List<int> batteryRow = new List<int>();
                foreach (char c in line)
                {

                    string batteryValueStr = Convert.ToString(c);
                    int batteryValue = Convert.ToInt32(batteryValueStr);
                    batteryRow.Add(batteryValue);
                }
                batteryRows.Add(batteryRow);
            }

            return batteryRows;
        }
    }
}
