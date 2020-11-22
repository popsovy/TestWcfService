using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestWcfApp.ServiceReference1;

namespace TestWcfApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Service1Client();
            var threads = new List<Thread>();
            for(var i = 0; i < 100; i++)
            {
                var thread = new Thread(() =>
                {
                    var time = DateTime.Now;
                    var line = $"Starting thread {i} at {time}. ";
                    var result = client.ExecuteMethod();
                    line += $"Done in {DateTime.Now.Subtract(time).TotalMilliseconds} ms";
                    Console.WriteLine(line);
                });
                thread.Start();
                threads.Add(thread);
            }
            foreach(var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("Done");
            Console.Read();
        }
    }
}
