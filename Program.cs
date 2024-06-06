using System.Dynamic;
using System.Runtime.CompilerServices;

namespace ChallengeLabsWeek5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Call the method to get the numbers from the user.
            int[] ints = GetArrayOfIntsFromUser("Please enter a range of numbers in sequence that is missing one digit. . Ex: 5412, sequence from 1-5 missing the 3.");
            
            //Send the array of ints to the method to get the missing number.
            int missingNumber = GetMissingInt(ints);
            
            //If the missing number we received form the GetMissingInt method is not -1, print the missing number.
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

            //Instatntiate a new array of ints with a length of the user's number.
            int[] ints = new int[userInput.Length];

            //Get the numeric value of each number in the user's multi-digit number.
            for (int i = 0; i < userInput.Length; i++)
            {
                double num = char.GetNumericValue(userInput[i]);
                ints[i] = Convert.ToInt32(num);
            }
            return ints;
        }

        static int GetMissingInt(int[] array)
        {
            int minNumber = array.Min();
            int maxNumber = array.Max();
  
            //Instantiate a new dictionary to hold the ints from the int array we created in the GetArrayOfIntsFromUser method.
            Dictionary<int,int> numbers = new Dictionary<int,int>();

            //Populate the dictionary with the ints from the array.
            for (int i = 0; i < array.Length; i++)
            {
                if (!numbers.ContainsKey(array[i]))
                {
                    numbers[array[i]] = 1;
                }
                else
                {
                    numbers[array[i]] = 0;
                }
            }


            //Parse the dictionary to see i
            for (int i = minNumber; i < maxNumber; i++)
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
