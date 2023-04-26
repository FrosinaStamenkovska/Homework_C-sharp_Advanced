namespace Models
{
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsClean { get; set; }
        public bool IsGasFull { get; set; }
        public bool IsBroken { get; set; }

        public Vehicle(string model, int year, bool isClean, bool isGasFull, bool isBroken)
        {
            Model = model;
            Year = year;
            IsClean = isClean;
            IsGasFull = isGasFull;
            IsBroken = isBroken;
        }


        public abstract void Drive();
    }
}