using System;

namespace Programming.Tasks
{
    public class SumDivisibilityTask : AbstractTask
    {
        public override string Title => "Sum Divisibility";
        public override string Description =>
            "Написать программу, которая определяет: кратна ли трем сумма цифр двухзначного числа";

        public override void Run()
        {
            Console.Write("Введите двухзначное число (10-99): ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number >= 10 && number <= 99)
                {
                    int firstDigit = number / 10;
                    int secondDigit = number % 10;
                    int sum = firstDigit + secondDigit;

                    if (sum % 3 == 0)
                    {
                        Console.WriteLine($"Сумма цифр числа {number} равна {sum} и кратна трем");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Сумма цифр числа {number} равна {sum} и не кратна трем"
                        );
                    }
                    Complete();
                }
                else
                {
                    Console.WriteLine("Число должно быть двухзначным (от 10 до 99)!");
                    Fail();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
            }
        }
    }
}
