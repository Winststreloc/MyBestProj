 using System;
 using System.Threading;
 using System.Threading.Tasks;

 namespace WorkLesson_03._11
{
    public class Program
    {
        private static void Main(string[] args)
        {
            WakeUp();
            TurnOnTV();
            MakeTea();
            FryEggs();
            Washdishes();
            MakeTosts();
        }

        private static void WakeUp()
        {
            Console.WriteLine("Hello World!");
        }

        private static void TurnOnTV()
        {
            Console.WriteLine("Tv On");
        }

        private static async void MakeTea()
        {
            Console.WriteLine("Pour water into kettle");
            Console.WriteLine("Kettle ON");
            
            var waterBoilingTask = Task.Delay(2000);

            Console.WriteLine("Put tea in the cup");
            await waterBoilingTask;
            Console.WriteLine("Pour boiled water");
            
            var makingTeasTask = Task.Delay(1000);
            makingTeasTask.Wait();
            
            Console.WriteLine("Take tea");
        }

        private static void FryEggs()
        {
            Console.WriteLine("Put pan on fire");
            Thread.Sleep(1000);
            
            Console.WriteLine("Pour oil into the pan");
            Console.WriteLine("Pour eggs into the pan");

            Thread.Sleep(3000);
            
            Console.WriteLine("Get fried eggs from the pan");
        }

        private static void Washdishes()
        {
            Console.WriteLine("Dishes are cleaned");
        }

        private static void MakeTosts()
        {
            Console.WriteLine("Put bread into te toaster");

            Thread.Sleep(1000);
        }        
    }

}