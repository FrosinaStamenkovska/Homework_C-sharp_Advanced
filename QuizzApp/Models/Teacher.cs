namespace Models
{
    public class Teacher : User
    {
        public List<Student> Students { get; set; }

        public Teacher(string firstName, string lastName, string username, string password, List <Student> listOfStudents ) : base(firstName, lastName, username, password)
        {
            UserType = UserEnum.Teacher;
            Students = listOfStudents;

        }

        public Teacher() { }

        public void StudentsWhoDidQuizz()
        {
            List<Student> didQuizz = Students.Where(x => x.Grade > 0).ToList(); // creating a list to store all the students who did the quizz
            if (didQuizz.Any()) // if the list has at least 1 student it will be printed
            {
                Console.WriteLine("\nStudents who have done the Quizz:");
                foreach (Student student in didQuizz)
                {
                    Console.WriteLine($"{student.FullName()} - Grade: {student.Grade} [{student.QuizzScore} correct answers]");
                }
            }
        }

        public void StudentsWithoutQuizz()
        {   
            List<Student> noQuizz = Students.Where(x => x.Grade == 0).ToList(); // a list to store all the students who have't done the quizz yet

            if (noQuizz.Any()) // if the list has at least 1 student it will be printed
            {
                Console.WriteLine("\nStudents that haven't done the Quizz yet:");
                foreach (Student student in noQuizz)
                {
                    Console.WriteLine($"{student.FullName()}");
                }
            }
            
        }
    }
}
