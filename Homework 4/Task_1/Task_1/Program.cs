using Models;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle
            {
                Id = 1,
                Radius = 10,
            };

            Circle circle2 = new Circle
            {
                Id = 2,
                Radius = 3,
            };

            Circle circle3 = new Circle
            {
                Id = 3,
                Radius = 5,
            };

            Rectangle rectangle1 = new Rectangle
            {
                Id = 1,
                SideA = 2,
                SideB = 5
            };

            Rectangle rectangle2 = new Rectangle
            {
                Id = 2,
                SideA = 3,
                SideB = 6
            };

            Rectangle rectangle3 = new Rectangle
            {
                Id = 3,
                SideA = 5,
                SideB = 7
            };

            // Creating generic db for both types
            DataBase<Circle> circleData = new DataBase<Circle>();
            DataBase<Rectangle> rectangleData = new DataBase<Rectangle>();
            
            // Adding the Circle-objects in the DataBase
            circleData.Add(circle1);
            circleData.Add(circle2);
            circleData.Add(circle3);

            // Calling the methods of the DataBase
            circleData.PrintArea();
            circleData.PrintPerimeter();

            // Adding the Rectangle-objects in the DataBase
            rectangleData.Add(rectangle1);
            rectangleData.Add(rectangle2);
            rectangleData.Add(rectangle3);

            // Calling the methods of the DataBase
            rectangleData.PrintArea();
            rectangleData.PrintPerimeter();

            //Calling the extension methods for Circle and Rectangle, that print info for these types.
            foreach (Circle circle in circleData._data)
            {
                circle.PrintCircleInfo();
            }

            foreach (Rectangle rectangle in rectangleData._data)
            {
                rectangle.PrintRectangleInfo();
            }
            

        }
    }
}