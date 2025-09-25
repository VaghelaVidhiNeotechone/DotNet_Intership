using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_
{
    internal class Inheritance_Polymorphism
    {
       class Animal
        {
            public string Name;
            
            public void A()
            {
                Console.WriteLine("It's My Favorite");
            }

            public virtual void animalSound()
            {
                Console.WriteLine("The animal make a sound");
            }
        }

        class Dog : Animal
        {
            public int Age = 12;

            public override void animalSound()
            {
                Console.WriteLine("bow wow");
            }
        }

        class Pig : Animal
        {
            public override void animalSound()
            {
                Console.WriteLine("wee wee");
            }
        }

        public static void run()
        {
            Dog dog = new Dog();
            dog.A();

            Animal myAnimal = new Animal();
            Animal myDog = new Dog();
            Animal MyPig = new Pig();

            Console.WriteLine(dog.Name + dog.Age);

            myAnimal.animalSound();
            myDog.animalSound();
            MyPig.animalSound();
        }
    }
}


