using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Constructor_Encapculation
    {

        public static void run()
        {
            Console.WriteLine("----Constructor to inisialize object----");
            Car Flowers = new Car("Lotus");
            Console.WriteLine("Flower Name: " + Flowers.flower);

            Console.WriteLine("----Private Field with public get/set----");
            Person Obj = new Person();
            Obj.Name = "Yashvi";
            Console.WriteLine("Hey " + Obj.Name);
        }
        class Car
        {
            public string flower;

            public Car(string flowerName)
            {
                flower = flowerName;
            }
        }
        class Person
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }
    }
}
