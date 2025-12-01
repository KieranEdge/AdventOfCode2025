using Day1.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
List<string> instructions = DataAccessor.TextFileToListOfInstructions(filePath);

DataProcessor dataProcessor = new DataProcessor();
dataProcessor.ProcessData(instructions);