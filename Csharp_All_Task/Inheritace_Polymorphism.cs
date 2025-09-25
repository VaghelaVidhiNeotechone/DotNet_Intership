using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Inheritace_Polymorphism
    {

        class Animal
        {
            public string type;//properties
            public void sound()//method
            {
                Console.WriteLine("bhauuu bhauuu");
            }
            public virtual void MakeSound()
            {
                Console.WriteLine("The Animal Makes a Sound");
            }
        }
        class Dog : Animal
        {
            public string dogName = "Bull Dog";
            //override
            public override void MakeSound()
            {
                Console.WriteLine("Dog says:Bow Bow");
            }
        }
        class Cat : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Cat says:Meeww Meeww");
            }
        }
        public static void run()
        {
            Console.WriteLine("----Inheriting class----");
            Dog dog = new Dog();
            dog.sound();
            Console.WriteLine(dog.type + "" + dog.dogName);

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
