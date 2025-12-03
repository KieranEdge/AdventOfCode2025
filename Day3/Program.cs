using Day3.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
bool isPart1 = false;

List<List<int>> batteryRows = DataProcessor.TextFileToListOfListOfInts(filePath);
List<long> maxJoltages = new List<long>();

foreach (var batteryRow in batteryRows)
{
    if (isPart1)
    {
        maxJoltages.Add(RowAnalyser.MaxJoltageCalculatorPart1(batteryRow));
        Console.WriteLine($"Sum of max joltages Part 1= {maxJoltages.Sum()}");
    }
    else
    {
        maxJoltages.Add(RowAnalyser.MaxJoltageCalculatorPart2(batteryRow));
    }   
}

Console.WriteLine($"Sum of max joltages Part 2 = {maxJoltages.Sum()}");