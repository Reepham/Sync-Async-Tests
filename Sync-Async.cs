using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sync_Async_Tests
{

    class Test
    {
        private CancellationToken ct;

        public Test(CancellationToken ct)
        {
            this.ct = ct;
        }

        public Test()
        {
        }

        public static void startTest(CancellationToken ct)
        {
            Test t = new Test(ct);
            t.Testasnyc();
            t.Testsync();
        }


        private void Testsync()
        {
            DateTime time1 = DateTime.Now;

            Test test1 = Generatesync(1);
            Console.WriteLine("test Sync 1 complete");
            Test test2 = Generatesync(2);
            Console.WriteLine("test Sync 2 complete");
            Test test3 = Generatesync(3);
            Console.WriteLine("test Sync 3 complete");
            Test test4 = Generatesync(4);
            Console.WriteLine("test Sync 4 complete");
            Console.WriteLine("Test Sync Completed");

            DateTime time2 = DateTime.Now;
            Console.WriteLine("Sync-Timespan: " + time2.Subtract(time1).TotalMinutes);
        }


        private Test Generatesync(int n)
        {
            var test = new Test();
            Console.WriteLine("test Sync " + n + " pause");
            this.ct.ThrowIfCancellationRequested();
            Thread.Sleep(300);
            this.ct.ThrowIfCancellationRequested();
            Console.WriteLine("test Sync " + n + " unpause");
            return test;
        }



        private async void Testasnyc()
        {
            DateTime time1 = DateTime.Now;

            var testTask1 = GenerateAsync(1);
            var testTask2 = GenerateAsync(2);
            var testTask3 = GenerateAsync(3);
            var testTask4 = GenerateAsync(4);

            Test test = await testTask1;
            Console.WriteLine("test Async 1 complete");
            Test test2 = await testTask2;
            Console.WriteLine("test Async 2 complete");
            Test test3 = await testTask3;
            Console.WriteLine("test Async 3 complete");
            Test test4 = await testTask4;
            Console.WriteLine("test Async 4 complete");
            Console.WriteLine("Test Async Completed");

            DateTime time2 = DateTime.Now;
            Console.WriteLine("Async-Timespan: " + time2.Subtract(time1).TotalMinutes);

        }

        private async Task<Test> GenerateAsync(int n)
        {
            var test = new Test();
            Console.WriteLine("test Async " + n + " pause");
            this.ct.ThrowIfCancellationRequested();
            await Task.Delay(300);
            this.ct.ThrowIfCancellationRequested();
            Console.WriteLine("test Async " + n + " unpause");
            return test;
        }
    }
}