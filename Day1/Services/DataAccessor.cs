using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Services
{
    public static class DataAccessor
    {
        public static List<string> TextFileToListOfInstructions(string filePath)
        {
            var list = new List<string>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                list.Add(line);
            }
            return list;
        }
    }
}
