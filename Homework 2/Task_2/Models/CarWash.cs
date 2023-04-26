using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarWash : ICarWash
    {
        public void WashCar(Car car)
        {
            car.IsClean = true;
        }

        public void WashTruck(Truck truck)
        {
            truck.IsClean = true;
        }
    }
}
