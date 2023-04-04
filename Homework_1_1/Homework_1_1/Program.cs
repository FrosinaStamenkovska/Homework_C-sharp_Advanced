using System.Text.RegularExpressions;

namespace Homework_1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            List <string> listOfNames = new List <string> ();
            while(true)
            {
                Console.WriteLine("Please enter a name or press x to exit!");
                string input = Console.ReadLine();
                if(input.ToLower() == "x")
                {
                    break;
                }

                if(!Regex.IsMatch(input, @"^[a-zA-Z]+$") || input.Length < 2)
                {
                    Console.WriteLine("Invalid name!");
                    continue;
                }

                listOfNames.Add(input);
            }

            Console.WriteLine("Please enter a text");
            string someText = Console.ReadLine();

            foreach(string name in listOfNames)
            {
                Console.WriteLine($"The name {name} was included in the text {Regex.Matches(someText.ToLower(),name.ToLower()).Count()} times");
            }

        }

        

        
    }
}