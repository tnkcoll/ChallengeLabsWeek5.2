using System.Dynamic;
using System.Runtime.CompilerServices;

namespace ChallengeLabsWeek5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = GetArrayOfIntsFromUser("Please enter a range of numbers in sequence that is missing one digit. . Ex: 5412, sequence from 1-5 missing the 3.");
            int missingNumber = GetMissingInt(ints);
            if (missingNumber != -1)
            {
                Console.WriteLine("The missing number is: {0}", missingNumber);
            }
            else
            {
                Console.WriteLine("There is no missing number.");
            }
        }

        static int[] GetArrayOfIntsFromUser(string s)
        {
            string? userInput = "";

            do
            {
                Console.WriteLine(s);
                userInput = Console.ReadLine();
            } while (userInput == "");

            int[] ints = new int[userInput.Length];

            for (int i = 0; i < userInput.Length; i++)
            {
                double num = char.GetNumericValue(userInput[i]);
                ints[i] = Convert.ToInt32(num);
            }
            return ints;
        }

        static int GetMissingInt(int[] array)
        {
  

            Dictionary<int,int> numbers = new Dictionary<int,int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (numbers.ContainsKey(array[i]))
                {
                    numbers[array[i]]++;
                }
                else
                {
                    numbers[array[i]] = 1;
                }
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (!numbers.ContainsKey(i))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
