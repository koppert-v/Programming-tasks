using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming.Tasks
{
    public class ArrayOperationsTask : AbstractTask
    {
        public override string Title => "Array Operations";
        public override string Description => "Various operations with integer array";

        private List<int> _array;

        public override void Run()
        {
            try
            {
                _array = new List<int> { 12, -5, 8, 15, -3, 22, 8, 17, -10, 25, 4, 22, 19, 6 };

                Console.WriteLine("Исходный массив:");
                PrintArray(_array);

                Console.WriteLine("\nВыберите операцию (1-15):");
                Console.WriteLine("1) Удалить все четные числа");
                Console.WriteLine("2) Удалить все максимальные элементы");
                Console.WriteLine("3) Удалить числа из интервала");
                Console.WriteLine("4) Удалить числа с заданной последней цифрой");
                Console.WriteLine("5) Удалить элементы с k1 по k2");
                Console.WriteLine("6) Вставить перед первым отрицательным");
                Console.WriteLine("7) Вставить после последнего положительного");
                Console.WriteLine("8) Вставить перед всеми четными");
                Console.WriteLine("9) Вставить после элементов с заданной последней цифрой");
                Console.WriteLine("10) Вставить после элементов, кратных своему номеру");
                Console.WriteLine("11) Удалить элементы с различными цифрами");
                Console.WriteLine("12) Удалить повторяющиеся элементы");
                Console.WriteLine("13) Вставить после всех максимальных");
                Console.WriteLine("14) Вставить перед элементами с заданной цифрой");
                Console.WriteLine("15) Вставить между элементами с разными знаками");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 15)
                {
                    Console.WriteLine("Некорректный выбор операции!");
                    Fail();
                    return;
                }

                List<int> result = PerformOperation(_array, choice);

                if (result == null)
                {
                    Console.WriteLine("\nОперация не выполнена из-за ошибки.");
                    Fail();
                    return;
                }

                Console.WriteLine("\nРезультат:");
                PrintArray(result);

                Complete();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nНепредвиденная ошибка: {ex.Message}");
                Fail();
            }
        }

        private List<int> PerformOperation(List<int> array, int choice)
        {
            List<int> result = new List<int>(array);

            try
            {
                switch (choice)
                {
                    case 1:
                        result.RemoveAll(x => x % 2 == 0);
                        break;

                    case 2:
                        if (result.Count == 0)
                        {
                            Console.WriteLine("Массив пуст!");
                            return null;
                        }
                        int max = result.Max();
                        result.RemoveAll(x => x == max);
                        break;

                    case 3:
                        Console.Write("Введите начало интервала: ");
                        if (!int.TryParse(Console.ReadLine(), out int min))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        Console.Write("Введите конец интервала: ");
                        if (!int.TryParse(Console.ReadLine(), out int maxInterval))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        result.RemoveAll(x => x >= min && x <= maxInterval);
                        break;

                    case 4:
                        Console.Write("Введите последнюю цифру (0-9): ");
                        if (
                            !int.TryParse(Console.ReadLine(), out int lastDigit)
                            || lastDigit < 0
                            || lastDigit > 9
                        )
                        {
                            Console.WriteLine("Ошибка: введите цифру от 0 до 9!");
                            return null;
                        }
                        result.RemoveAll(x => Math.Abs(x) % 10 == lastDigit);
                        break;

                    case 5:
                        Console.Write("Введите k1 (начальный индекс, с 0): ");
                        if (!int.TryParse(Console.ReadLine(), out int k1))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        Console.Write("Введите k2 (конечный индекс): ");
                        if (!int.TryParse(Console.ReadLine(), out int k2))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        if (k1 >= 0 && k2 < result.Count && k1 <= k2)
                        {
                            result.RemoveRange(k1, k2 - k1 + 1);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: некорректный диапазон индексов!");
                            return null;
                        }
                        break;

                    case 6:
                        Console.Write("Введите новый элемент: ");
                        if (!int.TryParse(Console.ReadLine(), out int newElem6))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        int firstNegIndex = result.FindIndex(x => x < 0);
                        if (firstNegIndex != -1)
                        {
                            result.Insert(firstNegIndex, newElem6);
                        }
                        else
                        {
                            Console.WriteLine("В массиве нет отрицательных элементов!");
                            return null;
                        }
                        break;

                    case 7:
                        Console.Write("Введите новый элемент: ");
                        if (!int.TryParse(Console.ReadLine(), out int newElem7))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        int lastPosIndex = result.FindLastIndex(x => x > 0);
                        if (lastPosIndex != -1)
                        {
                            result.Insert(lastPosIndex + 1, newElem7);
                        }
                        else
                        {
                            Console.WriteLine("В массиве нет положительных элементов!");
                            return null;
                        }
                        break;

                    case 8:
                        Console.Write("Введите новый элемент: ");
                        if (!int.TryParse(Console.ReadLine(), out int newElem8))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        for (int i = result.Count - 1; i >= 0; i--)
                        {
                            if (result[i] % 2 == 0)
                                result.Insert(i, newElem8);
                        }
                        break;

                    case 9:
                        Console.Write("Введите последнюю цифру (0-9): ");
                        if (
                            !int.TryParse(Console.ReadLine(), out int digit9)
                            || digit9 < 0
                            || digit9 > 9
                        )
                        {
                            Console.WriteLine("Ошибка: введите цифру от 0 до 9!");
                            return null;
                        }
                        Console.Write("Введите новый элемент: ");
                        if (!int.TryParse(Console.ReadLine(), out int newElem9))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        for (int i = result.Count - 1; i >= 0; i--)
                        {
                            if (Math.Abs(result[i]) % 10 == digit9)
                                result.Insert(i + 1, newElem9);
                        }
                        break;

                    case 10:
                        Console.Write("Введите новый элемент: ");
                        if (!int.TryParse(Console.ReadLine(), out int newElem10))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        for (int i = result.Count - 1; i >= 0; i--)
                        {
                            if (i > 0 && result[i] % (i + 1) == 0)
                                result.Insert(i + 1, newElem10);
                        }
                        break;

                    case 11:
                        result.RemoveAll(x => HasAllDistinctDigits(x));
                        break;

                    case 12:
                        result = result.Distinct().ToList();
                        break;

                    case 13:
                        if (result.Count == 0)
                        {
                            Console.WriteLine("Массив пуст!");
                            return null;
                        }
                        Console.Write("Введите новый элемент: ");
                        if (!int.TryParse(Console.ReadLine(), out int newElem13))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        int max13 = result.Max();
                        for (int i = result.Count - 1; i >= 0; i--)
                        {
                            if (result[i] == max13)
                                result.Insert(i + 1, newElem13);
                        }
                        break;

                    case 14:
                        Console.Write("Введите цифру для поиска (0-9): ");
                        if (
                            !int.TryParse(Console.ReadLine(), out int digit14)
                            || digit14 < 0
                            || digit14 > 9
                        )
                        {
                            Console.WriteLine("Ошибка: введите цифру от 0 до 9!");
                            return null;
                        }
                        Console.Write("Введите новый элемент: ");
                        if (!int.TryParse(Console.ReadLine(), out int newElem14))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        for (int i = result.Count - 1; i >= 0; i--)
                        {
                            if (ContainsDigit(result[i], digit14))
                                result.Insert(i, newElem14);
                        }
                        break;

                    case 15:
                        Console.Write("Введите новый элемент: ");
                        if (!int.TryParse(Console.ReadLine(), out int newElem15))
                        {
                            Console.WriteLine("Ошибка: введите целое число!");
                            return null;
                        }
                        for (int i = result.Count - 2; i >= 0; i--)
                        {
                            if (
                                (result[i] > 0 && result[i + 1] < 0)
                                || (result[i] < 0 && result[i + 1] > 0)
                            )
                                result.Insert(i + 1, newElem15);
                        }
                        break;
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении операции: {ex.Message}");
                return null;
            }
        }

        private bool HasAllDistinctDigits(int num)
        {
            string digits = Math.Abs(num).ToString();
            return digits.Distinct().Count() == digits.Length;
        }

        private bool ContainsDigit(int num, int digit)
        {
            string numStr = Math.Abs(num).ToString();
            return numStr.Contains(digit.ToString());
        }

        private void PrintArray(List<int> array)
        {
            Console.WriteLine($"[{string.Join(", ", array)}] (Размер: {array.Count})");
        }
    }
}
