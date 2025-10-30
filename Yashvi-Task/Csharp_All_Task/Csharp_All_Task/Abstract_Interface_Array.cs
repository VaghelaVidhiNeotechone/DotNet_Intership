using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Abstract_Interface_Array
    {

        public abstract class Shape
        {
            public abstract double GetArea();
            public void Display()
            {
                Console.WriteLine("This is a shape.");
            }
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double GetArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public override double GetArea()
            {
                return Width * Height;
            }
        }

        public static void run()
        {
            Shape circle = new Circle(6);
            Shape rectangle = new Rectangle(9, 4);

            Console.WriteLine("----Define Abstract Shape----");
            circle.Display();
            //rectangle.Display();
            Console.WriteLine("Circle Area: " + circle.GetArea());
            Console.WriteLine("Rectangle Area: " + rectangle.GetArea());

            Console.WriteLine("----Store Name in Array----");
            string[] std = { "Yashvi", "Shivani", "Jahi", "Arya", "Dhyey" };
            foreach (string s in std) Console.WriteLine(s);

            Console.WriteLine("----List----");
            List<int> marks = new List<int>();
            marks.Add(87);
            marks.Add(90);
            marks.Add(75);
            marks.Add(67);
            marks.Add(59);
            //Console.WriteLine("Marks (List): " + string.Join(", ", marks));
            foreach (int m in marks)
                Console.WriteLine(m);
            double average = marks.Average();
            Console.WriteLine("Average Marks = " + average);

            Console.WriteLine("----Dictionary----");
            Dictionary<string, int> studentmark = new Dictionary<string, int>();
            studentmark.Add("Yashvi", 87);
            studentmark.Add("Shivani", 90);
            studentmark.Add("Jahi", 75);
            studentmark.Add("Arya", 67);
            studentmark.Add("Dhyey", 59);
            Console.WriteLine("Students Marks:");
            foreach (var mark in studentmark)
            {
                Console.WriteLine(mark.Key + "," + mark.Value);
            }

        }

    }
}
