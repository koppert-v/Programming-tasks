using System;

namespace Programming.Tasks
{
    public class NumbersEndingWithDigitTask : AbstractTask
    {
        public override string Title => "Numbers Ending With Digit";
        public override string Description =>
            "Вывести на экран: все целые числа из диапазона от А до В (А≤В), оканчивающиеся на цифру Х;";

        public override void Run()
        {
            Console.Write("Введите начало диапазона A: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            Console.Write("Введите конец диапазона B: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            if (a > b)
            {
                Console.WriteLine("A должно быть меньше или равно B!");
                Fail();
                return;
            }

            Console.Write("Введите цифру X (0-9): ");
            if (!int.TryParse(Console.ReadLine(), out int x) || x < 0 || x > 9)
            {
                Console.WriteLine("X должно быть цифрой от 0 до 9!");
                Fail();
                return;
            }

            Console.WriteLine($"\nЧисла из диапазона [{a}, {b}], оканчивающиеся на {x}:");

            bool found = false;
            for (int i = a; i <= b; i++)
            {
                if (i % 10 == x)
                {
                    Console.Write(i + " ");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Таких чисел не найдено");
            }
            else
            {
                Console.WriteLine("Таких чисел не найдено");
            }

            Complete();
        }
    }
}
