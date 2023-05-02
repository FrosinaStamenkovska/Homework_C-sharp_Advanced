
namespace Models
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public PetTypeEnum Type { get; set; }
        public int Age { get; set; }

        public abstract void PrintInfo();
    }
}
