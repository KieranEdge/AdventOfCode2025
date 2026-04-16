using Day9.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
bool isPart1 = false;

List<List<long>> coordinatePairsList = DataSeparator.DataFileToArrayOfLongs(filePath);
int coordinatePairsCount = coordinatePairsList.Count;
Console.WriteLine($"{coordinatePairsList.Count} coordinate pairs found");
Console.WriteLine(coordinatePairsList[coordinatePairsCount - 1][1]);

List<long> rectangleSizes = new List<long>();

if (isPart1)
{
    for (int i = 0; i < coordinatePairsCount; i++)
    {
        Console.WriteLine($"Searching at index {i}");
        rectangleSizes.Add(GeometryCalculator.FindLargestRectangle(coordinatePairsList, i));
    }
}
else
{
    char[,] tileArray = MatrixCreator.MatrixFromTextStyle(coordinatePairsList);
}


Console.WriteLine($"Max rectangle size = {rectangleSizes.Max()}");