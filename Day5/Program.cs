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


// Part 1
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

Console.WriteLine($"Number of acceptable ingredients at Part 1 = {countOfAcceptableIngredients}");


// Part 2
List<List<long>> concatenatedRanges = RangeConcatenator.MergeStartEndLists(acceptableIngredients);
List<List<long>> processedRanges = RangeConcatenator.MergeRanges(concatenatedRanges);
long sum = 0;
foreach(List<long> range in processedRanges)
{
    sum += range[1] - range[0];
}

Console.WriteLine(sum);