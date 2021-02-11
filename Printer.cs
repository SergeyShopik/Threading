using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    public class Printer
    {
        public void print(string text)
        {
            Console.Write("[");
            foreach (char c in text)
            {
                Thread.Sleep(new Random().Next(0, 100));
                Console.Write(c);
                Thread.Sleep(new Random().Next(0, 100));
            }
            Console.WriteLine("]");
        }
    }
}
