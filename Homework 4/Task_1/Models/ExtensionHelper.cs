
namespace Models
{
    public static class ExtensionHelper
    {
        // • Extension methods for Circle and Rectangle, that print info for these types.
        public static void PrintCircleInfo(this Circle circle)
        {
            if (circle != null)
            {
                Console.WriteLine($"\nCircle {circle.Id} has a radius of {circle.Radius}cm.");
                circle.GetPerimeter();
                circle.GetArea();
            }
        }

        public static void PrintRectangleInfo(this Rectangle rectangle)
        {
            if (rectangle != null)
            {
                Console.WriteLine($"\nRectangle {rectangle.Id} info: Side A is {rectangle.SideA}cm and Side B is {rectangle.SideB}cm.");
                rectangle.GetPerimeter();
                rectangle.GetArea();
            }
        }
    }
}
