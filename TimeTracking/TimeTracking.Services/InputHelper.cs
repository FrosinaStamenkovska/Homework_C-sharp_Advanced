using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models.Database;
using TimeTracking.Models;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace TimeTracking.Services
{
    public static class InputHelper
    {
        public static string Input(string typeOfInput)
        {
            Console.WriteLine($"Please insert your {typeOfInput}:");
            string input;
            while (true)  
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You need to insert your {typeOfInput}");
                    Console.ResetColor();
                    continue;
                }
                return input;
            }
        }

        public static TimeSpan TrimTime(TimeSpan time)
        {
            TimeSpan trimmedTime = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
            return trimmedTime;
        }

        public static void InvalidSelection()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Selection!");
            Console.ResetColor();
        }

        public static User SelectActivity(User user)
        {
            
            TimeSpan trackedTime;
            User modifiedUser = null;
            bool exit = false;
            while (true)
            {
                Console.WriteLine("\nTRACKING\n \n\t1 - Reading \n\t2 - Exercising \n\t3 - Working \n\t4 - Other Hobbies \n\t5 - Back");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("You have chosen the reading activity!");
                        trackedTime = TimeTracker();
                        Reading reading = ReadingInfo(trackedTime);
                        user.ReadingList.Add(reading);
                        Console.WriteLine($"You have spent {TrimTime(trackedTime)} for reading.");
                        modifiedUser = user;
                        break;
                    case "2":
                        Console.WriteLine("You have chosen the exercising activity!");
                        trackedTime = TimeTracker();
                        Exercising exercising = ExercisingInfo(trackedTime);
                        user.ExercisingList.Add(exercising);
                        Console.WriteLine($"You have spent {TrimTime(trackedTime)} for exercising.");
                        modifiedUser = user;
                        break;
                    case "3":
                        Console.WriteLine("You have chosen the working activity!");
                        trackedTime = TimeTracker();
                        Working working = WorkingInfo(trackedTime);
                        user.WorkingList.Add(working);
                        Console.WriteLine($"You have spent {TrimTime(trackedTime)} for working.");
                        modifiedUser = user;
                        break;
                    case "4":
                        Console.WriteLine("You have chosen Other Hobbies!");
                        trackedTime = TimeTracker();
                        Hobby hobby = HobbyInfo(trackedTime);
                        user.HobbiesList.Add(hobby);
                        Console.WriteLine($"You have spent {TrimTime(trackedTime)} for {hobby.Name}.");
                        modifiedUser = user;
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        InvalidSelection();
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
            return modifiedUser;
        }

        public static Reading ReadingInfo(TimeSpan readingTime)
        {
            Reading reading = new Reading();
            reading.TotalTime = readingTime;

            while (true)
            {
                Console.WriteLine("How many pages have you read?");
                if (!int.TryParse(Console.ReadLine(), out int result) || result < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number of pages needs to be larger than 0!");
                    Console.ResetColor ();
                    continue;
                };
                reading.Pages = result;
                break;
            }

            while (true)
            {
                Console.WriteLine("Select a genre: \n\t1 - Belles Lettres \n\t2 - Fiction \n\t3 - Professional Literature");
                switch (Console.ReadLine())
                {
                    case "1":
                        reading.ReadingType = Models.Enums.ReadingTypeEnum.BellesLettres;
                        break;
                    case "2":
                        reading.ReadingType = Models.Enums.ReadingTypeEnum.Fiction;
                        break;
                    case "3":
                        reading.ReadingType = Models.Enums.ReadingTypeEnum.ProfessionalLiterature;
                        break;
                    default:
                        InvalidSelection();
                        continue;
                }
                break;
            }
            return reading;

        }

        public static Exercising ExercisingInfo(TimeSpan exercisingTime)
        {
            Exercising exercising = new Exercising();
            exercising.TotalTime = exercisingTime;

            while (true)
            {
                Console.WriteLine("Select a type of exercising: \n\t1 - General \n\t2 - Running \n\t3 - Sport");
                switch (Console.ReadLine())
                {
                    case "1":
                        exercising.ExercisingType = Models.Enums.ExercisingTypeEnum.General;
                        break;
                    case "2":
                        exercising.ExercisingType = Models.Enums.ExercisingTypeEnum.Running;
                        break;
                    case "3":
                        exercising.ExercisingType = Models.Enums.ExercisingTypeEnum.Sport;
                        break;
                    default:
                        InvalidSelection();
                        continue;
                }
                break;
            }
            return exercising;
        }

        public static Working WorkingInfo(TimeSpan workingTime)
        {
            Working working = new Working();
            working.TotalTime = workingTime;

            while (true)
            {
                Console.WriteLine("Select a type of working: \n\t1 - At the office \n\t2 - From home");
                switch (Console.ReadLine())
                {
                    case "1":
                        working.WorkingType = Models.Enums.WorkingTypeEnum.AtTheOffice;
                        break;
                    case "2":
                        working.WorkingType = Models.Enums.WorkingTypeEnum.FromHome;
                        break;
                    default:
                        InvalidSelection();
                        continue;
                }
                break;
            }
            return working;
        }

        public static Hobby HobbyInfo(TimeSpan hobbyTime)
        {
            Hobby hobby = new Hobby();
            hobby.TotalTime = hobbyTime;
            while (true)
            {
                Console.WriteLine("Insert the name of your hobby.");
                string nameOfHobby = Console.ReadLine();
                if(int.TryParse(nameOfHobby, out int result) || string.IsNullOrEmpty(nameOfHobby))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You need to insert a valid hobby!");
                    Console.ResetColor();
                    continue;
                }
                hobby.Name = nameOfHobby;
                return hobby;
            }
        }

        public static TimeSpan TimeTracker()
        {
            Console.WriteLine("Press ENTER to start the activity.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            TimeSpan start = DateTime.Now.TimeOfDay;
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine("\nThe countdown for the activity has started! (Press ENTER to stop the timer.)");
            Console.ResetColor();
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            TimeSpan end = DateTime.Now.TimeOfDay;

            TimeSpan timeDiff = end - start;

            return timeDiff;
        }

       
    }
}
