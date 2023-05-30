using TimeTracking.Models;
using TimeTracking.Models.Database;
using TimeTracking.Services.Statistics;

namespace TimeTracking.Services
{
    public class UserService
    {
        private UserDatabase _database;
        public UserService(UserDatabase database)
        {
            _database = database;
        }

        public bool UsernameExists(string username)
        {
            User user = _database.FindUser(username);
            if(user == null)
            {
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The username already exists, please try with different one!");
            Console.ResetColor();
            return true;
        }

        public bool PasswordMatch (User user, string password)
        {
            if(_database.CorrectPassword(user, password))
            {
                return true;
            }
            return false;
        }

        public User Register()
        {
            string firstName;
            string lastName;
            string age;
            string username;
            string password;

            while (true)
            {
                firstName = InputHelper.Input("FirstName");
                if (!RegisterValidation.ValidName(firstName))
                {
                    continue;
                }
                break;
            }

            while (true)
            {
                lastName = InputHelper.Input("LastName");
                if (!RegisterValidation.ValidName(lastName))
                {
                    continue;
                }
                break;
            }

            while (true)
            {
                age = InputHelper.Input("Age");
                if (!RegisterValidation.ValidAge(age))
                {
                    continue;
                }
                break;
            }

            while (true)
            {
                username = InputHelper.Input("Username");
                if (!RegisterValidation.ValidUserName(username) || UsernameExists(username))
                {
                    continue;
                }
                break;
            }

            while (true)
            {
                password = InputHelper.Input("Password");
                if (!RegisterValidation.ValidPassword(password))
                {
                    continue;
                }
                break;
            }

            User user = new User(firstName, lastName, age, username, password);

            _database.InsertUser(user);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You have successfully completed your registration!");
            Console.ResetColor();

            return user;
        }

        public User Login()
        {
            string username = InputHelper.Input("Username");
            User user = _database.FindUser(username);
            return user;
        }

        public void Update (User user)
        {
            _database.UpdateUser(user);
        }

        public void GetReadingStatistics (User user)
        {
            User foundUser = _database.FindUser(user.Username);
            if(foundUser.ReadingList.Count > 0)
            {
                Console.WriteLine("\nReading Statistics:");
                Statistics<Reading>.TotalTime(user.ReadingList);
                Statistics<Reading>.AverageTime(user.ReadingList);
                Statistics<Reading>.NumberOfPages(user.ReadingList);
                Statistics<Reading>.FavouriteReadingType(user.ReadingList);
                return;
            }
            Console.WriteLine("You haven't used the reading activity yet, therefore there is no statistic data for this activity.");
        }

        public void GetExercisingStatistics(User user)
        {
            User foundUser = _database.FindUser(user.Username);
            if (foundUser.ExercisingList.Count > 0)
            {
                Console.WriteLine("\nExercising Statistics:");
                Statistics<Exercising>.TotalTime(user.ExercisingList);
                Statistics<Exercising>.AverageTime(user.ExercisingList);
                Statistics<Exercising>.FavouriteExercisingType(user.ExercisingList);
                return;
            }
            Console.WriteLine("You haven't used the exercising activity yet, therefore there is no statistic data for this activity.");
        }

        public void GetWorkingStatistics(User user)
        {
            User foundUser = _database.FindUser(user.Username);
            if (foundUser.WorkingList.Count > 0)
            {
                Console.WriteLine("\nWorking Statistics:");
                Statistics<Working>.TotalTime(user.WorkingList);
                Statistics<Working>.AverageTime(user.WorkingList);
                Statistics<Working>.FavouriteWorkingType(user.WorkingList);
                return;
            }
            Console.WriteLine("You haven't used the working activity yet, therefore there is no statistic data for this activity.");
        }

        public void GetHobbiesStatistics(User user)
        {
            User foundUser = _database.FindUser(user.Username);
            if (foundUser.HobbiesList.Count > 0)
            {
                Console.WriteLine("\nHobbies Statistics:");
                Statistics<Hobby>.TotalTime(user.HobbiesList);
                Statistics<Hobby>.HobbyNames(user.HobbiesList);
                return;
            }
            Console.WriteLine("You haven't used the hobby - activity yet, therefore there is no statistic data for this activity.");
        }

        public void GetGlobalStatistics(User user)
        {
            User foundUser = _database.FindUser(user.Username);
            Statistics<Activity>.GlobalTotalTime(foundUser);
        }

        public void StatisticsSelection (User user)
        {
            bool exit = false;
            
            while (true)
            {
                Console.WriteLine("\nSTATISTICS\n \n\t1 - Reading \n\t2 - Exercising \n\t3 - Working \n\t4 - Hobbies \n\t5 - Global \n\t6 - Back\n");
                switch(Console.ReadLine())
                {
                    case "1":
                        GetReadingStatistics(user);
                        break;
                    case "2":
                        GetExercisingStatistics(user);
                        break;
                    case "3":
                        GetWorkingStatistics(user);
                        break;
                    case "4":
                        GetHobbiesStatistics(user);
                        break;
                    case "5":
                        GetGlobalStatistics(user);
                        break;
                    case "6":
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
            
        }
    }
}
