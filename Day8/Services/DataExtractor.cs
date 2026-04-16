namespace Day8.Services
{
    public static class DataExtractor
    {
        public static List<List<long>> ExtractDataToListsOfLongs(string filePath)
        {
            string[] stringsInFile = File.ReadAllLines(filePath);
            List<List<long>> listofJunctionBoxLocations = new List<List<long>>();

            foreach (string str in stringsInFile)
            {
                List<long> longs = new List<long>();
                string[] coordinates = str.Split(',');
                foreach (string coordinatesString in coordinates)
                {
                    longs.Add(long.Parse(coordinatesString));
                }
                listofJunctionBoxLocations.Add(longs);
            }

            return listofJunctionBoxLocations;
        }
    }
}
