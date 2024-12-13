using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Puzzle
{
    internal class Program
    {
        const int AMOUNT_OF_CHARS_TO_READ = 2;
        const string PATH_TO_FILE = @"G:\Visual Studio Projects\Puzzle\input.txt";

        static void Main(string[] args)
        {
            List<string> fileData = File.ReadAllLines(PATH_TO_FILE).ToList();
            string result = ConcatMatchesIntoString(FindMatches(fileData).Distinct().ToList());

            Console.WriteLine($"Result length: {result.Length} characters");
            Console.WriteLine($"Result: {result}");
        }

        static List<string> FindMatches(List<string> fileData)
        {
            List<string> matches = new List<string>();

            for (int i = 0; i < fileData.Count; i++)
            {
                string firstNumberToFind = fileData[i].Substring(0, AMOUNT_OF_CHARS_TO_READ);
                string secondNumberToFind = fileData[i].Substring(fileData[i].Length - AMOUNT_OF_CHARS_TO_READ);

                for (int j = i + 1; j < fileData.Count; j++)
                {
                    string firstNumberToCompare = fileData[j].Substring(0, AMOUNT_OF_CHARS_TO_READ);
                    string secondNumberToCopmare = fileData[j].Substring(fileData[j].Length - AMOUNT_OF_CHARS_TO_READ);

                    if (firstNumberToFind.Equals(secondNumberToCopmare))
                    {
                        matches.Add(fileData[j]);
                        matches.Add(fileData[i]);
                    }

                    if (secondNumberToFind.Equals(firstNumberToCompare))
                    {
                        matches.Add(fileData[i]);
                        matches.Add(fileData[j]);
                    }
                }
            }

            return matches;
        }

        static string ConcatMatchesIntoString(List<string> matches)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < matches.Count; i++)
            {
                result.Append(i + 1 < matches.Count ? matches[i].Substring(0, matches[i].Length - AMOUNT_OF_CHARS_TO_READ) : matches[i]);
            }

            return result.ToString();
        }
    }
}
