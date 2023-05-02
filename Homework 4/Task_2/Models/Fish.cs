
namespace Models
{
    public class Fish:Pet
    {
        public string Color { get; set; }
        public string Size { get; set; }

        public Fish()
        {
            Type = PetTypeEnum.Fish;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} is a {Color} colored fish.");
        }
    }
}
