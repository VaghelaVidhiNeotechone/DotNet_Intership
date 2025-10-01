using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class index
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***************** Day - 1(Datatype_Variable) ******************");
            Datatype_Variable.run();
            Console.WriteLine("***************** Day - 2(String_Conditional) ******************");
            String_Conditional.run();
            Console.WriteLine("***************** Day - 3(Loops_Method) ******************");
            Loops_Method.run();
            Console.WriteLine("***************** Day - 4(Class_Object) ******************");
            Class_Object.car();
            Console.WriteLine("***************** Day - 5(Constructor_Encapculation) ******************");
            Constructor_Encapculation.run();
            Console.WriteLine("***************** Day - 6(Inheritace_Polymorphism) ******************");
            Inheritace_Polymorphism.run();
            Console.WriteLine("***************** Day - 7(Abstract_Interface_Array) ******************");
            Abstract_Interface_Array.run();
            Console.WriteLine("***************** Day - 8(LeetCode_Practice) ******************");
            TwoSumNum.run();
            Longest_Common_Prefix.run();
            Search_Insert_Position.run();
            Add_Two_Numbers.run();
            Longest_Substring_Without_Repeating_Characters.run();


        }
    }
}
