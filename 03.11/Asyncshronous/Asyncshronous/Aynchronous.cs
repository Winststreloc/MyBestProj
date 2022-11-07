using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ASYNCAWAIT.Models;

namespace Asyncshronous
{
    public static class Aynchronous
    {
        public static async Task Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            
            GrindCofee(token);
            EndApp(cancellationTokenSource);
            AlignCofee(token);
            CreateCoffeeTablet(token);
            var espesso = CreateEspesso(token);
            Milk milk = await TakeMilkInFridge(token);
            var shakeMilk = CreateShakeMilk(milk, token);
            var task = new List<Task>() { espesso, shakeMilk };
            EndApp(cancellationTokenSource);
            if (!Task.WaitAll(task.ToArray(), 20000))
            {
                Console.WriteLine("Lifetime espresso 30 sekonds");
            }

            MakeCapuchino(token);
        }

        private static async Task EndApp(CancellationTokenSource cancellationToken)
        {
            if (Console.ReadLine() == "cancel")
            {
                cancellationToken.Cancel();                
            }
        }
        private static async Task GrindCofee(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Start grinding coffee{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(8000);

            Console.WriteLine($"End grinding cofee{Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task AlignCofee(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Start align coffee{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine("End align");
        }

        private static CoffeeTablet CreateCoffeeTablet(CancellationToken cancellationToken)
        {
            Console.WriteLine($"CreateCoffeeTablet{Thread.CurrentThread.ManagedThreadId}");
            return new CoffeeTablet();
        }

        private static async Task<Espesso> CreateEspesso(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Start create espresso{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(10000);

            Console.WriteLine("Espresso ready");
            return new Espesso();
        }

        private static async Task<Milk> TakeMilkInFridge(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Take milk {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(2000);
            Console.WriteLine("Pour milk into the pitcher");
            Task.Delay(1000);
            return new Milk();
        }

        private static async Task<ShakeMilk> CreateShakeMilk(Milk milk, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Start creating shake milk{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(5000);
            Console.WriteLine("Milk ready");
            return new ShakeMilk();
        }

        private static async Task<Cappuchino> MakeCapuchino(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Creating capuchino{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(5000);
            Console.WriteLine("Capuchino ready");
            return new Cappuchino();
        }
    }
}