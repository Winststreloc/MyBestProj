using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ASYNCAWAIT.Models;

namespace Asyncshronous
{
    public static class Aynchronous
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(() =>
            {
                if (Console.ReadKey(true).KeyChar == 'c')
                {
                    cancellationTokenSource.Cancel();
                }
            });
            CreateCappuchino();
        }

        private static async Task CreateCappuchino()
        {
            GrindCofee();
            AlignCofee();
            CreateCoffeeTablet();
            var espesso = CreateEspesso();
            Milk milk = await TakeMilkInFridge();
            var shakeMilk = CreateShakeMilk(milk);
            
            var task = new List<Task>() { espesso, shakeMilk };
            if (!Task.WaitAll(task.ToArray(), 20000))
            {
                Console.WriteLine("Lifetime espresso 30 sekonds");
            }
            MakeCapuchino();
        }
        
        private static async Task GrindCofee()
        {
            Console.WriteLine($"Start grinding coffee{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(8000);

            Console.WriteLine($"End grinding cofee{Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task AlignCofee()
        {
            Console.WriteLine($"Start align coffee{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine("End align");
        }

        private static CoffeeTablet CreateCoffeeTablet()
        {
            Console.WriteLine($"CreateCoffeeTablet{Thread.CurrentThread.ManagedThreadId}");
            return new CoffeeTablet();
        }

        private static async Task<Espesso> CreateEspesso()
        {
            Console.WriteLine($"Start create espresso{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(10000);

            Console.WriteLine("Espresso ready");
            return new Espesso();
        }

        private static async Task<Milk> TakeMilkInFridge()
        {
            Console.WriteLine($"Take milk {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(2000);
            Console.WriteLine("Pour milk into the pitcher");
            Task.Delay(1000);
            return new Milk();
        }

        private static async Task<ShakeMilk> CreateShakeMilk(Milk milk)
        {
            Console.WriteLine($"Start creating shake milk{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(5000);
            Console.WriteLine("Milk ready");
            return new ShakeMilk();
        }

        private static async Task<Cappuchino> MakeCapuchino()
        {
            Console.WriteLine($"Creating capuchino{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(5000);
            Console.WriteLine("Capuchino ready");
            return new Cappuchino();
        }
    }
}