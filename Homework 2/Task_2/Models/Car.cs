using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Car : Vehicle
    {
        public Car(string model, int year, bool isClean, bool isGasFull, bool isBroken)
            :base(model, year, isClean, isGasFull, isBroken)
        {

        }

        public override void Drive()
        {
            if (IsBroken)
            {
                Console.WriteLine($"You cannot drive the car {Model}, because it's broken!");
            }
            else if (!IsGasFull)
            {
                Console.WriteLine($"You cannot drive the car {Model}, because there is no gas in it!");
            }
            else
            {
                Console.WriteLine($"The car {Model} is driving.");
            }
        }
    }
}
