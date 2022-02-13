using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.MultiThreading
{
    class ScatterGatherPattern
    {
        //https://igorpopov.io/2018/06/30/asynchronous-programming-in-csharp/
        public void Foo()
        {
            var t1 = Task.Run(() => Console.WriteLine("Hello"));
            var t2 = Task.Run(() => Console.WriteLine("Hello"));
            Task.WaitAll(new Task[] {t1, t2 }, TimeSpan.FromSeconds(3));
        }
    }
}
