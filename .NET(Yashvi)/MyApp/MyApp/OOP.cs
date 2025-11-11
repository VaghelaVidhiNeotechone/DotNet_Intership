using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class OOP
    {
        public class Vehicle
        {
            //  ENCAPSULATION — Hiding data using private fields
            private string _engineNumber;

            public string EngineNumber
            {
                get { return _engineNumber; }
                set
                {
                    if (value.Length == 6)
                        _engineNumber = value;
                    else
                        Console.WriteLine("Invalid engine number (must be 6 characters)");
                }
            }
            public string Brand { get; set; }

            public void Start()
            {
                Console.WriteLine($"{Brand} engine started!");
            }
        }
        //INHERITANCE — Derived class inherits base class
     
        public class Car : Vehicle
        {
            public string Model { get; set; }
            public virtual void Drive()
            {
                Console.WriteLine($"{Brand} {Model} is driving at normal speed.");
            }
        }
        public class SportsCar : Car
        {
            public override void Drive()
            {
                Console.WriteLine($"{Brand} {Model} is driving at 200 km/h !");
            }
        }
        // ABSTRACTION — Hiding complexity using abstract class
        public abstract class Payment
        {
            public abstract void MakePayment(double amount);
        }

        public class CreditCardPayment : Payment
        {
            public override void MakePayment(double amount)
            {
                Console.WriteLine($"Payment of ₹{amount} made successfully using Credit Card");
            }
        }

       public static void run()
        {
                Console.WriteLine("=== C# OOP Concepts Example ===\n");

                // CLASS & OBJECT
                Car car1 = new Car();
                car1.Brand = "Toyota";
                car1.Model = "Corolla";
                car1.EngineNumber = "ABC123";
                car1.Start();    
                car1.Drive();   

                Console.WriteLine();

                SportsCar sportCar = new SportsCar();
                sportCar.Brand = "Ferrari";
                sportCar.Model = "488 GTB";
                sportCar.EngineNumber = "XYZ789";
                sportCar.Start();
                sportCar.Drive();  

                Console.WriteLine();

                Payment payment = new CreditCardPayment();
                payment.MakePayment(50000);
            }
        }
    }






