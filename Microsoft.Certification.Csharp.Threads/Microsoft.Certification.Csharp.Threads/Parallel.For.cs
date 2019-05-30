using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Certification.Csharp.Threads
{
    internal class Parallel_For : ApplicationBase
    {
        public override void Execute()
        {
            var items = Enumerable.Range(0, 500).ToArray();
            Parallel.For(0, items.Length, i =>
            {
                ProcessItem(items[i]);
            });
            Console.WriteLine("Parallel for ended");
        }
    }
}