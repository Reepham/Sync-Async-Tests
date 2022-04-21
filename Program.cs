using System;
using System.Threading;
using ConsoleUtility;

namespace Sync_Async_Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            Test.startTest(tokenSource.Token);
            Commands.Start(Test.startTest);
        }

    }
}
