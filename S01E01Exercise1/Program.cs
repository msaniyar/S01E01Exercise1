using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S01E01Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                YearExercises();

                if (!EmailValidation())
                {
                    Console.WriteLine("Your email is not valid.");
                }
                else
                {
                    Console.WriteLine("Your email is valid.");
                }

                SumCalculation();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        public static void YearExercises()
        {
            Console.WriteLine("Current date is: " + DateTime.Now);
            Console.WriteLine("Day of the year: " + DateTime.Now.DayOfYear);

            var thisYear = DateTime.Now.Year;

            for (int i = thisYear; i < 9999; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    DateTime firstDay = new DateTime(i, 1, 1);
                    if (firstDay.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        Console.WriteLine("Next leap year that starts with Tuesday: " + i);
                        break;
                    }
                }
            }
        }

        public static bool EmailValidation()
        {
            Console.WriteLine("Enter your email address for validity check");
            var email = Console.ReadLine();
            if (!email.Contains("@"))
            {
                return false;
            }

            var emailSplitted = email.Split('.');
            if (emailSplitted.Length != 2)
            {
                return false;
            }
            return true;
        }

        public static void SumCalculation()
        {
            Console.WriteLine("Enter your number sequence with one space between each number:");
            var userInput = Console.ReadLine();
            var userInputSplitted = userInput.Split(' ');
            var sum = 0;
            foreach (var input in userInputSplitted)
            {
                sum = sum + int.Parse(input);
            }
            Console.WriteLine("Sum is: {0}", sum);
        }

    }
}
