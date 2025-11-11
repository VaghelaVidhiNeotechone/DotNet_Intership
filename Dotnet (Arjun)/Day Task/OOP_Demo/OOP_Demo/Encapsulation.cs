using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Demo
{
    internal class Encapsulation
    {
        private double balance;

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public double GetBalance()
        {
            return balance;
        }

        public static void run()
        {
            Encapsulation acc = new Encapsulation();
            acc.Deposit(1000);
            Console.WriteLine($"Current Balance Is: {acc.GetBalance()}");
        }
    }
}
