using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCalculators
{
    public enum AgeBrackett
    {
        Child,
        Adolescent,
        Adult
    }
    class NewMember //declares class called NewMember
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private DateTime BirthDate { get; set; }
        private string Email{ get; set; }
        public AgeBrackett AgeBrackett { get; set; }
        

        public NewMember(string firstname, string lastname, 
            DateTime birthdate, string email) //Class NewMember constructor
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Email = email;
        }

        public int CalcAge()  //Calculates new member age
        {
            var today = DateTime.Today;  
            var age = today.Year - BirthDate.Year; //Uses DateTime objects to determine age
            return age;
        }

        public void DisplayAgeBrackett()  //Displays enum age brackett
        {
            if (CalcAge() < 12)
            {
                AgeBrackett = AgeBrackett.Child;
            }
            else if (CalcAge() > 12 && CalcAge() < 18)
            {
                AgeBrackett = AgeBrackett.Adolescent;
            }
            else
            {
                AgeBrackett = AgeBrackett.Adult;
            }
            Console.WriteLine($"Age Brackett is: {AgeBrackett}");
        }
        public void DisplayUserInfo()  //Method that displays user info
        {
            
            Console.WriteLine($"Thank you for registering: {FirstName} {LastName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Age: {CalcAge()}");
            DisplayAgeBrackett();
            Console.Write("Press enter to continue.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
