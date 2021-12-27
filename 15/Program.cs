using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace laba15
{
    internal class Program
    {
        public static Thread thread3 = new Thread(new ParameterizedThreadStart(NumberWritePair));
        public static Thread thread4 = new Thread(new ParameterizedThreadStart(NumberWritePair));
        public static void Main(string[] args)
        {
            //1
            try
            {
                foreach (var process in Process.GetProcesses())
                {
                    if(process.Id == 0) continue;
                    Console.WriteLine($"id: {process.Id}; name: {process.ProcessName}; " +
                                      $"start time: {process.StartTime}; process time: {process.TotalProcessorTime}; " +
                                      $"priority: {process.PriorityClass}");
                }

                Console.WriteLine("-------------------------------------");
            }
            catch(Exception err){Console.WriteLine(err.Message);}

            //2
            try
            {
                var currentDomain = AppDomain.CurrentDomain;
                Console.WriteLine($"name: {currentDomain.FriendlyName}; " +
                                  $"directory: {currentDomain.BaseDirectory}; " +
                                  $"configurations inf: {currentDomain.SetupInformation.ApplicationName}");
                foreach (var assembly in currentDomain.GetAssemblies())
                {
                    Console.WriteLine(assembly.FullName);
                }

                var newDomain = AppDomain.CreateDomain("child_app");
                var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "MyApp.dll");
                newDomain.Load(assemblyPath);
                AppDomain.Unload(newDomain);
            }
            catch(Exception err){}

            Console.WriteLine("-------------------------------------");
            
            //3
            Thread newThread = new Thread(new ThreadStart(DoWork));
            newThread.Start();
            newThread.Suspend();
            newThread.Resume();
            
            Console.WriteLine($"name: {newThread.Name};" +
                              $"status: {newThread.ThreadState.ToString()};" +
                              $"priority: {newThread.Priority.ToString()}" +
                              $"id: {newThread.ManagedThreadId}");
            
            //4
            // Thread thread1 = new Thread(new ParameterizedThreadStart(NumberWriteQueue));
            // Thread thread2 = new Thread(new ParameterizedThreadStart(NumberWriteQueue));
            // thread1.Start("chetn");
            // thread2.Start("nechetn");
            // thread1.Priority = ThreadPriority.Highest;
            
            thread3.Start("chetn");
            thread4.Start("nechetn");

            //5
            Timer tmr = new Timer(new TimerCallback(SomeTask), 100000, 0, 2000);
        }
        
        static AutoResetEvent waitHandler = new AutoResetEvent(true);

        private static void SomeTask(object maxVal)
        {
            Console.WriteLine(Math.Pow(new Random().Next((int)maxVal), new Random().Next(20)));
        }
        
        private static void DoWork()
        {
            StreamWriter writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "values.txt"));
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i);
                writer.WriteLine(i);
                Thread.Sleep(100);
            }
            writer.Close();
        }

        public static void NumberWriteQueue(object type)
        {
            waitHandler.WaitOne();
            {
                StreamWriter writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "threadData.txt"));
                if ((string) type == "chetn")
                {
                    for (int i = 1; i < 100; i += 2)
                    {
                        Console.WriteLine("thread1---" + i);
                        writer.WriteLine(i);
                        Thread.Sleep(10);
                    }
                }

                if ((string) type == "nechetn")
                {
                    for (int i = 0; i < 100; i += 2)
                    {
                        Console.WriteLine("thread2---" + i);
                        writer.WriteLine(i);
                        Thread.Sleep(14);
                    }
                }
                writer.Close();
            }
            waitHandler.Set();
        }
        
        
        public static void NumberWritePair(object type)
        {
            Mutex mutexObj = new Mutex();
            int x = 1, y = 0;

            while (x < 100 && y < 100)
            {
                mutexObj.WaitOne();
                if ((string) type == "chetn")
                {
                    Console.WriteLine("thread1---" + x);
                    Thread.Sleep(10);
                    x += 2;
                }

                if ((string) type == "nechetn")
                {
                    Console.WriteLine("thread2---" + y);
                    Thread.Sleep(14);
                    y += 2;
                }
                mutexObj.ReleaseMutex();
            }
        }
    }
}