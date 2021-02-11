using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

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
        int i = 0;

        while (i++ < 10)
        {
            Console.WriteLine($"I'm a child - {Name}...");
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        }

        Console.WriteLine($"Child thread ended - {Name}...");
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



            SecondThreadWay first = new SecondThreadWay("first");
            SecondThreadWay second = new SecondThreadWay("second");
            SecondThreadWay third = new SecondThreadWay("third");

            // first approach
            //while (first.InnerThread.IsAlive || second.InnerThread.IsAlive
            //    || third.InnerThread.IsAlive)
            //{
            //    //Console.WriteLine("I'm main...");
            //    Thread.Sleep(TimeSpan.FromMilliseconds(500));
            //}

            first.InnerThread.Join();
            second.InnerThread.Join();
            third.InnerThread.Join();

            Console.WriteLine("Main ended.");
        }
    }
}
