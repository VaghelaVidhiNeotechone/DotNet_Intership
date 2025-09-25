using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Datatype_Variable
    {
        public static void run()
        {
            Console.Write("hello");
            Console.WriteLine(3 + 3);

            string name = "yashvi";
            Console.WriteLine(name);

            Console.WriteLine("Enter UserName");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Your Age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("UserName Is: " + username + " Your Age is: " + age);

            const int myNum = 15;
            //myNum = 20;
            Console.WriteLine(myNum);

            Console.WriteLine("----Diff Type with Interpolition----");
            string name1 = "Yashvi";
            int age1 = 21;
            double salary = 45000.75;
            bool isStudent = true;

            Console.WriteLine($"Name: {name1}");
            Console.WriteLine($"Age: {age1}");
            Console.WriteLine($"Salary: {salary}");
            Console.WriteLine($"Is Student? {isStudent}");

            Console.WriteLine($"Hello, my name is {name1}, I am {age1} years old, earn {salary}, Student = {isStudent}");
            Console.WriteLine("Hello my name is " + name1 + " i am " + age1 + " Years old , earn " + 45000 + " , Student = " + isStudent);

            double myDouble = 9.12;
            int myInt = (int)myDouble;
            Console.WriteLine(myDouble);
            Console.WriteLine(myInt);


            Console.WriteLine("----convert type----");
            int myInt2 = 10;
            double mydouble = 5.23;
            bool myBool = true;
            Console.WriteLine(Convert.ToString(myInt2));
            Console.WriteLine(Convert.ToDouble(myInt2));
            Console.WriteLine(Convert.ToInt32(mydouble));
            Console.WriteLine(Convert.ToString(myBool));



            Console.WriteLine("----Operator----");
            int a = 10, b = 3;

            Console.WriteLine($"a + b = {a + b}");
            Console.WriteLine($"a - b = {a - b}");
            Console.WriteLine($"a * b = {a * b}");
            Console.WriteLine($"a / b = {a / b}");
            Console.WriteLine($"a % b = {a % b}");

            int x = 7;
            x += 2;
            Console.WriteLine($"x after += 2 → {x}");

            Console.WriteLine($"a == b? {a == b}");
            Console.WriteLine($"a > b? {a > b}");
            Console.WriteLine($"a < b? {a < b}");
            Console.WriteLine(x > 5 && x < 10);
        }
    }
}
