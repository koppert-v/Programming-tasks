using System;

namespace Programming.Tasks
{
    public class FunctionTableTask : AbstractTask
    {
        public override string Title => "Function Table Builder";
        public override string Description =>
            "Постройте таблицу значений функции y=f(x) для х∈[a, b] с шагом h";

        public override void Run()
        {
            Console.Write("Введите начало диапазона a: ");
            if (!double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            Console.Write("Введите конец диапазона b: ");
            if (!double.TryParse(Console.ReadLine(), out double b))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            if (a > b)
            {
                Console.WriteLine("a должно быть меньше или равно b!");
                Fail();
                return;
            }

            Console.Write("Введите шаг h: ");
            if (!double.TryParse(Console.ReadLine(), out double h) || h <= 0)
            {
                Console.WriteLine("Шаг должен быть положительным числом!");
                Fail();
                return;
            }

            Console.WriteLine("\n" + new string('=', 40));
            Console.WriteLine($"{"x", 10} | {"y", 20}");
            Console.WriteLine(new string('=', 40));

            for (double x = a; x <= b; x += h)
            {
                double y = CalculateY(x);
                Console.WriteLine($"{x, 10:F2} | {y, 20:F4}");
            }

            Console.WriteLine(new string('=', 40));
        }

        private double CalculateY(double x)
        {
            if (x + 2 <= 1)
            {
                return x * x;
            }
            if (x + 2 < 10)
            {
                return 1.0 / (x + 2);
            }

            return x + 2;
        }
    }
}
