
namespace Models
{
    public class Cat:Pet
    {
        public bool Lazy { get; set; }
        public int LivesLeft { get; set; }

        public Cat()
        {
            Type = PetTypeEnum.Cat;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"The cat {Name} is {Age} years old and it has {LivesLeft} lives left.");
        }
    }
}
