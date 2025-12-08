using Day6.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
bool isPart1 = false;

List<string[]> rowsOfFigures = DataSeparator.TextFileToDataInputs(filePath);

long sum = ListOperator.SumOfAllFunctions(rowsOfFigures, isPart1);

if (isPart1)
{
    Console.WriteLine($"Sum for part 1: {sum}");
}
else
{
    Console.WriteLine($"Sum for part 2: {sum}");
}
