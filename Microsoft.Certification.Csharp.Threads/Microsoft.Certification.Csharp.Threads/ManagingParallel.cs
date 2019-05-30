using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Certification.Csharp.Threads
{
    public class ManagingParallel : ApplicationBase
    {
        private ConcurrentBag<int> completedIterations;

        public ManagingParallel()
        {
            completedIterations = new ConcurrentBag<int>();
        }

        public override void Execute()
        {
            var items = Enumerable.Range(0, 500).ToArray();
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
                  {
                      if (i == 200)
                          loopState.Stop();
                      DoWork(items[i]);
                  });
            ElaborationCompleted = result.IsCompleted;
        }

        private void DoWork(int v)
        {
            completedIterations.Add(v);
        }
        public int CompletedIterationsCount
        {
            get
            {
                return completedIterations.Count;
            }
        }

        public bool ElaborationCompleted
        {
            get; private set;
        }
    }
}