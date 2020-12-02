using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day2
{
    class Day02
    {
        static void Main(string[] args)
        {
            string[] fileData = System.IO.File.ReadAllLines("..\\..\\..\\Values.txt");
            var inputData = DataProcessing(fileData);
            Console.WriteLine("Total Correct Password from Policy 1: " + inputData.Item1);
            Console.WriteLine("Total Correct Password from Policy 2: " + inputData.Item2);
            Console.ReadKey();
        }

        static (int, int) DataProcessing(string[] fileData)
        {
            var Policy1CorrectPasswordCount = 0;
            var Policy2CorrectPasswordCount = 0;
            foreach (var data in fileData)
            {
                var regexGroup = Regex.Matches(data, @"([\d]+)-([\d]+) ([a-z]): ([a-z]+)", RegexOptions.IgnoreCase);
                var FirstNumber = int.Parse(regexGroup[0].Groups[1].Value);
                var SecondNumber = int.Parse(regexGroup[0].Groups[2].Value);
                var Character = char.Parse(regexGroup[0].Groups[3].Value);
                var PasswordToValidate = regexGroup[0].Groups[4].Value;

                //Policy 1 evaluation
                var charOccuranceCounter = PasswordToValidate.Split(Character).Length - 1;
                if (FirstNumber <= charOccuranceCounter && charOccuranceCounter <= SecondNumber)
                    Policy1CorrectPasswordCount++;

                //Policy 2 evaluation
                char Location1Char = PasswordToValidate[FirstNumber - 1];
                char Location2Char = PasswordToValidate[SecondNumber - 1];
                if ((Location1Char != Location2Char) && (Location1Char == Character || Location2Char == Character))
                    Policy2CorrectPasswordCount++;
            }
            return (Policy1CorrectPasswordCount, Policy2CorrectPasswordCount);
        }
    }
}
