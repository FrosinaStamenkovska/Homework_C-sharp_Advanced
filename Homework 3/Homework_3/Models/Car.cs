
namespace Models
{
    public class Car:Vehicle
    {
        public int FuelTank { get; set; }
        public string Countries { get; set; }

        public Car(string type, int yearOfProduction, string batchNumber, int fuelTank, string countries)
            :base(type, yearOfProduction, batchNumber)
        {
            FuelTank = fuelTank;
            Countries = countries;
        }

        public Car() { }

        public override void PrintVehicle()
        {
            Console.WriteLine($"{Type} - produced in: {Countries}");
        }
    }
}
