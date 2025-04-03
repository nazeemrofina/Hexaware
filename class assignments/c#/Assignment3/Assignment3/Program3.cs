using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Program3
    {
        public static void Main(string[] args)
        {
            CallingFunc f = new CallingFunc();
            //CallingFunc f2 = new CallingFunc();
            f.Func();
           // f2.Func();
            Console.WriteLine(f.Func());
        }
    }
    class CallingFunc
    {
        static int funccount = 0;
        public int Func()
        {
            funccount++;
            return funccount;
        }
    }
}
