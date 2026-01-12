using System;

namespace Programming.Tasks
{
    public class ArithmeticProgressionTask : AbstractTask
    {
        public override string Title => "Arithmetic Progression (Recursive)";
        public override string Description =>
            "Даны первый член и разность арифметической прогрессии. Написать рекурсивный метод\n"
            + "для нахождения n-го члена и суммы n первых членов прогрессии.";

        public override void Run()
        {
            Console.Write("Введите первый член прогрессии (a): ");
            if (!double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            Console.Write("Введите разность прогрессии (d): ");
            if (!double.TryParse(Console.ReadLine(), out double d))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            Console.Write("Введите номер члена прогрессии (n): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
            {
                Console.WriteLine("n должно быть натуральным числом!");
                Fail();
                return;
            }

            double nthTerm = GetNthTerm(a, d, n);
            double sum = GetSum(a, d, n);

            Console.WriteLine($"\nРезультаты для арифметической прогрессии:");
            Console.WriteLine($"Первый член (a) = {a}");
            Console.WriteLine($"Разность (d) = {d}");
            Console.WriteLine($"\n{n}-й член прогрессии: {nthTerm:F2}");
            Console.WriteLine($"Сумма {n} первых членов: {sum:F2}");

            Console.WriteLine($"\nПервые {Math.Min(n, 10)} членов прогрессии:");
            for (int i = 1; i <= Math.Min(n, 10); i++)
            {
                Console.Write($"{GetNthTerm(a, d, i):F2}  ");
            }
            if (n > 10)
                Console.Write("...");
            Console.WriteLine();
            Complete();
        }

        private double GetNthTerm(double a, double d, int n)
        {
            if (n == 1)
                return a;

            return GetNthTerm(a, d, n - 1) + d;
        }

        private double GetSum(double a, double d, int n)
        {
            if (n == 1)
                return a;

            return GetSum(a, d, n - 1) + GetNthTerm(a, d, n);
        }
    }
}
