namespace Models
{
    public class User
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public UserEnum UserType { get; set; }

        public User(string firstName, string lastName, string username, string password)
        {   
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }

        public User() { }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public bool CorrectPassword(string password)
        {
            if (Password != password)
            {
                return false;
            }
            return true;
        }


    }
}
