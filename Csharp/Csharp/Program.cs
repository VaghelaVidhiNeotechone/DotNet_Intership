using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string name = " Mr. Arjun";
            //int pos = name.IndexOf('A');
            //string lname = name.Substring(pos);
            //int a = 5 + 5;
            //int b = 10;
            //double c = 19.99D;
            //bool d = true;
            //bool e = false;
            //double f = a;
            //int g = (int)c;
            //Console.WriteLine("Hello" + name);
            //Console.WriteLine(lname);
            //Console.WriteLine(a + b);
            //Console.WriteLine(c);
            //Console.WriteLine(d);
            //Console.WriteLine(e);
            //Console.WriteLine(f);
            //Console.WriteLine(g);
            //Console.WriteLine(Convert.ToString(a));
            //Console.WriteLine(Convert.ToDouble(b));
            //Console.WriteLine(Convert.ToInt32(c));
            //Console.WriteLine(Convert.ToString(e));
            //Console.WriteLine(name.Length);
            //Console.WriteLine(name.ToUpper());
            //Console.WriteLine(name.ToLower());
            //Console.WriteLine("Hello, World!");

            //string name = "John";
            //int age = 30;
            //double height = 5.7;
            //bool isStudent = true;
            //char grade = 'A';

            //Console.WriteLine($"Name: {name}");
            //Console.WriteLine($"Age: {age}");
            //Console.WriteLine($"Height: {height} feet");
            //Console.WriteLine($"Is Student: {isStudent}");
            //Console.WriteLine($"Grade: {grade}");

            //int a = 10, b = 3;

            //Console.WriteLine("Arithmetic Operators:");
            //Console.WriteLine($"a + b = {a + b}");
            //Console.WriteLine($"a - b = {a - b}");
            //Console.WriteLine($"a * b = {a * b}");
            //Console.WriteLine($"a / b = {a / b}");
            //Console.WriteLine($"a % b = {a % b}");


            //Console.WriteLine("\nAssignment Operators:");
            //int x = 5;
            //Console.WriteLine("Initial x = " + x);
            //x += 3;
            //Console.WriteLine("x += 3 => " + x);
            //x *= 2;
            //Console.WriteLine("x *= 2 => " + x);
            //x -= 4;
            //Console.WriteLine("x -= 4 => " + x);


            //Console.WriteLine("\nComparison Operators:");
            //Console.WriteLine($"a == b: {a == b}");
            //Console.WriteLine($"a != b: {a != b}");
            //Console.WriteLine($"a > b: {a > b}");
            //Console.WriteLine($"a < b: {a < b}");
            //Console.WriteLine($"a >= b: {a >= b}");
            //Console.WriteLine($"a <= b: {a <= b}");

            //Console.WriteLine("=== Simple String Formatter ===");

            //Console.Write("Enter a string: ");
            //string input = Console.ReadLine();

            //Console.WriteLine("\nChoose a formatting option:");
            //Console.WriteLine("1. Uppercase");
            //Console.WriteLine("2. Lowercase");
            //Console.WriteLine("3. Title Case");
            //Console.WriteLine("4. Trim Whitespace");
            //Console.WriteLine("5. Reverse String");

            //Console.Write("\nEnter your choice (1-5): ");
            //string choice = Console.ReadLine();

            //string result = "";

            //switch (choice)
            //{
            //    case "1":
            //        result = input.ToUpper();
            //        break;
            //    case "2":
            //        result = input.ToLower();
            //        break;
            //    case "3":
            //        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            //        result = textInfo.ToTitleCase(input.ToLower());
            //        break;
            //    case "4":
            //        result = input.Trim();
            //        break;
            //    case "5":
            //        char[] charArray = input.ToCharArray();
            //        Array.Reverse(charArray);
            //        result = new string(charArray);
            //        break;
            //    default:
            //        Console.WriteLine("Invalid choice.");
            //        return;
            //}

            //Console.WriteLine($"\nFormatted Result: {result}");

            //string correctUsername = "Arjun";
            //int correctPassword = 12321;

            //Console.WriteLine("Enter Username: ");
            //string username = Console.ReadLine();

            //if (username == correctUsername)
            //{
            //    Console.WriteLine("Enter password: ");
            //    int password = Convert.ToInt32(Console.ReadLine());

            //    if (password == correctPassword)
            //    {
            //        Console.WriteLine("Login Successful!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Incorrect password.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Username Not Found.");
            //}

            LoopsMethod.mySum();

            int myNum1 = LoopsMethod.Add(8, 5);
            double myNum2 = LoopsMethod.Add(4.3, 6.26);
            Console.WriteLine("Int: " + myNum1);
            Console.WriteLine("Double: " + myNum2);

            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            long fact = LoopsMethod.Factorial(number);

            if (fact != -1)
                Console.WriteLine($"Factorial of {number} is: {fact}");


            ClassObject myCar1 = new ClassObject("Toyota", "Camry", 2020);
            ClassObject myCar2 = new ClassObject("Honda", "Civic", 2021);
            ClassObject myCar3 = new ClassObject("Ford", "Mustang", 2022);
            ClassObject myCar4 = new ClassObject("Tesla", "Model S", 2023);
            myCar1.Multiple();
            myCar2.Multiple();
            myCar3.Multiple();
            myCar4.Multiple();

            //Constractor_Encapsulation first = new Constractor_Encapsulation ("Arjun", 21);
            //first.Obj();

            Constractor_Encapsulation.run();

            Inheritance_Polymorphism.run();

            Abstract_Interface_Array.Run();

            Abstract_Interface_Array.Student();
            Abstract_Interface_Array.Lists();
            Abstract_Interface_Array.Dictionarys();

        }
    }
}
