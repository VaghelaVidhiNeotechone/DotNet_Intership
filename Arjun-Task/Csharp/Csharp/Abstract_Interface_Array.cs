using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Abstract_Interface_Array
    {
        abstract class Shap
        {
            public abstract void GetArea();
            public void aa()
            {
                int a = 10 * 10;
                Console.WriteLine(a);
            }
        }

        class Circle : Shap
        {
            public override void GetArea()
            {
                double b = Math.PI * (20 * 20);
                Console.WriteLine(b);
            }
        }

        public static void Run()
        {
            Circle c = new Circle();
            c.GetArea();
            c.aa();
        }

        public static void Student()
        { 
        string[] studentName = {"Arjun", "Kriyan", "Jay", "Krishiv", "Ved"};
            Console.WriteLine(studentName[0]);
        }


        public static void Lists()
        {
            List<int> mark = new List<int>();
            mark.Add(76);
            mark.Add(89);
            mark.Add(94);
            mark.Add(80);
            
            //Console.WriteLine(mark.Capacity);
            //Console.WriteLine(mark.Count);

            //mark.Insert(4,30);

            foreach (int s in mark)
            {
                Console.WriteLine(s);
            }
            double average = mark.Average();
            Console.WriteLine("Average: " + average);
        }

        public static void Dictionarys()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Arjun", 98);
            dict.Add("Kriyan", 80);
            dict.Add("Jay", 72);
            dict.Add("Krishiv", 86);
            dict.Add("Ved", 91);

            foreach (var s in dict)
            {
                Console.WriteLine(s);
            }
        }
    }
}
