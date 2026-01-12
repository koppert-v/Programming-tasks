using System;

namespace Programming.Tasks
{
    public class AdjacentNumberPairsTask : AbstractTask
    {
        public override string Title => "Adjacent Number Pairs Analysis";
        public override string Description =>
            "На отрезке [a, b] найти все пары соседних натуральных чисел:\n"
            + "1. сумма которых является составным числом;\n"
            + "2. произведение которых является простым числом;\n"
            + "3. сумма которых образует симметричное число;\n"
            + "4. которые являются взаимопростыми числами;\n"
            + "5. наибольший общий делитель которых является простым числом. На отрезке [a, b] найти все пары соседних натуральных чисел:\n"
            + "1. сумма которых является составным числом;\n2. произведение которых является простым числом;\n"
            + "3. сумма которых образует симметричное число;\n"
            + "4. которые являются взаимопростыми числами;\n"
            + "5. наибольший общий делитель которых является простым числом. ";

        public override void Run()
        {
            Console.Write("Введите начало отрезка a (натуральное число): ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a < 1)
            {
                Console.WriteLine("a должно быть натуральным числом!");
                Fail();
                return;
            }

            Console.Write("Введите конец отрезка b (натуральное число): ");
            if (!int.TryParse(Console.ReadLine(), out int b) || b < 1)
            {
                Console.WriteLine("b должно быть натуральным числом!");
                Fail();
                return;
            }

            if (a >= b)
            {
                Console.WriteLine("a должно быть меньше b!");
                Fail();
                return;
            }

            AnalyzePairs(a, b);
            Complete();
        }

        private void AnalyzePairs(int a, int b)
        {
            Console.WriteLine($"\nАнализ пар соседних чисел на отрезке [{a}, {b}]:\n");

            Console.WriteLine("1) Пары, сумма которых является составным числом:");
            for (int n = a; n < b; n++)
            {
                int sum = n + (n + 1);
                if (IsComposite(sum))
                    Console.WriteLine($"   ({n}, {n + 1}) -> сумма = {sum}");
            }

            Console.WriteLine("\n2) Пары, произведение которых является простым числом:");
            for (int n = a; n < b; n++)
            {
                int product = n * (n + 1);
                if (IsPrime(product))
                    Console.WriteLine($"   ({n}, {n + 1}) -> произведение = {product}");
            }

            Console.WriteLine("\n3) Пары, сумма которых образует симметричное число:");
            for (int n = a; n < b; n++)
            {
                int sum = n + (n + 1);
                if (IsPalindrome(sum))
                    Console.WriteLine($"   ({n}, {n + 1}) -> сумма = {sum}");
            }

            Console.WriteLine("\n4) Пары взаимопростых чисел:");
            for (int n = a; n < b; n++)
            {
                if (GCD(n, n + 1) == 1)
                    Console.WriteLine($"   ({n}, {n + 1})");
            }

            Console.WriteLine("\n5) Пары, НОД которых является простым числом:");
            for (int n = a; n < b; n++)
            {
                for (int m = n + 1; m <= Math.Min(n + 3, b); m++)
                {
                    int gcd = GCD(n, m);
                    if (IsPrime(gcd))
                        Console.WriteLine($"   ({n}, {m}) -> НОД = {gcd}");
                }
            }
        }

        private bool IsPrime(int n)
        {
            if (n < 2)
                return false;
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;

            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        private bool IsComposite(int n)
        {
            return n > 1 && !IsPrime(n);
        }

        private bool IsPalindrome(int n)
        {
            string str = n.ToString();
            int len = str.Length;

            for (int i = 0; i < len / 2; i++)
            {
                if (str[i] != str[len - 1 - i])
                    return false;
            }
            return true;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
