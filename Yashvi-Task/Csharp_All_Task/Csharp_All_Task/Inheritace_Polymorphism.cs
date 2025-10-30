using System;

namespace Csharp_All_Task
{
    internal class Inheritace_Polymorphism
    {
        class Animal
        {
            public string type = "Animal"; // initialized to avoid warning

            public void sound() // normal method
            {
                Console.WriteLine("bhauuu bhauuu");
            }

            public virtual void MakeSound() // virtual method
            {
                Console.WriteLine("The Animal Makes a Sound");
            }
        }

        class Dog : Animal
        {
            public string dogName = "Bull Dog";

            // override
            public override void MakeSound()
            {
                Console.WriteLine("Dog says: Bow Bow");
            }
        }

        class Cat : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Cat says: Meeww Meeww");
            }
        }

        public static void run()
        {
            Console.WriteLine("----Inheriting class----");
            Dog dog = new Dog();
            dog.type = "Dog"; // assign value
            dog.sound();
            Console.WriteLine(dog.type + " " + dog.dogName);

            Console.WriteLine("----Override a Method----");
            Animal mycat = new Cat();
            Animal mydog = new Dog();
            Animal myanimal = new Animal();

            myanimal.MakeSound();
            mycat.MakeSound();
            mydog.MakeSound();
        }
    }
}
