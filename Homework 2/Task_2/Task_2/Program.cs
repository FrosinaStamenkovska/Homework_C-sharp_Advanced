using Models;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("BMW", 2015, true, false, true);
            Car car2 = new Car("Shkoda", 2018, false, true, false);
            Car car3 = new Car("Opel", 2010, true, true, true);

            Truck truck1 = new Truck("Man", 2017, false, false, false);
            Truck truck2 = new Truck("Volvo", 2020, true, false, false);

            CarCenter carCenter = new CarCenter();
            car1.Drive();
            car2.Drive();
            car3.Drive();
            truck1.Drive();
            truck2.Drive();

            Console.WriteLine($"{car2.Model} isClean Status before:");
            Console.WriteLine(car2.IsClean);
            carCenter.WashCar(car2);
            Console.WriteLine($"{car2.Model} isClean Status after:");
            Console.WriteLine(car2.IsClean);

            Console.WriteLine($"{truck2.Model} isGasFull Status before:");
            Console.WriteLine(truck2.IsGasFull);
            carCenter.PumpGas(truck2);
            Console.WriteLine($"{truck2.Model} isGasFull Status after:");
            Console.WriteLine(truck2.IsGasFull);
            Console.WriteLine($"{truck2.Model} Driving Status after:");
            truck2.Drive();


            carCenter.CheckVehicle(car1);
            carCenter.CheckVehicle(car2);
            carCenter.FixVehicle(truck1);

            Console.WriteLine($"{car3.Model} isBroken Status before:");
            Console.WriteLine(car3.IsBroken);
            carCenter.FixVehicle(car3);
            Console.WriteLine($"{car3.Model} isBroken Status after:");
            Console.WriteLine(car3.IsBroken);
            Console.WriteLine($"{car3.Model} Driving Status after:");
            car3.Drive();

            Console.WriteLine($"The number of services that have been done by the Car center: {carCenter.NumberOfServices}");
            carCenter.PrintVehicles();

            CarWash carWash = new CarWash();
            GasPump gasPump = new GasPump();
            RepairService repairService = new RepairService();

            carWash.WashTruck(truck1);
            Console.WriteLine($"{truck1.Model} isClean Status after:");
            Console.WriteLine(truck1.IsClean);

            carWash.WashCar(car1);
            Console.WriteLine($"{car1.Model} isClean Status after:");
            Console.WriteLine(car1.IsClean);

           
            gasPump.PumpGas(car2);
            Console.WriteLine($"{car2.Model} isGasFull Status after:");
            Console.WriteLine(car2.IsGasFull);

            Console.WriteLine($"Checking the condition of {car3.Model}");
            repairService.CheckVehicle(car3);

            repairService.FixVehicle(truck2);
            Console.WriteLine($"{truck2.Model} isBroken Status after:");
            Console.WriteLine(truck2.IsBroken);

        }
    }
}