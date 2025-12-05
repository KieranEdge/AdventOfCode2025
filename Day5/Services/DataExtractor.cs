using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Services
{
    internal static class DataExtractor
    {
        public static List<List<long>> RangeDataExtractor(string filePath)
        {
            // Getting the data from the text file
            string[] listOfRanges = File.ReadAllLines(filePath);

            // Converting to longs and adding to a list
            List<long> ingredientsInBottomOfRange = new List<long>();
            List<long> ingredientsInTopOfRange = new List<long>();
            List<List<long>> combinedRanges = new List<List<long>>();

            foreach (string range in listOfRanges)
            {
                long rangeStart = long.Parse(range.Split('-')[0]);
                long rangeEnd = long.Parse(range.Split('-')[1]);

                ingredientsInBottomOfRange.Add(rangeStart);
                ingredientsInTopOfRange.Add(rangeEnd);
            }

            combinedRanges.Add(ingredientsInBottomOfRange);
            combinedRanges.Add(ingredientsInTopOfRange);

            return combinedRanges;

        }

        public static List<long> ListOfIngredientsAsLongs(string filePath)
        {
            // Getting all of the ingredients as an array
            string[] lines = File.ReadAllLines(filePath);

            // Iterating over them and returning them as a list
            List<long> ingredients = new List<long>();
            foreach (string line in lines)
            {
                ingredients.Add(long.Parse(line));
            }
            return ingredients;
        }
    }
}
