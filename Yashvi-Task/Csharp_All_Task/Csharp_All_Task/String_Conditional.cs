using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class String_Conditional
    {
        public static void run()
        {
            Console.WriteLine("----String Formatter----");
            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();


            Console.WriteLine($"\nYour name has {fullName.Length} characters.");
            Console.WriteLine($"Uppercase: {fullName.ToUpper()}");

            if (fullName.Length >= 3)
            {
                Console.WriteLine($"First 3 letters: {fullName.Substring(0, 3)}");
            }
            //IndexOF
            int charpos = fullName.IndexOf("a");
            string lname = fullName.Substring(charpos);
            Console.WriteLine(lname);
            // String interpolation
            Console.WriteLine($"\nFormatted Message: Hello {fullName}, welcome to C#!");

            //nested if/else
            Console.WriteLine("----Nested if/else----");
            Console.WriteLine("Enter Your Marks");
            int mark = Convert.ToInt32(Console.ReadLine());

            if (mark >= 40)
            {
                Console.WriteLine("you passed");
                if (mark >= 75)
                {
                    Console.WriteLine("Grade:A+");
                }
                else if (mark >= 60)
                {
                    Console.WriteLine("Grade:B+");
                }
                else
                {
                    Console.WriteLine("You just pass");
                }
            }
            else
            {
                Console.WriteLine("you failed");
            }

            int time = 20;
            string result = (time < 18) ? "Good day." : "Good evening";
            Console.WriteLine(result);

            //switch
            Console.WriteLine("----Switch Case----");
            Console.WriteLine("1. Add two numbers");
            Console.WriteLine("2. Subtract two numbers");
            Console.WriteLine("3. Multiply two numbers");
            Console.WriteLine("4. Divide two numbers");
            Console.Write("Enter your choice (1-4): ");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Result: {num1 + num2}");
                    break;
                case 2:
                    Console.WriteLine($"Result: {num1 - num2}");
                    break;
                case 3:
                    Console.WriteLine($"Result: {num1 * num2}");
                    break;
                case 4:
                    if (num2 != 0)
                        Console.WriteLine($"Result: {num1 / num2}");
                    else
                        Console.WriteLine("Error: Division by zero!");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
