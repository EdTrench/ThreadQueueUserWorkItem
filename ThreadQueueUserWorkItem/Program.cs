using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadQueueUserWorkItem
{
    class Program
    {
        static readonly Random Random = new Random();

        static void Main(string[] args)
        {

            Console.WriteLine("[{0}] Main called,", Thread.CurrentThread.ManagedThreadId);
            for(int i=0; i<10; i++)
            {
                ThreadPool.QueueUserWorkItem(SayHello, i);
            }
            Thread.Sleep(Random.Next(250, 500));
            Console.WriteLine("[{0}] Main done,", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }

        static void SayHello(object arg)
        {
            Thread.Sleep(Random.Next(250, 500));
            Console.WriteLine("[{0}] Hello, world {1}! ({2})",
                Thread.CurrentThread.ManagedThreadId,
                (int) arg,
                Thread.CurrentThread.IsBackground);
        }

    }
}
