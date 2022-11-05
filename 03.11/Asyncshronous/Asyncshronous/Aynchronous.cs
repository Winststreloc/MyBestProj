namespace ASYNCAWAIT
{
    public static class Aynchronous
    {
        public static void Main(string[] args)
        {
            Holder holder = new Holder();
            
            
            
            GroundCofee groundCofee = GrindCofee();
            AlignCofee();
            CoffeeTablet coffeeTablet = CreateCoffeeTablet(groundCofee, holder);
            Espesso espesso = CreateEspesso(coffeeTablet, holder);

            Milk milk = TakeMilkInFridge();
            ShakeMilk shakeMilk = CreateShakeMilk(milk);
            Capuchino capuchino = MakeCapuchino(espesso, shakeMilk);

        }
        public static GroundCofee GrindCofee()
        {
            Console.WriteLine("Start grinding cofee");
            Task.
            Thread.Sleep(8000);
            Console.WriteLine("End grinding cofee");
            return new GroundCofee();
        }

        public static void AlignCofee()
        {
            Console.WriteLine("Start align coffee");
            Thread.Sleep(2000);
            Console.WriteLine("End align");
        }

        public static CoffeeTablet CreateCoffeeTablet(GroundCofee groundCofee, Holder holder)
        {
            Console.WriteLine("CreateCoffeeTablet");
            return new CoffeeTablet();
        }

        public static Espesso CreateEspesso(CoffeeTablet coffeeTablet, Holder holder)
        {
            Console.WriteLine("Start create espresso");
            Thread.Sleep(22000);
            Console.WriteLine("Espresso ready");
            return new Espesso();
        }

        public static Milk TakeMilkInFridge()
        {
            Console.WriteLine("Take milk");
            return new Milk();
        }

        public static ShakeMilk CreateShakeMilk(Milk milk)
        {
            Console.WriteLine("Start creating shake milk");
            Thread.Sleep(5000);
            Console.WriteLine("Milk ready");
            return new ShakeMilk();
        }

        public static Capuchino MakeCapuchino(Espesso espesso, ShakeMilk milk)
        {
            Console.WriteLine("Creating capuchino");
            Thread.Sleep(5000);
            Console.WriteLine("Capuchino ready");
            return new Capuchino();
        }
    }
}