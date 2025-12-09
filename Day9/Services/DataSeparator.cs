namespace Day9.Services
{
    public static class DataSeparator
    {
        public static List<List<long>> DataFileToArrayOfLongs(string filePath)
        {
            string[] array = File.ReadAllLines(filePath);
            List<List<long>> coordinatePairsList = new List<List<long>>();

            foreach (string line in array)
            {
                List<long> coordinatePairs = new List<long>();
                string[] strings = line.Split(',');
                foreach (string s in strings)
                {
                    coordinatePairs.Add(long.Parse(s));
                }
                coordinatePairsList.Add(coordinatePairs);
            }

            return coordinatePairsList;
        }
    }
}