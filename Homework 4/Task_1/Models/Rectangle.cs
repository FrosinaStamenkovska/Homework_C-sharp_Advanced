
namespace Models
{
    public class Rectangle : Shape
    {
        public int SideA {  get; set; }
        public int SideB { get; set; }

        public override void GetArea()
        {
            double area = SideA * SideB;
            Console.WriteLine($"The area of Rectangle {Id} is: {area}cm");
        }

        public override void GetPerimeter()
        {
            double perimeter = 2 * (SideA + SideB);
            Console.WriteLine($"The Perimeter of Rectangle {Id} is: {perimeter}cm");
        }

       
    }
}
