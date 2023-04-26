using Models;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog("Lucy", 5, "WhiteAndBrown");
            Dog dog2 = new Dog("Lexie", 1, "Grey");

            Cat cat1 = new Cat("Garfield", 2, "Orange");


            dog1.PrintAnimal();
            dog1.Bark();
            dog2.PrintAnimal();
            dog2.Bark();
            cat1.PrintAnimal();
            cat1.Eat("fish");
        }
    }
}