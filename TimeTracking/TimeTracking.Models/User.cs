using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace TimeTracking.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool ActiveAccount { get; set; }

        public List<Reading> ReadingList { get; set; }
        public List<Working> WorkingList { get; set; }
        public List<Exercising> ExercisingList { get; set;}
        public List<Hobby> HobbiesList { get; set; }

        public User (string firstName, string lastName, string age, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Password = password;
            ActiveAccount = true;
            ReadingList = new List<Reading>();
            WorkingList = new List<Working> ();
            ExercisingList = new List<Exercising> ();
            HobbiesList = new List<Hobby> ();
        }

        public User()
        {

        }

        public bool CorrectPassword(string password)
        {
            if(Password == password)
            {
                return true;
            }
            return false;
        }

    }
}