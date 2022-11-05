using System;
using System.Threading;
using System.Threading.Tasks;
using ASYNCAWAIT.Models;

namespace Asyncshronous
{
    public static class Aynchronous
    {
        public static async Task Main(string[] args)
        {

            GrindCofee();
            AlignCofee();
            CreateCoffeeTablet();
            var espesso = CreateEspesso();
            var milk = TakeMilkInFridge();
            var shakeMilk = CreateShakeMilk();
            
            await espesso;
            await milk;
            await shakeMilk;
            
            Cappuchino capuchino = await MakeCapuchino();

            // Holder holder = new Holder();
            // //create espresso
            // GroundCofee groundCofee = await GrindCofee();
            // AlignCofee();
            // CoffeeTablet coffeeTablet =  CreateCoffeeTablet(groundCofee, holder);
            // Espesso espesso = await CreateEspesso(coffeeTablet, holder);
            // //create milk shake
            // await TakeMilkInFridge();
            // ShakeMilk shakeMilk = await CreateShakeMilk();
            // Capuchino _ = await MakeCapuchino(espesso, shakeMilk);
        }

        private static async Task<GroundCofee> GrindCofee()
        {
            Console.WriteLine($"Start grinding coffee{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(8000);
            
            Console.WriteLine($"End grinding cofee{Thread.CurrentThread.ManagedThreadId}");
            return new GroundCofee();
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

        private static async Task TakeMilkInFridge()
        {
            Console.WriteLine($"Take milk {Thread.CurrentThread.ManagedThreadId}");
            Task.Delay(2000);
            Console.WriteLine("Pour milk into the pitcher");
            Task.Delay(1000);
        }

        private static async Task<ShakeMilk> CreateShakeMilk()
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