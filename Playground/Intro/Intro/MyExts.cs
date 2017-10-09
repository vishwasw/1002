using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    static class MyExts
    {
        public static int DoubleIt(this int i)
        {
            return i * 2;
        }

        public static void PrintAssembly(this object obj)
        {
            Console.WriteLine(obj.GetType().Name);
        }
    }
}
