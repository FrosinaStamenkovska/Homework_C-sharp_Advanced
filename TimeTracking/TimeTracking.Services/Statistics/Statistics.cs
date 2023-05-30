using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services.Statistics
{
    public static class Statistics<T> where T : Activity
    {
        public static TimeSpan TotalTime(List<T>list)
        {
            
            var totalTime = new TimeSpan(list.Sum(x => x.TotalTime.Ticks));
            
            if (Convert.ToInt32(totalTime.Hours) < 1)
            {
                Console.WriteLine($"Total time: {totalTime.Minutes} minutes.");
            }
            else
            {
                Console.WriteLine($"Total time: {Convert.ToInt32(totalTime.TotalHours)} hours.");
            }
            return totalTime;
        }

        public static TimeSpan AverageTime(List<T>list)
        {
            TimeSpan averageTime = new TimeSpan (list.Sum(x => x.TotalTime.Ticks)) / list.Count;
            Console.WriteLine($"Average time: {averageTime.Minutes} minutes.");
            return averageTime;
        }

        public static int NumberOfPages(List<Reading>list)
        {
            int pages = list.Sum(x => x.Pages);
            Console.WriteLine($"Total Number of pages: {pages}");
            return pages;
        }

        public static void FavouriteExercisingType(List<Exercising>list)
        {
            var time1 = new TimeSpan(list.Where(x => x.ExercisingType == Models.Enums.ExercisingTypeEnum.General).ToList().Sum(x => x.TotalTime.Ticks));
            var time2 = new TimeSpan(list.Where(x => x.ExercisingType == Models.Enums.ExercisingTypeEnum.Running).ToList().Sum(x => x.TotalTime.Ticks));
            var time3 = new TimeSpan(list.Where(x => x.ExercisingType == Models.Enums.ExercisingTypeEnum.Sport).ToList().Sum(x => x.TotalTime.Ticks));

            List<TimeSpan> listOfTimes = new List<TimeSpan>() { time1, time2, time3 };

            TimeSpan longestTime = listOfTimes.Max();

            if (longestTime == time1)
            {
                Console.WriteLine("Your favourite type is General exercising.");
            }
            if (longestTime == time2)
            {
                Console.WriteLine("Your favourite exercising type is Running.");
            }
            if (longestTime == time3)
            {
                Console.WriteLine("Your favourite exercising type is Sport.");
            }
        }

        public static void FavouriteWorkingType(List<Working>list)
        {
            var time1 = new TimeSpan(list.Where(x => x.WorkingType == Models.Enums.WorkingTypeEnum.FromHome).ToList().Sum(x => x.TotalTime.Ticks));
            var time2 = new TimeSpan(list.Where(x => x.WorkingType == Models.Enums.WorkingTypeEnum.AtTheOffice).ToList().Sum(x => x.TotalTime.Ticks));

            if (Convert.ToInt32(time1.TotalHours) < 1)
            {
                Console.WriteLine($"Working from home: {time1.Minutes} minutes.");
            }
            else
            {
                Console.WriteLine($"Working from home: {time1.Hours} hours.");
            }

            if (Convert.ToInt32(time2.TotalHours) < 1)
            {
                Console.WriteLine($"Working at the Office: {time2.Minutes} minutes.");
            }
            else
            {
                Console.WriteLine($"Working at the Office: {time2.Hours} hours.");
            }
        }

        public static void HobbyNames(List<Hobby> list)
        {
            Console.WriteLine("List of recorded hobbies:");
            list.DistinctBy(x => x.Name).ToList().ForEach(x => Console.WriteLine(x.Name));
        }

        public static void  FavouriteReadingType(List<Reading>list)
        {

            var time1 = new TimeSpan(list.Where(x => x.ReadingType == Models.Enums.ReadingTypeEnum.BellesLettres).ToList().Sum(x => x.TotalTime.Ticks));
            var time2 = new TimeSpan(list.Where(x => x.ReadingType == Models.Enums.ReadingTypeEnum.Fiction).ToList().Sum(x => x.TotalTime.Ticks));
            var time3 = new TimeSpan(list.Where(x => x.ReadingType == Models.Enums.ReadingTypeEnum.ProfessionalLiterature).ToList().Sum(x => x.TotalTime.Ticks));


            List<TimeSpan> listOfTimes = new List<TimeSpan>() { time1, time2, time3};

            TimeSpan longestTime = listOfTimes.Max();

            if(longestTime == time1)
            {
                Console.WriteLine("Your favourite genre is Belles Lettres.");
            }
            if (longestTime == time2)
            {
                Console.WriteLine("Your favourite genre is Fiction.");
            }
            if (longestTime == time3)
            {
                Console.WriteLine("Your favourite genre is Professional Literature.");
            }

        }

        public static TimeSpan GlobalTotalTime(User user)
        {
            var readingTime = new TimeSpan(user.ReadingList.Sum(x => x.TotalTime.Ticks));
            var exercisingTime = new TimeSpan(user.ExercisingList.Sum(x => x.TotalTime.Ticks));
            var workingTime = new TimeSpan(user.WorkingList.Sum(x => x.TotalTime.Ticks));
            var hobbiesTime = new TimeSpan(user.HobbiesList.Sum(x => x.TotalTime.Ticks));

            List<TimeSpan> listOfTimes = new List<TimeSpan>() {readingTime, exercisingTime, workingTime, hobbiesTime};
            TimeSpan totalTime = new TimeSpan(listOfTimes.Sum(x => x.Ticks));

            if(Convert.ToInt32(totalTime.TotalHours) < 1) 
            {
                Console.WriteLine($"Total time of all activities: {totalTime.Minutes} minutes");
            }
            else
            {
                Console.WriteLine($"Total time of all activities: {totalTime.Hours} hours");
            }
        
            if(totalTime > TimeSpan.Zero)
            {
                TimeSpan longestTime = listOfTimes.Max();

                if (longestTime == readingTime)
                {
                    Console.WriteLine("Your favorite activity is Reading! You nerd! :)");
                }

                if (longestTime == exercisingTime)
                {
                    Console.WriteLine("Your favorite activity is Exercising! No pain - no gain! :)");
                }

                if (longestTime == workingTime)
                {
                    Console.WriteLine("Your favorite activity is Working! Get some rest! :)");
                }

                if (longestTime == hobbiesTime)
                {
                    Console.WriteLine("Your favorite activity is your Hobby!");
                }
            }
            return totalTime;
        }
    }
}
