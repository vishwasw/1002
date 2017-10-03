using System;
using System.Collections.Generic;
using System.Linq;

namespace Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person> {
                new Employee { FirstName = "Bill", LastName = "Gates" },
                new Employee { FirstName = "Steve", LastName = "Jobs" }
            };

            var r = people.FindAll(p => p.FirstName.StartsWith("S"));

            foreach (var p in r) {
                Console.WriteLine(p.FullName);
            }

            Console.ReadKey();
        }
    }   
}


