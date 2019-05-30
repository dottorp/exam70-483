using System;

namespace Microsoft.Certification.Csharp.Threads
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            ApplicationBase app = new ManagingParallel();
            app.Execute();
            Console.ReadKey();
        }
    }
}