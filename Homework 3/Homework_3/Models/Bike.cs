
namespace Models
{
    public class Bike: Vehicle
    {
        public string Color { get; set; }

        public Bike(string type, int yearOfProduction, string batchNumber, string color)
            :base(type, yearOfProduction, batchNumber)
        {
            Color = color;
        }

        public Bike() { }

        public override void PrintVehicle()
        {
            Console.WriteLine($"Year of production: {YearOfProduction} - {Color} color.");
        }
    }
}
