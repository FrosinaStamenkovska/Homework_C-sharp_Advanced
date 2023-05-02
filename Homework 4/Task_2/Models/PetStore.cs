
using System.Security.Cryptography.X509Certificates;

namespace Models
{
    public class PetStore<T> where T : Pet
    {
        public List<T> Pets { get; set;}

        public PetStore()
        { 
            Pets = new List<T>();
        }

        public void PrintPets()
        {
            if (Pets.Any())
            {
                Pets.ForEach(p => Console.WriteLine(p.Name));
            }
            else 
            {
                Console.WriteLine("There are no pets in this store");
            }
        }

        public void BuyPet(string name)
        {
            T chosenPet = Pets.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            if(chosenPet != null)
            {
                Pets.Remove(chosenPet);
                Console.WriteLine($"You have successfully bought {chosenPet.Name}");
            }
            else
            {
                Console.WriteLine($"There is no pet named {name} in this store.");
            }
        }

    }
}
