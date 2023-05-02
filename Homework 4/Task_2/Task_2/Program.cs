using Models;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Dog dog1 = new Dog()
            {
                Name = "Foo",
                Age = 1,
                FavouriteFood = "Chicken"
            };

            Dog dog2 = new Dog()
            {
                Name = "Lucy",
                Age = 5,
                FavouriteFood = "Meat"
            };
            Dog dog3 = new Dog()
            {
                Name = "Foo",
                Age = 3,
                FavouriteFood = "Dog Food"
            };

            Cat cat1 = new Cat()
            {
                Name = "Tom",
                Age = 2,
                Lazy = false,
                LivesLeft = 9
            };

            Cat cat2 = new Cat()
            {
                Name = "Lucifer",
                Age = 10,
                Lazy = true,
                LivesLeft = 5
            };

            Fish fish1 = new Fish()
            {
                Name = "Nemo",
                Age = 7,
                Color = "Orange and White",
                Size = "Small"
            };

            Fish fish2 = new Fish()
            {
                Name = "Dory",
                Age = 6,
                Color = "Blue and Yellow",
                Size = "Small"
            };


            PetStore<Dog> dogStore = new PetStore<Dog>();
            PetStore<Cat> catStore = new PetStore<Cat>();
            PetStore<Fish> fishStore = new PetStore<Fish>();

            dog2.PrintInfo();
            dogStore.Pets.Add(dog1);
            dogStore.Pets.Add(dog2);
            dogStore.Pets.Add(dog3);

            cat1.PrintInfo();
            catStore.Pets.Add(cat1);
            catStore.Pets.Add(cat2);

            fish1.PrintInfo();
            fishStore.Pets.Add(fish1);
            fishStore.Pets.Add(fish2);

            dogStore.BuyPet("lucy");
            dogStore.BuyPet("lucy");
            dogStore.BuyPet("foo");

            catStore.BuyPet("Garfield");
            catStore.BuyPet("lucifer");
            catStore.BuyPet("tom");

            Console.WriteLine($"\nPets in the Dog store:");
            dogStore.PrintPets();

            Console.WriteLine($"\nPets in the Cat store:");
            catStore.PrintPets();

            Console.WriteLine($"\nPets in the Fish store:");
            fishStore.PrintPets();
            







        }
    }
}