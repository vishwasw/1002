using System;
using System.Collections.Generic;

namespace Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            Person emp = new Employee();
            emp.FirstName = "Bill";
            emp.LastName = "Gates";

            Console.WriteLine(emp.FullName);

            Console.ReadKey();
        }
    }   
}


