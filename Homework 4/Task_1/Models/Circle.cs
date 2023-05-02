
namespace Models
{
    public class Circle: Shape
    {
        public int Radius { get; set; }

        public override void GetArea()
        {
            double area = 3.14 * Radius * Radius;
            Console.WriteLine($"The area of Circle {Id} is: {area}cm");
        }

        public override void GetPerimeter()
        {
            double perimeter = 3.14 * Radius * 2;
            Console.WriteLine($"The Perimeter of Circle {Id} is: {perimeter} cm");
        }

        
    }
}
