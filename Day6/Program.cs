using Day6.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");

List<string[]> rowsOfFigures = DataSeparator.TextFileToDataInputs(filePath);

long sum = Part1.SumOfAllFunctions(rowsOfFigures);

Console.WriteLine($"Sum for part 1: {sum}");