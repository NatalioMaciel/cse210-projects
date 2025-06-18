using System;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square s1 = new Square("Red", 10);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 7, 2);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 55);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }


}