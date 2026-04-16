using Day_12.Data;

string filePath = "C:\\Users\\Kieran Edge\\source\\repos\\AdventOfCode2025\\Day 12\\Data.txt";

Dictionary<string, List<string>> keyValuePairs = DataExtractor.TextFileToDictionary(filePath);

List<string> startingPaths = keyValuePairs["you"];

foreach (string startingPath in startingPaths)
{
    Console.WriteLine(startingPath);
}
