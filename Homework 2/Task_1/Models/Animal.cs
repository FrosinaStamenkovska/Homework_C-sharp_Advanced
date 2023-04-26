namespace Models
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }

        public Animal(string name, int age, string color) 
        {
            Name = name;
            Age = age;
            Color = color;
        }

        public abstract void PrintAnimal();
        
    }
}