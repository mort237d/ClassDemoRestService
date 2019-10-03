using System;

namespace ConsumeREST
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            worker.Start();

            Console.ReadLine();
        }
    }
}
