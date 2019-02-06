using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentVariableTarget = System.EnvironmentVariableTarget;

namespace S01E01Exercise1
{
    class Program
    {
        /* SUMMARY of app: 
           The app will write to console the following:
           Current date (year, month, day only)
           Number of days elapsed since start of the year
           What is the next leap year that starts with a Tuesday
           The app ask for an email address and then say if it is a valid email address
           The app ask for a sequence of numbers and then write out the sum of all those numbers (user decides how many numbers)
         */
        static void Main(string[] args)
        {

            Console.WriteLine("This apps shows current date, elapsed day since start of the year and next leap year that starts with a Tuesday");
            Console.WriteLine("Then you can validate email and get sum of given numbers");
            Console.WriteLine("For exiting to application type \"Exit\" before typing email: \n");

            while (true)
            {

                try
                {
                    YearExercises();

                    Console.WriteLine("Enter your email address for validity check");
                    var email = Console.ReadLine();
                    if (email == "Exit")
                    {
                        break;
                    }

                    if (!EmailValidation(email))
                    {
                        Console.WriteLine("Your email is not valid.");
                    }
                    else
                    {
                        Console.WriteLine("Your email is valid.");
                    }

                    if (!SumCalculation(out var sum))
                    {
                        Console.WriteLine(
                            "Given number are not proper. Calculation cannot be made. Please try proper numbers next time.");
                    }
                    else
                    {
                        Console.WriteLine("Sum of the given numbers is: {0}", sum.ToString("F")); // Show sum in proper representation
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured. Please try again. Details of error is showing below:");
                    Console.WriteLine(e.Message);
                }
            }

        }

        //This method show necessary info for year exercise
        public static void YearExercises()
        {
            Console.WriteLine("Current date is: " + DateTime.Now.ToShortDateString());

            // Day of year gives today's day count. Minus one means how many days are elapsed.
            Console.WriteLine("Number of days elapsed since start of the year: " + (DateTime.Now.DayOfYear - 1)); 

            var thisYear = DateTime.Now.Year;

            for (int i = thisYear; i < Int32.MaxValue; i++) // Year checking started from this year to maximum integer
            {
                if (!DateTime.IsLeapYear(i))
                {
                    continue;
                }

                var firstDay = new DateTime(i, 1, 1);
                if (!(firstDay.DayOfWeek == DayOfWeek.Tuesday))
                {
                    continue;
                }
                Console.WriteLine("Next leap year that starts with Tuesday: " + i);
                break;

            }
        }

        //This method validates given email, if email is valid returns true.
        public static bool EmailValidation(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //This method calculates sum of given numbers and out the sum and also has a return value to determine if everything is ok during calculation.
        public static bool SumCalculation(out double sum)
        {
            Console.WriteLine("Enter your number sequence with one space between each number:");
            var userInput = Console.ReadLine();
            var userInputSplitted = userInput.Split(' ');
            sum = 0L;
            foreach (var input in userInputSplitted)
            {
                if (!double.TryParse(input, out double number))
                {
                    sum = 0L;
                    return false;
                }
                sum = sum + number;
            }
            return true;
        }


    }
}
