using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dog : Animal, IDog
    {
        public Dog(string name, int age, string color) : base(name, age, color) { }

        public override void PrintAnimal()
        {
            Console.WriteLine($"{Name} is a {Age} years old dog.");
        }

        public void Bark()
        {
            Console.WriteLine($"{Name} says: \"Bark Bark...\" ");
        }
    }
}
