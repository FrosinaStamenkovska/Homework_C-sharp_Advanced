using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services.Account_Management
{
    public static class AccountManagement
    {
        public static User ChangePassword (User user)
        {
            
            while (true)
            {
                Console.WriteLine("Enter your new password");
                string password = Console.ReadLine();
                if (user.CorrectPassword(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your new password cannot be the same as your previous one. Try again");
                    Console.ResetColor();
                    continue;
                }

                if (!RegisterValidation.ValidPassword(password))
                {
                    continue;
                }
                user.Password = password;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You have successfully changed your password!");
                Console.ResetColor();
                return user;
            }
        }

        public static User ChangeFirstName(User user)
        {
            
            while (true)
            {
                Console.WriteLine("Enter your new First name");
                string firstName = Console.ReadLine();
                if (!RegisterValidation.ValidName(firstName))
                {
                    continue;
                }
                user.FirstName = firstName;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You have successfully changed your First Name!");
                Console.ResetColor();
                return user;
            }
        }

        public static User ChangeLastName(User user)
        {
            
            while (true)
            {
                Console.WriteLine("Enter your new Last name");
                string lastName = Console.ReadLine();
                if (!RegisterValidation.ValidName(lastName))
                {
                    continue;
                }
                user.LastName = lastName;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You have successfully changed your Last Name!");
                Console.ResetColor();
                return user;
            }
        }

        public static User DeactivateAccount(User user)
        {
            user.ActiveAccount = false;
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine("You have successfully deactivated your account!");
            Console.ResetColor();
            return user;
        }

        public static User Selection(User user)
        {
            User changedUser = null;
            bool exit = false;

            while (true)
            {
                Console.WriteLine("\nACCOUNT MANAGEMENT\n \n\t1 - Change password \n\t2 - Change First Name \n\t3 - Change Last Name \n\t4 - Deactivate account \n\t5 - Back");
                switch (Console.ReadLine())
                {
                    case "1":
                        changedUser = ChangePassword(user);
                        break;
                    case "2":
                        changedUser = ChangeFirstName(user);
                        break;
                    case "3":
                        changedUser = ChangeLastName(user);
                        break;
                    case "4":
                        changedUser = DeactivateAccount(user);
                        exit = true;
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        InputHelper.InvalidSelection();
                        continue;
                }

                if (exit)
                {
                    break;
                }

                Console.WriteLine("\nPress ENTER to go BACK.");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                }
            }
            return changedUser;
        }
    }
}
