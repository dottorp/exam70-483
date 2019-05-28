using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Certification.Csharp.Threads
{
    public class Parallel_Invoke:ApplicationBase
    {
        private static Action[] tasks;
        static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
        }

        static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 ending");
        }       


        public override void Execute()
        {
            tasks = new Action[2];
            tasks[0] = Task1;
            tasks[1] = Task2;
            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine("===================");
            Parallel.Invoke(tasks);
            Console.WriteLine("Fine");
            Console.ReadKey();
        }
    }
}
