using System;
using System.Threading;

namespace Microsoft.Certification.Csharp.Threads
{
    public abstract class ApplicationBase
    {
        public abstract void Execute();
        internal void ProcessItem(int v)
        {
            Console.WriteLine("Started working on " + v);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on " + v);
        }
    }
}