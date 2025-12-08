
namespace Day6.Services
{
    public static class ListOperator
    {
        public static long SumOfAllFunctions(List<string[]> functions, bool isPart1)
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

                // Creating the long list for part 1
                if (isPart1)
                {
                    foreach (string[] figureArray in figuresToCalculate)
                    {
                        longFigures.Add((long)Convert.ToDouble(figureArray[i]));
                    }
                }
                // Creatng the long list for part 2
                else
                {
                    // Getting the column as strings
                    List<string> stringFiguresInColumn = new List<string>();
                    foreach(string[] figureArray in figuresToCalculate)
                    {
                        Console.WriteLine($"Strings to sort {figureArray[i]}");
                        stringFiguresInColumn.Add(figureArray[i]);
                    }

                    longFigures = ListReworker(stringFiguresInColumn);
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

        public static List<long> ListReworker(List<string> listToBeReworked)
        {
            // Breaking the list into columns as we know the max is 4 digits
            List<List<string>> list = new List<List<string>>();
            List<List<char>> listOfDigits = new List<List<char>>();
            List<long> longSortedDigits = new List<long>();
            
            int maxStringSize = 0;

            // Getting the max number of digits to begin making a list
            foreach (string s in listToBeReworked)
            {
                int stringSize = s.Length;
                if(stringSize > maxStringSize)
                {
                    maxStringSize = stringSize;
                }
            }

            // Creating a list of columns
            for (int i = 0; i < maxStringSize; i++)
            {
                
                List<char> tempList = new List<char>();
                foreach (string s in listToBeReworked)
                {
                    if (i < s.Length)
                    {
                        tempList.Add(s[i]);
                    }
                }

                listOfDigits.Add(tempList);
            }

            // Reordering the columns
            foreach (List<char> digitCol in listOfDigits)
            {
                // Adding the digits to a new list
                List<int> temporaryDigitList = new List<int>();
                foreach (char c in digitCol)
                {
                    temporaryDigitList.Add(Convert.ToInt32(Convert.ToString(c)));
                }

                // Sorting the digits largest to shortest
                temporaryDigitList.Sort((a, b) => b.CompareTo(a));

                // Concatenating the list of sorted digits into a string
                string tempString = "";
                foreach (int i in temporaryDigitList)
                {
                    tempString += Convert.ToString(i);
                }
                Console.WriteLine($"Sorted digits = {tempString}");

                // Converting to long and adding to the list
                longSortedDigits.Add((long)Convert.ToDouble(tempString));
            }
            Console.ReadLine();
            return longSortedDigits;
        }
    }
}
