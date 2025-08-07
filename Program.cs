using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth_Year_to_Age_Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> birthYearInputs = new List<string>();
            Dictionary<int, string> classifications = new Dictionary<int, string>();
            int currentYear = DateTime.Now.Year;

            Console.WriteLine("Enter 5 birth years:");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Birth year #{i + 1}: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || !IsValidYear(input))
                {
                    Console.WriteLine("Invalid input. Please enter a valid 4-digit year.");
                    i--; // Retry current input
                    continue;
                }

                birthYearInputs.Add(input);
            }
            
            Console.WriteLine("\nAge Classification:");
            
            foreach (string yearInput in birthYearInputs)
            {
                int birthYear = Convert.ToInt32(yearInput);
                int age = currentYear - birthYear;

                string classification;
                if (age < 18)
                    classification = "Minor";
                else if (age <= 65)
                    classification = "Adult";
                else
                    classification = "Senior";

                Console.WriteLine($"Birth Year: {birthYear} | Age: {age} | Classification: {classification}");
            }
        }
        static bool IsValidYear(string input)
        {
            if (!int.TryParse(input, out int year) || year < 1900 || year > DateTime.Now.Year)
                return false;
            return true;
        }
    }
}
