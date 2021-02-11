using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

class SomeThread
{
    private Thread InnerThread;
    private bool running = true;

    public SomeThread()
    {
        InnerThread = new Thread(new ThreadStart(this.Run));
        InnerThread.Start();
    }

    public void Run()
    {
        while(running)
        {
            Console.WriteLine("child...");
        }
    }

    public void Stop()
    {
        running = false;
    }
}

class SortProcess : IComparer<Process>
{
    public int Compare(Process x, Process y) => x.Id - y.Id;
}

class FirstThreadWay
{
    public string Name { get; }
    public FirstThreadWay(string name)
    {
        Name = name;
    }
    public void Run()
    {
        while(true)
        {
            Console.WriteLine($"I'm a child - {Name}...");
            Thread.Sleep(TimeSpan.FromMilliseconds(1000));
        }
    }
}

class SecondThreadWay
{
    public Thread InnerThread { get; }
    public string Name { get; }
    public SecondThreadWay(string name)
    {
        InnerThread = new Thread(new ThreadStart(this.Run));
        Name = name;
        //thread.IsBackground = true;
        InnerThread.Start();
    }
    public void Run()
    {
        try
        {
            //int i = 0;

            while (true)
            {
                Console.WriteLine($"I'm a child - {Name}...");
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }

            Console.WriteLine($"Child thread ended - {Name}...");
        } catch(ThreadAbortException ex)
        {
            if ((int)ex.ExceptionState != 0)
            {
                Console.WriteLine($"Child thread ended - {Name}...");
                Console.WriteLine(ex.ExceptionState);
            }
            else
            {
                Thread.ResetAbort();
            }
        }

        while (true)
        {
            Console.WriteLine($"I'm a child - {Name}...");
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        }
    }
}

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process process = Process.Start("Notepad.exe");

            //process.WaitForExit();
            //Thread.Sleep(TimeSpan.FromSeconds(5));

            //process.Kill(); // dangerous!
            //Console.WriteLine("Main process ended");



            //Process[] processes = Process.GetProcesses(".");
            //Array.Sort(processes, new SortProcess());
            //foreach (Process process in processes)
            //{
            //    Console.WriteLine($"--> PID: {process.Id}\tName: {process.ProcessName}");
            //}


            //FirstThreadWay way = new FirstThreadWay("first");
            //FirstThreadWay way1 = new FirstThreadWay("second");
            //FirstThreadWay way2 = new FirstThreadWay("third");

            //Thread thread = new Thread(new ThreadStart(way.Run));
            //Thread thread1 = new Thread(new ThreadStart(way1.Run));
            //Thread thread2 = new Thread(new ThreadStart(way2.Run));

            //thread.Start();
            //thread1.Start();
            //thread2.Start();

            //while (true)
            //{
            //    Console.WriteLine("I'm main...");
            //    Thread.Sleep(TimeSpan.FromMilliseconds(1000));
            //}



            //SecondThreadWay first = new SecondThreadWay("first");
            //SecondThreadWay second = new SecondThreadWay("second");
            //SecondThreadWay third = new SecondThreadWay("third");

            //while (first.InnerThread.IsAlive || second.InnerThread.IsAlive
            //    || third.InnerThread.IsAlive)
            //{
            //    //Console.WriteLine("I'm main...");
            //    Thread.Sleep(TimeSpan.FromMilliseconds(500));
            //}

            //Thread.Sleep(TimeSpan.FromSeconds(2));
            //first.InnerThread.Suspend();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            //first.InnerThread.Resume();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            //first.InnerThread.Abort(0);

            //first.InnerThread.Join();
            //second.InnerThread.Join();
            //third.InnerThread.Join();

            //Printer printer1 = new Printer();
            //Printer printer2 = new Printer();


            //Writer writer = new Writer(printer1, "first");
            //Writer writer1 = new Writer(printer2, "second");
            //Writer writer2 = new Writer(printer1, "third");
            //Writer writer3 = new Writer(printer2, "fourth");

            //writer.InnerThread.Join();
            //writer1.InnerThread.Join();
            //writer2.InnerThread.Join();
            //writer3.InnerThread.Join();

            SomeThread some = new SomeThread();
            Thread.Sleep(2000);
            some.Stop();

            Console.WriteLine("Main ended.");
        }
    }
}
