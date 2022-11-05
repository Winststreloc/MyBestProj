using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkLesson_03._11
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var ts = new CancellationTokenSource();
            var token = ts.Token;
            
            
            ts.Cancel();
            
            WakeUp();
            TurnOnTV();
            var makingTeaTask = MakeTea();
            var makingEggsTask = FryEggs();
            Washdishes();
            var makingTostsTask = MakeTosts();

            await makingTeaTask;
            FriedEggs eggs = await makingEggsTask;
            Toast toast = await makingTostsTask;

            Makesanwitch(eggs, toast);
        }

        private static void WakeUp()
        {
            Console.WriteLine("Hello World!");
        }

        private static void TurnOnTV()
        {
            Console.WriteLine("Tv On");
        }

        private static async Task MakeTea()
        {
            Console.WriteLine("Pour water into kettle");
            Console.WriteLine("Kettle ON");

            Console.WriteLine("Put tea in the cup");
            await Task.Delay(2000, CancellationToken.None);

            Console.WriteLine("Pour boiled water");

            var makingTeasTask = Task.Delay(1000);
            makingTeasTask.Wait();

            Console.WriteLine("Take tea");
        }

        private static async Task<FriedEggs> FryEggs(CancellationToken cancellationToken)
        {
            Console.WriteLine("Put pan on fire");
            await Task.Delay(1000);

            Console.WriteLine("Pour oil into the pan");
            Console.WriteLine("Pour eggs into the pan");
            if (cancellationToken.IsCancellationRequested)
            await Task.Delay(3000);

            Console.WriteLine("Get fried eggs from the pan");
            return new FriedEggs();
        }

        private static void Washdishes()
        {
            Console.WriteLine("Dishes are cleaned");
        }

        private static async Task<Toast> MakeTosts()
        {
            Console.WriteLine("Put bread into te toaster");

            await Task.Delay(1000);
            return new Toast();
        }

        private static void Makesanwitch(FriedEggs eggs, Toast toast)
        {
            Console.WriteLine("Combine toast and eggs into a sandwitch");
        }

        private class FriedEggs
        {
        }

        private class Toast
        {
        }
    }
}