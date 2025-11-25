using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo
{
    internal class Inheritance
    {
        class Animal
        {
            public void Eat()
            {
                Console.WriteLine("Animal eats");
            }
        }

        class Dog : Animal
        {
            public void Bark()
            {
                Console.WriteLine("The dog barks");
            }
        }
        public static void run()
        {
            Dog d = new Dog();
            d.Eat();  
            d.Bark();
        }
    }
}
