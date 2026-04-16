using Day8.Services;

string filePath = Path.Combine(AppContext.BaseDirectory, "Data.txt");
List<List<long>> listOfJunctionBoxLocations = DataExtractor.ExtractDataToListsOfLongs(filePath);

JunctionMapper.JunctionMapperInDictionary(listOfJunctionBoxLocations);