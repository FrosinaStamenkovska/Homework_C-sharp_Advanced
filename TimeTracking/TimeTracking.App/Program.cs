using System.Diagnostics;
using TimeTracking.Models.Database;
using TimeTracking.Models;
using TimeTracking.Services;
using TimeTracking.Services.Account_Management;

namespace TimeTracking.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserDatabase userDatabase = new UserDatabase();
            User user1 = new User("Frosina", "Stamenkovska", "33", "frosinaS", "Frosina33");
            User user2 = new User("Bob", "Bobski", "25", "bobBobski", "Bob123");
            userDatabase.InsertUser(user1);
            userDatabase.InsertUser(user2);

            UserService _userService = new UserService(userDatabase);

            do
            {
                int loginAttepmpts = 3;
                User currentUser = null;
                bool exit = false;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Welcome to the Tracking App!");
                Console.ResetColor();
                Console.WriteLine("\n\t1 - Log in\n\t2 - Register\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        while(loginAttepmpts > 0)
                        {
                            currentUser = _userService.Login();
                            string password = InputHelper.Input("password");
                            if (currentUser == null || !_userService.PasswordMatch(currentUser, password))
                            {
                                loginAttepmpts--;
                                if(loginAttepmpts > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong username or password! Try again.");
                                    Console.ResetColor();
                                }
                                continue;
                            }
                            break;
                        }
                        break;
                    case "2":
                        currentUser = _userService.Register();
                        break;
                    default:
                        InputHelper.InvalidSelection();
                        continue;
                }
                
                if (loginAttepmpts == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have reached the limit of 3 wrong username or password attempts! \nGoodBye!");
                    Console.ResetColor();
                    continue;
                }

                if (!currentUser.ActiveAccount)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your account is inactive!");
                    Console.ResetColor();

                    while (true)
                    {
                        Console.WriteLine("\t1 - Activate account\n\t2 - Exit");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                currentUser.ActiveAccount = true;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Your account is active again!");
                                Console.ResetColor ();
                                break;
                            case "2":
                                exit = true;
                                break;
                            default:
                                InputHelper.InvalidSelection();
                                continue;
                        }
                        break;
                    }

                }

                if (exit)
                {
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Welcome {currentUser.FirstName} {currentUser.LastName}!\n");
                Console.ResetColor();

                while (true)
                {
                    if (!currentUser.ActiveAccount)
                    {
                        break;
                    }


                    Console.WriteLine("\nMAIN MENU: \n\t1 - Tracking \n\t2 - Statistics \n\t3 - Account Management \n\t4 - Log out");
                    User modifiedUser = null;
                    switch (Console.ReadLine())
                    {   
                        case "1":
                            modifiedUser = InputHelper.SelectActivity(currentUser);
                            if (modifiedUser != null)
                            {
                                _userService.Update(modifiedUser);
                            }
                            break;
                        case "2":
                            _userService.StatisticsSelection(currentUser);
                            break;
                        case "3":
                            modifiedUser = AccountManagement.Selection(currentUser);
                            if (modifiedUser != null)
                            {
                                _userService.Update(modifiedUser);
                            }
                            break;
                        case "4":
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
                }

            } while(true);
        }

    }
}