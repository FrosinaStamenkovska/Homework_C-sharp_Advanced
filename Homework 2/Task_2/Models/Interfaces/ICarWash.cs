using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ICarWash
    {
        public void WashCar(Car car);
        public void WashTruck(Truck truck);
    }
}
