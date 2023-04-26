using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cat: Animal, ICat
    {
        public Cat(string name, int age, string color) : base(name, age, color) { }

        public override void PrintAnimal()
        {
            Console.WriteLine($"{Name} is a {Age} years old cat.");
        }

        public void Eat(string food)
        {
            Console.WriteLine($"{Name} is eating {food}.");
        }
    }
}
