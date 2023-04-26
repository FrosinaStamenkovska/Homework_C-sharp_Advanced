using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RepairService:IRepairService
    {
        public void CheckVehicle(Vehicle vehicle)
        {
            if (vehicle.IsBroken)
            {
                Console.WriteLine($"The vehicle {vehicle.Model} is broken and needs to be fixed.");
            }
            else
            {
                Console.WriteLine($"The vehicle {vehicle.Model} is in a good condition.");
            }
        }

        public void FixVehicle(Vehicle vehicle)
        { 
            vehicle.IsBroken = false;
        }
    }
}
