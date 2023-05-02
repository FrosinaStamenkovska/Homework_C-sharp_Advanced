namespace Models
{
    public class Dog:Pet
    {
        public string FavouriteFood { get; set; }

        public Dog()
        {
            Type = PetTypeEnum.Dog;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} is a dog that is {Age} years old and it's favourite food is {FavouriteFood}");
        }
    }
}