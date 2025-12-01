using Day1.Services;

// Getting the instructions from the data file
string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
List<string> instructions = DataAccessor.TextFileToListOfInstructions(filePath);

// Processing the data
bool isPart1 = false;
DataProcessor dataProcessor = new DataProcessor();

dataProcessor.ProcessData(instructions, isPart1);