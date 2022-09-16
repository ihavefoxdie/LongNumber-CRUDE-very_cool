using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Homework.Classes;

namespace Testing
{
    class Program
    {
        static void Main()
        {
            string ass = "900";

            LongNumber obj = new(ass);

            //obj = 10

            long o = (long)obj;

            int a = (int)obj;

            bool b = (bool)obj;

            ass.ToLongNumber();

            StringBuilder stringbuild = new StringBuilder("100");

            obj = 300 + 400;
            obj = "300000".ToLongNumber() + "303240";

            LongNumber obj2 = 900;
            
            Console.WriteLine(obj.Number);
            LongNumber obj3 = false;
            bool boolean1 = (bool)obj3;

            Console.WriteLine(obj2.Equals(obj));
            Console.WriteLine(obj3.Number);
            //Console.WriteLine(str1.CompareTo(str3));

            Console.WriteLine(a + ", " + o + ", " + b);
        }
    }
}