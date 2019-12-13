using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Certification.Csharp.Threads
{
    public class Parallel_Invoke:ApplicationBase
    {
        public override void Execute()
        {
            Console.WriteLine("START");
            Parallel.Invoke(() => Task1(), () => Task2(), () => Task3(), () => Task4(), () => Task5(), () => Task6(), () => Task7());
            Console.WriteLine("END. Press any key to continue.");
            Console.ReadKey();
        }

        static void Task1()
        {
            DownloadString("https://docs.microsoft.com/it-it/dotnet/api/system.net.webclient.downloadstring?view=netframework-4.8");
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} completed");
        }

        static void Task2()
        {
            DownloadString("https://docs.microsoft.com/it-it/dotnet/api/system.net.webclient.downloadstring?view=netframework-4.8");
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} completed");
        }

        static void Task3()
        {
            DownloadString("https://docs.microsoft.com/it-it/dotnet/api/system.net.webclient.downloadstring?view=netframework-4.8");
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} completed");
        }

        static void Task4()
        {
            DownloadString("https://docs.microsoft.com/it-it/dotnet/api/system.net.webclient.downloadstring?view=netframework-4.8");
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} completed");
        }

        static void Task5()
        {
            DownloadString("https://docs.microsoft.com/it-it/dotnet/api/system.net.webclient.downloadstring?view=netframework-4.8");
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} completed");
        }

        static void Task6()
        {
            DownloadString("https://docs.microsoft.com/it-it/dotnet/api/system.net.webclient.downloadstring?view=netframework-4.8");
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} completed");
        }

        static void Task7()
        {
            DownloadString("https://docs.microsoft.com/it-it/dotnet/api/system.net.webclient.downloadstring?view=netframework-4.8");
            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} completed");
        }

        private static void DownloadString(string address)
        {
            WebClient client = new WebClient();
            client.DownloadString(address);
        }

    }
}
