using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
    public class Writer
    {
        //private static object o = new object();
        public Thread InnerThread { get; }
        private Printer printer;
        private string text;


        public Writer(Printer printer, string text)
        {
            this.printer = printer;
            this.text = text;
            InnerThread = new Thread(new ThreadStart(this.Run));
            InnerThread.Start();
        }

        public void Run()
        {
            lock (typeof(Writer))// or Object o
            {
                printer.print(text);
            }

            //while(true)
            //{
            //    if (Monitor.TryEnter(typeof(Writer)))
            //    {
            //        printer.print(text);

            //        Monitor.Exit(typeof(Writer));
            //    }
            //    else
            //    {
            //        // can do smth else
            //    }
            //}



        }
    }
}
