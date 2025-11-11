using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo
{
    internal class Abstraction
    {
        abstract class Shape
        {
            public abstract void Draw();
        }

        class Circle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Draw Circle");
            }
        }


        public static void run()
        {
            Shape s = new Circle();
            s.Draw();
        }

    }
}
