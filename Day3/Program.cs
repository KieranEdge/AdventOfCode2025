using Day3.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");

List<List<int>> batteryRows = DataProcessor.TextFileToListOfListOfInts(filePath);
List<int> maxJoltages = new List<int>();

foreach (var batteryRow in batteryRows)
{
    maxJoltages.Add(RowAnalyser.MaxJoltageCalculator(batteryRow));
}

Console.WriteLine($"Sum of max joltages = {maxJoltages.Sum()}");