using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Certification.Csharp.Threads.Test
{
    [TestClass]
    public class ManagingParallelTest
    {
        private ApplicationBase app;
        private ManagingParallel mp;
        [TestInitialize]
        public void Init()
        {
            app = new ManagingParallel();
            app.Execute();
            mp = app as ManagingParallel;
        }

        [TestMethod]
        public void WeAreRunningManagingParallelApp()
        {
            Assert.IsNotNull(mp);
        }

        [TestMethod]
        public void IteratorWontInstantlyStopAnyExecutingIteration()
        {            
            Assert.IsTrue(mp.CompletedIterationsCount>=200);
        }

        [TestMethod]
        public void ElaborationIsNotCompleted()
        {
            Assert.IsFalse(mp.ElaborationCompleted);
        }
    }
}
