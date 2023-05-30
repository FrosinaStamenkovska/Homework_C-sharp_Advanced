using System.Text.RegularExpressions;
using TimeTracking.Models;

namespace TimeTracking.Services
{
    public static class RegisterValidation
    {
        public static bool ValidPassword(string password)
        {
            if (password.Trim().Length < 6 // Password should not be shorter than 6 characters excluding the empty spaces
                || new Regex("[A-Z]").Matches(password).Count < 1 //Password should contain at least one capital letter
                || new Regex("[0-9]").Matches(password).Count < 1)//Password should contain at least one number
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password should not be shorter than 6 characters, should contain at least one capital letter and at least one number!");
                Console.ResetColor();
                return false;
                
            }
            return true;
        }

        public static bool ValidUserName(string username)
        {
            if(username.Trim().Length < 5) // Username should not be shorter than 5 characters excluding the empty spaces
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username should not be shorter than 5 characters");
                Console.ResetColor();
                return false;
            }
            return true;
        }

        public static bool ValidName(string name)
        {
            if (name.Trim().Length < 2 || new Regex("[0-9]").Matches(name).Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First Name and Last Name should not be shorter than 2 characters and should not contain numbers!");
                Console.ResetColor();
                return false; //First Name and Last Name should not be shorter than 2 characters and should not contain numbers 
            }
            return true;
        }

        public static bool ValidAge(string age)
        {
            if(!int.TryParse(age, out int result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to insert a valid number!");
                Console.ResetColor();
                return false;
            }

            if (result < 18 || result > 120) //	Age should not be less than 18 years or over 120
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Age should not be less than 18 years or over 120");
                Console.ResetColor();
                return false;
            }
            return true;
        }
    }
}