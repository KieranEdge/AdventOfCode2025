
namespace Day6.Services
{
    public static class Part1
    {
        public static long SumOfAllFunctions(List<string[]> functions)
        {
            // Initialising the running sum
            long sum = 0;

            // Extracting the function operators
            string[] mathematicalFunctions = functions[functions.Count - 1];

            // Extracting the figures
            List<string[]> figuresToCalculate = new List<string[]>();
            for (int i = 0; i < functions.Count - 1; i++)
            {
                figuresToCalculate.Add(functions[i]);
            }

            // Iterating over the columns
            for (int i = 0; i < figuresToCalculate[0].Length; i++)
            {
                // Creating a list for each column
                List<long> longFigures = new List<long>();
                //Console.WriteLine("Figures to operate on");

                foreach (string[] figureArray in figuresToCalculate)
                {
                    longFigures.Add((long)Convert.ToDouble(figureArray[i]));
                    // Console.WriteLine(figureArray[i]);
                }

                //Console.WriteLine($"Mathematical operator to apply: {mathematicalFunctions[i]}");
                long sumAfterOperation = 0;

                if (mathematicalFunctions[i] == "*")
                {
                    sumAfterOperation = MultiplyValues(longFigures);
                    sum += sumAfterOperation;
                }
                else
                {
                    sumAfterOperation = AddValues(longFigures);
                    sum += sumAfterOperation;
                }
                //Console.WriteLine($"Sum after operation {sumAfterOperation}");
                //Console.ReadLine();

            }
            
            return sum;
        }

        public static long MultiplyValues(List<long> figuresToMultiply)
        {
            long sum = figuresToMultiply[0];
            int numOfFigures = figuresToMultiply.Count;

            for (int i = 1; i < numOfFigures; i++)
            {
                sum *= figuresToMultiply[i];
            }
            return sum;
        }
        
        public static long AddValues(List<long> figuresToMultiply)
        {
            long sum = figuresToMultiply[0];
            int numOfFigures = figuresToMultiply.Count;

            for (int i = 1; i < numOfFigures; i++)
            {
                sum += figuresToMultiply[i];
            }
            return sum;
        }

        
    }
}
