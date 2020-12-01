using System;
using System.IO;

namespace Adventofcode
{
    class Day01
    {
        private static void Main(string[] args)
        {
            string[] fileData = System.IO.File.ReadAllLines("..\\..\\..\\Values.txt");
            int[] numbers = Array.ConvertAll(fileData, s => int.Parse(s));
            (int, int) answer = FindProductofIntegrerThatHasSumof2020(numbers);
            Console.WriteLine("\n Answer 1 is:" + answer.Item1);
            Console.WriteLine("\n Answer 2 is:" + answer.Item2);
            Console.ReadKey();
        }

        public static (int, int) FindProductofIntegrerThatHasSumof2020(int[] numbers)
        {
            int answer1 = 0;
            var answer2 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if ((numbers[i] + numbers[j]) == 2020)
                    {
                        answer1 = numbers[i] * numbers[j];
                    }
                    answer2 = FindProductofThreeIntegrerThatHasSumof2020(numbers, answer2, i, j);
                }
            }
            return (answer1, answer2);
        }

        private static int FindProductofThreeIntegrerThatHasSumof2020(int[] numbers, int answer2, int i, int j)
        {
            if ((numbers[i] + numbers[j]) < 2020)
            {
                for (int k = i + 1; k < numbers.Length; k++)
                {
                    if ((numbers[i] + numbers[j] + numbers[k]) == 2020)
                    {
                        answer2 = numbers[i] * numbers[j] * numbers[k];
                    }
                }
                return answer2;
            }
            return answer2;
        }
    }
}
