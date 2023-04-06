using Models;
using System.Linq;

namespace QuizzApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Frosina", "Stamenkovska", "Frosina", "123456");
            Student student2 = new Student("Bob", "Bobski", "Bob", "789789");
            Student student3 = new Student("John", "Doe", "John", "321654");
            Student student4 = new Student("Jane", "Smith", "Jane", "111111");

            List<Student> students = new List<Student>() { student1, student2, student3, student4};

            Teacher teacher = new Teacher("Risto", "Panchevski", "Risto", "555555", students);

            List<User> users = new List<User>() { teacher, student1, student2, student3, student4 }; // A list to store all the users - process of boxing

            do
            {
                User currentUser = null; // creating a helper object to store the data for the current user
                int usernameAttempts = 3;
                int passwordAttempts = 3;
                Console.ResetColor();

                while (usernameAttempts > 0)
                {
                    Console.WriteLine("\nPlease enter your username to log in!");
                    string username = Console.ReadLine();

                    bool userExists = false;

                    foreach(User user in users)
                    {
                        if (user.Username == username)
                        {
                            currentUser = user; // assigning the founded user to the object currentUser
                            userExists = true;
                        }  
                    }

                    if (!userExists) // if the user doesn't exist, decreasing the attempts
                    {
                        usernameAttempts--;
                        Console.WriteLine($"The username does not exist, you have {usernameAttempts} attempts left!");
                        continue;
                    }
                    break;
                }

                if (usernameAttempts == 0) // if there are no more attempts, throwing an exception and closing the app
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("\nYou have reached the limit of 3 incorrect username attempts!\nYour account has been blocked!");
                }

                while (passwordAttempts > 0)
                {
                    Console.WriteLine("Please enter your password");
                    string password = Console.ReadLine();
                    if (!currentUser.CorrectPassword(password)) // if the password doesn't match, decreasing the attempts
                    {
                        passwordAttempts--;
                        Console.WriteLine($"Incorrect password, you have {passwordAttempts} attempts left!");
                        continue;
                    }
                    break;
                }

                if (passwordAttempts == 0) // if there are no more attempts, throwing an exception and closing the app
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("\nYou have reached the limit of 3 incorrect password attempts!\nYour account has been blocked!");
                }

                Console.WriteLine($"\nWelcome {currentUser.FullName()}.");
                ConsoleKeyInfo keyInfo; // variable for key info, that will be used to continue with the process after the user presses some particular key

                if ((int) currentUser.UserType == 2) // if the user type of the current user is enum 2 (Teacher) 
                {
                    Teacher currentTeacher = (Teacher) currentUser; //converting the User object to Teacher object - Unboxing
                    Console.ForegroundColor = ConsoleColor.Green;
                    currentTeacher.StudentsWhoDidQuizz();

                    Console.ForegroundColor = ConsoleColor.Red;
                    currentTeacher.StudentsWithoutQuizz();

                    do {
                        keyInfo = Console.ReadKey(true);
                    } while (keyInfo.Key != ConsoleKey.Enter); // the teacher will be logged out after pressing enter
                }
                else
                {
                    Student currentStudent = (Student)currentUser; //converting the User object to Student object - Unboxing

                    if (currentStudent.QuizzScore != -1) // if the student have taken the quizz before, the quizz score should be different from -1 and will log them out
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have already done the test!");
                        continue;
                    }

                    currentStudent.QuizzScore = 0; // setting the quizz score to 0 before starting the quizz and increasing the score for every correct answer
                    Console.WriteLine("The Quizz has 5 multiple-choice questions ( 4 choices ).\nAll the choices must be numbers from 1 to 4.\nGood Luck!");

                    Console.WriteLine("Press Enter to Start the Quizz.");
                    
                    do
                    {
                        keyInfo = Console.ReadKey(true);
                    } while (keyInfo.Key != ConsoleKey.Enter); // the student can start the Quizz after pressing enter

                    Console.WriteLine("\n1. Q: What is the capital of Tasmania?\n\ta: Dodoma\n\tb: Hobart \n\tc: Launceston\n\td: Wellington");
                    while (true)
                    {
                        switch (Console.ReadLine())
                        {
                            case "1":
                                break;
                            case "2":
                                currentStudent.QuizzScore++;
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Wrong input, All the choices must be numbers from 1-4. Please try again!");
                                continue;
                        }
                        break;
                    }

                    Console.WriteLine("\n2. Q: What is the tallest building in the Republic of the Congo?\n\ta: Kinshasa Democratic Republic of the Congo Temple\n\tb: Palais de la Nation\n\tc: Kongo Trade Centre\n\td: Nabemba Tower");
                    while (true)
                    {
                        switch (Console.ReadLine())
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "4":
                                currentStudent.QuizzScore++;
                                break;
                            default:
                                Console.WriteLine("Wrong input, All the choices must be numbers from 1-4. Please try again");
                                continue;
                        }
                        break;
                    }

                    Console.WriteLine("\n3. Q: Which of these is not one of Pluto's moons?\n\ta: Styx\n\tb: Hydra\n\tc: Nix \n\td: Lugia");
                    while (true)
                    {
                        switch (Console.ReadLine())
                        {
                            case "1":
                                break;
                            case "2":
                                break;
                            case "3":
                                currentStudent.QuizzScore++;
                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Wrong input, All the choices must be numbers from 1-4. Please try again");
                                continue;
                        }
                        break;
                    }

                    Console.WriteLine("\n4. Q: What is the smallest lake in the world?\n\ta: Onega Lake\n\tb: Benxi Lake \n\tc: Kivu Lake\n\td: Wakatipu Lake");
                    while (true)
                    {
                        switch (Console.ReadLine())
                        {
                            case "1":
                                break;
                            case "2":
                                currentStudent.QuizzScore++;
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Wrong input, All the choices must be numbers from 1-4. Please try again");
                                continue;
                        }
                        break;
                    }

                    Console.WriteLine("\n5 Q: What country has the largest population of alpacas?\n\ta: Chad\n\tb: Peru \n\tc: Australia\n\td: Niger");
                    while (true)
                    {
                        switch (Console.ReadLine())
                        {
                            case "1":
                                break;
                            case "2":
                                currentStudent.QuizzScore++;
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            default:
                                Console.WriteLine("Wrong input, All the choices must be numbers from 1-4. Please try again");
                                continue;
                        }
                        break;
                    }

                    Console.WriteLine($"\nYou completed the quizz with {currentStudent.QuizzScore} correct answers!");
                    Console.WriteLine($"Your grade is: {currentStudent.Grade}");
                    switch (currentStudent.Grade)
                    {
                        case 1:
                            Console.WriteLine("You need to study more!");
                            break;
                        case 2:
                            Console.WriteLine("Not Bad!");
                            break;
                        case 3:
                            Console.WriteLine("Good Job!");
                            break;
                        case 4:
                            Console.WriteLine("Well Done!");
                            break;
                        case 5:
                            Console.WriteLine("Excellent!");
                            break;
                    }

                    Console.WriteLine("\nPress Enter to Log out.");
                    do
                    {
                        keyInfo = Console.ReadKey(true);
                    } while (keyInfo.Key != ConsoleKey.Enter); // the student can log out after pressing enter
                }

            } while (true);
        }
    }
}