using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day6.Services
{
    public static class DataSeparator
    {
        public static List<string[]> TextFileToDataInputsPart1(string filePath)
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

        public static List<List<long>> TextTextFileToDataInputsPart2(string filePath)
        {
            string[] extractedLines = File.ReadAllLines(filePath);

            // Extracting the strings with digits in them
            List<string> digitStrings = new List<string>();
            for(int i = 0; i < extractedLines.Count() - 1; i++)
            {
                digitStrings.Add(extractedLines[i]);
            }

            // Getting the string of mathematical operators
            string mathematicalOperatorsString = extractedLines[extractedLines.Length - 1];
            List<int> separatorIndices = new List<int>();
            for (int i = 0; i < mathematicalOperatorsString.Length; i++)
            {
                if(mathematicalOperatorsString[i] == '*' || mathematicalOperatorsString[i] == '+')
                {
                    separatorIndices.Add(i);
                }
            }

            // Separating the strings out based on this new separator
            List<List<string>> parsedStrings = new List<List<string>>();
            for (int i = 0; i < separatorIndices.Count; i++)
            {
                // Storing the values
                List<string> tempList = new List<string>();

                // Handling the other strings
                foreach(string digitString in digitStrings)
                {
                    // Handling the string at the end
                    if (i == separatorIndices.Count - 1)
                    {
                        string tempString = digitString.Substring(separatorIndices[i]);
                        tempList.Add(tempString);
                    }
                    else
                    {
                        int sizeOfStringSegment = separatorIndices[i + 1] - separatorIndices[i] - 1;
                        string tempString = digitString.Substring(separatorIndices[i], sizeOfStringSegment);
                        tempList.Add(tempString);
                    }
                    
                }

                parsedStrings.Add(tempList);
            }

            // Processing the values into a list of longs based on the columns
            List<List<long>> processedDigits = new List<List<long>>();
            foreach (List<string> digitString in parsedStrings)
            {
                // intialising lists of empty strings
                List<string> tempListOfStrings = new List<string>();
                foreach (string s in digitString)
                {
                    tempListOfStrings.Add("");
                }

                // Extracting the columns to strings
                for (int i = 0; i < digitString[0].Length; i++)
                {
                    foreach(string s in digitString)
                    {
                        tempListOfStrings[i] += s[i];
                    }
                }

                // Turning the strings into Longs and adding to a list
                // Clean up an empty string from somewhere
                List<long> tempLongList = new List<long>();
                foreach(string s in tempListOfStrings)
                {
                    if (s.Length > 0)
                    {
                        string trimmedString = s.Trim();
                        tempLongList.Add(long.Parse(trimmedString));
                    }                    
                }

                processedDigits.Add(tempLongList);
            }

            return processedDigits;
        }

        public static string[] ReturnMathematicalOperators(string filePath)
        {
            string[] extractedLines = File.ReadAllLines(filePath);

            return extractedLines[extractedLines.Count() - 1].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
