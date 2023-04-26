using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarCenter : ICarWash, IGasPump, IRepairService
    {
        public List<Vehicle> Vehicles = new List<Vehicle>();
        public int NumberOfServices = 0;

        public void PrintVehicles()
        {
            if(Vehicles.Any())
            {
                Console.WriteLine("The vehicles that have used the services of the CarCenter:");
                foreach (Vehicle vehicle in Vehicles)
                {
                    Console.WriteLine(vehicle.Model);
                }
            }
            else
            {
                Console.WriteLine("There is no vehicle that has visited the car center yet!");
            }
            
        }
        public void WashCar(Car car)
        {
            car.IsClean = true;
            if (!Vehicles.Contains((Vehicle)car))
            {
                Vehicles.Add((Vehicle)car);
            }
            NumberOfServices++;
            Console.WriteLine($"The car {car.Model} is clean now!");
        }

        public void WashTruck(Truck truck)
        {
            truck.IsClean = true;
            if (!Vehicles.Contains((Vehicle)truck))
            {
                Vehicles.Add((Vehicle)truck);
            }
            
            NumberOfServices++;
            Console.WriteLine($"The truck {truck.Model} is clean now!");
        }

        public void PumpGas(Vehicle vehicle)
        {
            vehicle.IsGasFull = true;
            if (!Vehicles.Contains(vehicle))
            {
                Vehicles.Add(vehicle);
            }
            NumberOfServices++;
            Console.WriteLine($"The vehicle {vehicle.Model} is fully tanked!");
        }

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

            if (!Vehicles.Contains(vehicle))
            {
                Vehicles.Add(vehicle);
            }
            NumberOfServices++;
        }

        public void FixVehicle(Vehicle vehicle)
        {
            if(!vehicle.IsBroken)
            {
                Console.WriteLine($"There is no need of fixing the vehicle {vehicle.Model}, because it is in a good condition.");
            }
            else
            {
                vehicle.IsBroken = false;
                if (!Vehicles.Contains(vehicle))
                {
                    Vehicles.Add(vehicle);
                }
                NumberOfServices++;
                Console.WriteLine($"The vehicle {vehicle.Model} is repaired!");
            }
            
        }

       
    }
}
