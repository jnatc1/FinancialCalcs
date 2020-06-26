using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FitnessCalculators
{
    static class Utility //This class is a utility class that houses methods not tied to the object class
    {
        public static string GetFirstName()  //Get's first name
        {
            Console.Write("Enter first name: ");
            return Console.ReadLine();
        }
        public static string GetLastName() //Get's the last name
        {
            Console.Write("Enter last name: ");
            return Console.ReadLine();
        }
        public static DateTime GetBirthDate()  //Gets date of birth
        {

            DateTime birthDay;  //Initializes date time variable
            Console.Write("Please enter date of birth ('MM/dd/yyyy'): ");
            bool checker = DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy",  //bool to parse the date from user
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out birthDay);
            while (true)  //while loop to make sure that the user entered correct date
            {
                if (checker)  //
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter date of birth ('MM/dd/yyyy'): "); 
                    checker = DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", //Boolean to ensure birthdate is correctly entered
                                              CultureInfo.InvariantCulture,
                                              DateTimeStyles.None, out birthDay);
                }
            }
            return birthDay;
        }
        public static string GetEmail()  //Gets email and checks to ensure correct format
        {
            Regex rx = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$",
                  RegexOptions.IgnoreCase);
            string email;
            while (true)
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                if (rx.IsMatch(email))
                {
                    return email;
                }
                else
                {
                    Console.WriteLine("Check email format."); 
                }

            }

        }
        public static void DisplayOptions()  //Displays the options
        {
            Console.WriteLine("The following are your choices: ");

            List<string> options = new List<string>() 
            {"1: Cash Flow",
             "2: Real Return",
             "3: Rule of 72"
            };

            foreach (var item in options)
            {
                Console.WriteLine(item);
            }
        }
        public static void DisplayDisclaimer() //Displays disclaimer that this app doesn't give advice
        {
            string disclaimer = File.ReadAllText("pagedisclamer.txt");
            Console.WriteLine(disclaimer);
            Console.ReadKey();
            Console.Clear();
        }
        public static void ClearConsole() //Clears the console so that it's not so cluttered
        {
            Console.WriteLine("Press Enter to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
