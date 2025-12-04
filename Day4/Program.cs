
using Day4.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
bool isPart1 = false;

char[,] paperCharactersArray = DataAccessor.TextFileToArrayOfCharacters(filePath);

ArrayAnalyser.FindAcceptablePapers(paperCharactersArray);