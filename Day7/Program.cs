using Day7.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
char[,] characterArray = DataExtractor.DataFileToCharacterArray(filePath);

BeamSplitter.FindBeamSplitters(characterArray);