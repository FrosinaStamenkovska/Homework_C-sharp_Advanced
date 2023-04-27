namespace Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int YearOfProduction { get; set; }

        public string BatchNumber { get; set; }

        public Vehicle(string type, int yearOfProduction, string batchNumber) 
        {
            Random rnd = new Random();
            Id = rnd.Next(1, int.MaxValue);
            Type = type;
            YearOfProduction = yearOfProduction;
            BatchNumber = batchNumber;
        }

        public Vehicle() { }

        public virtual void PrintVehicle()
        {
            Console.WriteLine($"Id: {Id}, {Type} - {YearOfProduction} year.");
        }



    }
}