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
            var inputData = InputMapping(fileData);
            int counter = InputValidationCount(inputData);
            Console.WriteLine("Total Count: " + counter);
            Console.ReadKey();
        }

        static List<InterpreterClass> InputMapping(string[] fileData)
        {
            List<InterpreterClass> listofobject = new List<InterpreterClass>();
            foreach (var data in fileData)
            {
                InterpreterClass sample = new InterpreterClass();
                var a = Regex.Matches(data, @"([0-9]{1,3})(?=-)", RegexOptions.IgnoreCase);
                sample.MinCount = int.Parse(a[0].Value);
                var b = Regex.Matches(data, @"([0-9]{1,3})(?= )", RegexOptions.IgnoreCase);
                sample.MaxCount = int.Parse(b[0].Value);
                var c = Regex.Matches(data, @"([a-z]{1})(?=:)", RegexOptions.IgnoreCase);
                sample.Character = char.Parse(c[0].Value);
                sample.ValidationInput = data.Split(' ')[2];
                listofobject.Add(sample);
            }
            return listofobject;
        }

        static int InputValidationCount(List<InterpreterClass> interpreters)
        {
            int count = 0;
            int loopCounter ;
            foreach (var data in interpreters)
            {
                loopCounter = 0;
                loopCounter = data.ValidationInput.Split(data.Character).Length - 1;
                if(data.MinCount<=loopCounter && loopCounter <= data.MaxCount)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
