using Day3.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");

List<List<int>> batteryRows = DataProcessor.TextFileToListOfListOfInts(filePath);

foreach (List<int> batteryRow in batteryRows)
{
    foreach(int battery in batteryRow)
    {
        Console.WriteLine(battery);
    }
}
