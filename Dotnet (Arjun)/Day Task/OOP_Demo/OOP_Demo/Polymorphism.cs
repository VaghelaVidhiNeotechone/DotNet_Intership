using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo
{
    internal class Polymorphism
    {
        //Method Overloading
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }


        public static void run()
        {
            Polymorphism p = new Polymorphism();
            Console.WriteLine(p.Add(5, 10));
            Console.WriteLine(p.Add(2.5, 3.5));
        }



        //Method Overriding

        class Animal
        {
            public virtual void Speak()
            {
                Console.WriteLine("The animal speaks");
            }
        }

        class Dog : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("The dog barks");
            }
        }

        public static void run2()
        {
            Animal a = new Dog();
            a.Speak();  
        }
    }
}
