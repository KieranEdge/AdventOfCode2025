using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * To Do
 * Start at 50
 * Split string on first character
 * Minus if L
 * Plus if R
 * Count 0s
 */

namespace Day1.Services
{
    public class DataProcessor
    {
        public void ProcessData(List<string> data) 
        {
            bool isLeft = false;
            long currentNumber = 50;
            long comboNumber;
            int count = 0;

            foreach (string line in data)
            {
                // Getting the direction and combo number
                isLeft = DirectionExtractor(line);
                comboNumber = (long)Convert.ToDouble(line.Substring(1));

                // Updating the current number based on the combo number and direction
                if (isLeft)
                {
                    currentNumber = currentNumber - comboNumber;
                }

                else
                {
                    currentNumber = currentNumber + comboNumber;
                }

                if (currentNumber % 100 == 0)
                {
                    count++;
                }

            }

            Console.WriteLine($"Total number of zeroes = {count}");
        }

        public bool DirectionExtractor(string line)
        {
            char c = line[0];

            if (c == 'L')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
