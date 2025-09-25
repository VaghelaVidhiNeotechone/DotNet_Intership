using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__All_Day_Task
{
    internal class day4
    {

        class Car
        {
            string Brand;
            string Model;
            int Year;

            public Car(string brand, string model, int year)
            {
                Brand = brand;
                Model = model;
                Year = year;
            }

            public void Detail()
            {
                Console.WriteLine($"{Year} {Brand} {Model}");
            }
        }

        public static void car()
        {
            Console.WriteLine("----Create a class and print Details----");
            Car car1 = new Car("Toyota", "Corolla", 2022);
            Car car2 = new Car("Honda", "Civic", 2021);
            Car car3 = new Car("Tesla", "Model 3", 2023);

            car1.Detail();
            car2.Detail();
            car3.Detail();

            Console.WriteLine("Car Instantiate multiple and print details");
        }
    }
}
