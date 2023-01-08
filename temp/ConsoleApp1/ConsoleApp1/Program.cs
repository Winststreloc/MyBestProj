using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console Application
            // 1. Создать приложение калькулятор, выполняющая основные арифметические операции на выбор:
            // - Сложение
            //     - Вычитание
            //     - Деление
            //     - Умножение
            //     - Процент от числа
            //     - Квадратный корень числа
            // 2. Отображение результата
            
            Console.WriteLine("Какую операцию выбрать? Выбор: +, - , * , /");
            var operation = Console.ReadLine();
            Console.WriteLine("Введи два числа");
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            if (operation == "+")
            {
                var result = a + b;
                Console.WriteLine($"a {operation} b = {result}");
            }
        }
    }
}