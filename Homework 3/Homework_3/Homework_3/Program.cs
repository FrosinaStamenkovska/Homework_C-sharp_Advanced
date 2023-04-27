using Models;
using Models.Services;

namespace Homework_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> listOfAllVehicles = new List<Vehicle>
            {
                new Vehicle("truck", 2010, "123456"),
                new Vehicle("bus", 2015, "789456"),
                new Vehicle("van", 2010, "654987"),
                new Vehicle() // Not all properties are asigned on purpose :)
                {
                    YearOfProduction = 2015
                },
                new Car("Hatchback", 2018, "658PO23", 50, "Germany and Austria"),
                new Car("Sedan", 2020, "753YTO23", 55, "France"),
                new Car("Coupe", 2018, "PT369852", 40, "Italy, Serbia, Macedonia"),
                new Car()
                {
                    Type = "Minivan"
                },
                new Bike("Road Bike", 2022, "VI24568", "Green"),
                new Bike("Mountain Bike", 2023, "156PO98", "Red"),
                new Bike()
                {
                    Color = "Blue"
                }
            };

            Console.WriteLine("Vehicles that cannot be added in the DataBase, due to not passing the validation:");
            PopulateDataBase(listOfAllVehicles);

            Console.WriteLine("\nVehicles from the DataBase:");
            foreach (Vehicle vehicle in DataBase._db)
            {
                vehicle.PrintVehicle();
            }
        }
        // A method that populates the DataBase with all the vehicles that pass the validation
        static void PopulateDataBase(List<Vehicle> vehicles)
        {   
            foreach (Vehicle vehicle in vehicles)
            {
                if (Validator.Validate(vehicle))
                {
                    DataBase._db.Add(vehicle);
                }
                else
                {
                    vehicle.PrintVehicle(); 
                };
            }
            
        }

           
            

            
        
    }
}