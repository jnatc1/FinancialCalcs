using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FitnessCalculators
{
    public static class Calcs  //Utility class used for calculations
    {
        public static void MakeChoice()  //Method used to take make choice of calculation
        {
            Utility.DisplayOptions();  //Displays formula options to user
            Console.Write("Please enter the number choice to select a calculation: ");
            string choice = Console.ReadLine();
            switch(choice)  //Switch statement to call method by choice
            {
                case "1":
                    CashFlow();
                    break;
                case "2":
                    RealReturn();
                    break;
                case "3":
                    RuleOf72();
                    break;
                default:
                    Console.WriteLine("You didn't enter a correct number");  
                    break;
            }
            
        }
        public static void CashFlow()  //method that calculates cash flow
        {
            string cashflows = File.ReadAllText("cashflow.txt");  //reads text from file located in bin
            Console.WriteLine($"{cashflows}");
            Console.Write("Enter income: ");
            double income = ReturnDouble();  //Uses a method to accept user input
            Console.Write("Enter expenses: ");
            double expenses = ReturnDouble();
            Console.WriteLine($"Your Cash Flow is: {income - expenses: 0.00}");
            Utility.ClearConsole();
        }
        public static void RealReturn()  //defines method that calculates Real Return
        {
            string returnInfo = File.ReadAllText("realreturn.txt"); //Reads text from a file
            Console.WriteLine($"{returnInfo}");
            Console.Write("Enter investment return: ");
            double invReturn = ReturnDouble();
            Console.Write("Enter inflation rate: ");
            double inflation = ReturnDouble();
            double realReturn = ((1 + invReturn) / (1 + inflation) - 1) * 100;  //Calculates real return
            Console.WriteLine($"Your estimated real return is: {realReturn: 0.00}");
            Utility.ClearConsole();
        }
        public static void RuleOf72()  //Method that calculates Rule of 72
        {
            string returnInfo = File.ReadAllText("ruleof72.txt");
            Console.WriteLine($"{returnInfo}");
            Console.Write("Enter rate of return as a whole number: ");
            double r = ReturnDouble();
            double rOf72 = 72 / r;  //Calculates Rule of 72
            Console.WriteLine($"Your rule of 72 is: {rOf72: 0.00} years");
            Utility.ClearConsole();
        }
        public static double ReturnDouble()  //Method that is used to accept user input for calculations
        {
            bool checker = Double.TryParse(Console.ReadLine(), out double number);  //bool to check user input
            while(true)
            {
                if(checker)  //Tests if bool is true, breaks the loop if true
                {
                    break;
                }
                else //Prompts the user to enter the number again if bool is false
                {
                    Console.Write("Please enter that number again: ");
                    checker = Double.TryParse(Console.ReadLine(), out number);
                }
            }
            return number;
            
        }
        
    }
}
