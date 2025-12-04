
using Day4.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
bool isPart1 = false;
int runningTotal;

char[,] paperCharactersArray = DataAccessor.TextFileToArrayOfCharacters(filePath);

if (isPart1)
{
    runningTotal = ArrayAnalyser.FindAcceptablePapers(paperCharactersArray);
}
else
{
    runningTotal = ArrayAnalyser.FindAcceptablePaperPart2(paperCharactersArray);
}

Console.WriteLine(runningTotal);