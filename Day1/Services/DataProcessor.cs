using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void ProcessData(List<string> data, bool isPart1) 
        {
            bool isLeft = false;
            int currentNumber = 50;
            int comboNumber;
            int count = 0;

            foreach (string line in data)
            {
                // Getting the direction and combo number
                isLeft = DirectionExtractor(line);
                comboNumber = (int)Convert.ToInt32(line.Substring(1));

                // Updating the current number based on the combo number and direction
                if (isPart1)
                {
                    // Updating the combo for part 1
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

                    Console.WriteLine($"Total number of zeroes landed on = {count}");
                }

                else
                {
                    // Find the amount of times the dial was at 0
                    count += TimesPassedZero(isLeft, currentNumber, comboNumber);

                    // Updating the current number
                    if (isLeft)
                    {
                        currentNumber = currentNumber - comboNumber;
                    }

                    else
                    {
                        currentNumber = currentNumber + comboNumber;
                    }   
                }
            }
            Console.WriteLine($"Total number of zeroes passed or landed on = {count}");

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

        public int TimesPassedZero(bool isLeft, int currentNumber, int comboNumber)
        {
            // Creating the range of numbers that the dial passes through when turning
            int[] ints;
            if (isLeft)
            {
                ints = Enumerable.Range(currentNumber - comboNumber, comboNumber).ToArray();
            }
            else
            {
                ints = Enumerable.Range(currentNumber + 1, comboNumber).ToArray();
            }

            // Counting the number of dial positions
            int count = 0;
            foreach(int dialNumber in ints)
            {
                if (dialNumber % 100 == 0)
                {
                    count++;
                }
            }
            
            return count;
        }
    }
}
