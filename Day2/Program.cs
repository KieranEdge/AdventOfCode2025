using Day2.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
List<List<long>> allRanges= DataProcessor.DataTextToListsOfInts(filePath);
int numOfRanges = allRanges[0].Count;
List<long> runningMatchingValues = new List<long>();

for (int i = 0; i < numOfRanges; i++)
{
    // Getting the ranges
    long rangeStart = allRanges[0][i];
    long rangeEnd = allRanges[1][i];
    List<long> range = DataProcessor.RangeConstructor(rangeStart, rangeEnd);
    List<long> matchingStrings = TextAnalyser.FindInvalidPatterns(range);
    foreach (long pattern in matchingStrings)
    {
        runningMatchingValues.Add(pattern);
    }
}

long result = DataProcessor.ReturnSumOfMatchingPatterns(runningMatchingValues);
Console.WriteLine(result);