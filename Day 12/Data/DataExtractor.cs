using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12.Data
{
    internal class DataExtractor
    {
        public static Dictionary<string, List<string>> TextFileToDictionary(string filePath)
        {
            string[] allLinesInFile = File.ReadAllLines(filePath);
            Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();

            foreach (string line in allLinesInFile)
            {
                // Split the string on the colon to get the key
                string[] splitStringOnColon = line.Split(": ");
                string key = splitStringOnColon[0];

                string[] paths = splitStringOnColon[1].Split(" ");
                List<string> values = new List<string>();
                foreach (string path in paths)
                {
                    values.Add(path);
                }

                keyValuePairs.Add(key, values);
                
            }

            return keyValuePairs;
        }
    }
}
