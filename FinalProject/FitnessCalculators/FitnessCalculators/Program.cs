using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCalculators
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Utility.DisplayDisclaimer(); //Displays disclaimer that application isn't for advice
            NewMembers();  //Calls method used to instantiate a new member
            Calculate(); //Calls static method that invokes the Calcs methods
            Console.ReadLine();
        }
        static void NewMembers()
        {
            NewMember member = new NewMember(Utility.GetFirstName(), Utility.GetLastName(),
                                    Utility.GetBirthDate(), Utility.GetEmail());
            member.DisplayUserInfo();
        }
        static void Calculate()
        {
            while (true)
            {
                Calcs.MakeChoice();
                Console.Write("Enter q to quit, or enter to continue: ");
                string end = Console.ReadLine();
                if (end.Equals("q"))
                {
                    Console.WriteLine("This ends this task, goodbye.");
                    break;
                }
            }
        }
    }
}
