using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Certification.Csharp.Threads
{
    public class Parallel_Foreach : ApplicationBase
    {
        public override void Execute()
        {
            var items = Enumerable.Range(0, 500);
            Parallel.ForEach(items, item => { ProcessItem(item); });
        }
    }
}