using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Constractor_Encapsulation
    {
        class Person
        {
            private int age;
            public int Age
            {
                get { return age; }
                set { age = value; }
            }
        }

        public static void run()
        {
            Person person = new Person();
            person.Age = 21;

            Console.WriteLine(person.Age);
        }
    }
}

