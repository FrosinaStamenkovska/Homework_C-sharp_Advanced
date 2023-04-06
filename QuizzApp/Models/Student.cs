namespace Models
{
    public class Student : User
    {
        public int QuizzScore { get; set; }
        public int Grade
        {
            get
            {   
                if(QuizzScore < 0) // if the student haven't taken the quizz yet, the grade will be 0
                {
                    return 0;
                }

                if(QuizzScore == 0) // if the student has no correct answers on the quizz the grade will be 1
                {
                    return 1;
                }

                return QuizzScore; // the grade will be set acording to the quizz score
            }
        }

        public Student(string firstName, string lastName, string username, string password) : base(firstName, lastName, username, password)
        {
            QuizzScore = -1; // The default value of -1 means that the student haven't taken the quizz yet
            UserType = UserEnum.Student;
        }

        public Student() { }
    }
}
