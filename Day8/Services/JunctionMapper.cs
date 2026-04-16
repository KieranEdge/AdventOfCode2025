using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Services
{
    public static class JunctionMapper
    {
        public static void JunctionMapperInDictionary(List<List<long>> junctionBoxLocations)
        {
            // Initialising the list and the count
            Dictionary<int, List<double>> junctionMap = new Dictionary<int, List<double>>();
            Dictionary<int, List<int>> circuits = new Dictionary<int, List<int>>();


            int countOfJunctionBoxes = junctionBoxLocations.Count;

            for (int i = 0; i < countOfJunctionBoxes; i++)
            {
                List<long> comparingJunction = junctionBoxLocations[i];
                List<double> distancesToOtherJunctions = new List<double>();
                circuits.Add(i, new List<int>());

                foreach (List<long> junctionBoxLocation in junctionBoxLocations)
                {
                    distancesToOtherJunctions.Add(DistanceBetweenJunctionBoxes(comparingJunction, junctionBoxLocation));
                }
                junctionMap.Add(i, distancesToOtherJunctions);
            }

            foreach (var kv in junctionMap)
            {
                int junctionBoxIndex = kv.Key;
                List<double> distancesToOtherBoxes = kv.Value;
                for (int i = 0; i < distancesToOtherBoxes.Count; i++)
                {
                    Console.WriteLine($"Distance from junction box {junctionBoxIndex} to junction box{i}: {distancesToOtherBoxes[i]}");
                }
            }
        }

        public static double DistanceBetweenJunctionBoxes(List<long> startingJunctionBoxLocation, List<long> endingJunctionBoxLocations)
        {
            // Getting the distances in x, y and z
            long x_distance = startingJunctionBoxLocation[0] - endingJunctionBoxLocations[0];
            long y_distance = startingJunctionBoxLocation[1] - endingJunctionBoxLocations[1];
            long z_distance = startingJunctionBoxLocation[2] - endingJunctionBoxLocations[2];

            return Math.Sqrt((x_distance * x_distance) + (y_distance * y_distance) + (z_distance * z_distance));
        }
    }
}
