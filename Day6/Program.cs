using Day6.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
bool isPart1 = false;

if (isPart1)
{
    List<string[]> rowsOfFigures = DataSeparator.TextFileToDataInputsPart1(filePath);
    long sum = ListOperator.SumOfAllFunctions(rowsOfFigures, isPart1);
    Console.WriteLine($"Sum for part 1: {sum}");
}
else
{
    List<List<long>> processedDigits = DataSeparator.TextTextFileToDataInputsPart2(filePath);
    string[] mathematicalOperators = DataSeparator.ReturnMathematicalOperators(filePath);
    long sum = 0;

    for (int i = 0; i < processedDigits.Count; i++)
    {
        if (mathematicalOperators[i] == "*")
        {
            sum += ListOperator.MultiplyValues(processedDigits[i]);
        }
        else
        {
            sum += ListOperator.AddValues(processedDigits[i]);
        }
    }

    Console.WriteLine($"Sum for part 2: {sum}");

}

