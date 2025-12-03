using Day2.Services;

// Setting the program parameters
string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
bool isPart1 = true;

// Extracting the file data to a list of numbers
List<List<long>> allRanges= DataProcessor.DataTextToListsOfLongs(filePath);
int numOfRanges = allRanges[0].Count;

// List for getting the total value of InvalidIDs
List<long> runningMatchingValues = new List<long>();

for (int i = 0; i < numOfRanges; i++)
{
    // Getting the ranges
    long rangeStart = allRanges[0][i];
    long rangeEnd = allRanges[1][i];
    
    // Constructing the ranges
    List<long> range = DataProcessor.RangeConstructor(rangeStart, rangeEnd);
    
    List<long> invalidIds = new List<long>();

    if (isPart1)
    {
        invalidIds = TextAnalyser.FindInvalidPatternsPart1(range);
    }

    else
    {
        invalidIds = TextAnalyser.FindInvalidPatternsPart2(range);
    }

    foreach (long pattern in invalidIds)
    {
        runningMatchingValues.Add(pattern);
    }
}

long result = DataProcessor.ReturnSumOfMatchingPatterns(runningMatchingValues);
Console.WriteLine(result);