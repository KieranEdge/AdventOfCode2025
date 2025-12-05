using Day5.Services;

// File Paths
string rangeFilePath = Path.Combine(AppContext.BaseDirectory, "RangeData.txt");
string ingredientsFilePath = Path.Combine(AppContext.BaseDirectory, "IngredientData.txt");

// Extracting the data from the string
List<List<long>> acceptableIngredients = DataExtractor.RangeDataExtractor(rangeFilePath);
List<long> ingredients = DataExtractor.ListOfIngredientsAsLongs(ingredientsFilePath);
int numberOfRanges = acceptableIngredients[0].Count;

// Finding the number of acceptable ingredients
int countOfAcceptableIngredients = 0;

foreach(long ingredient in ingredients)
{
    bool ingredientFound = false;
    
    for (int i = 0; i < numberOfRanges; i++)
    {
        if (ingredientFound)
        {
            continue;
        }
        else
        {
            if (ingredient >= acceptableIngredients[0][i] && ingredient <= acceptableIngredients[1][i])
            {
                countOfAcceptableIngredients++;
                ingredientFound = true;
            }
        }
    }
}

Console.WriteLine($"Number of acceptable ingredients = {countOfAcceptableIngredients}");