using System;

namespace Programming.Tasks
{
    public class DateCalculationTask : AbstractTask
    {
        public override string Title => "Date Calculation";
        public override string Description =>
            "Задана дата в формате <день>.<месяц>.<год>. Определить:\n"
            + "1) сколько дней прошло с начала года;\n"
            + "2) сколько дней осталось до конца года;\n"
            + "3) дату предыдущего дня;\n"
            + "4) дату следующего дня. ";

        public override void Run()
        {
            Console.Write("Введите дату в формате <день>.<месяц>.<год> (например, 15.03.2026): ");
            string input = Console.ReadLine();

            if (!TryParseDate(input, out int day, out int month, out int year))
            {
                Console.WriteLine("Некорректный формат даты!");
                Fail();
                return;
            }

            if (!IsValidDate(day, month, year))
            {
                Console.WriteLine("Некорректная дата!");
                Fail();
                return;
            }

            DateTime currentDate = new DateTime(year, month, day);
            DateTime yearStart = new DateTime(year, 1, 1);
            DateTime yearEnd = new DateTime(year, 12, 31);

            int daysFromStart = (currentDate - yearStart).Days + 1;

            int daysToEnd = (yearEnd - currentDate).Days;

            DateTime previousDay = currentDate.AddDays(-1);

            DateTime nextDay = currentDate.AddDays(1);

            Console.WriteLine($"\nВведенная дата: {currentDate:dd.MM.yyyy}");
            Console.WriteLine($"1) Дней прошло с начала года: {daysFromStart}");
            Console.WriteLine($"2) Дней осталось до конца года: {daysToEnd}");
            Console.WriteLine($"3) Предыдущий день: {previousDay:dd.MM.yyyy}");
            Console.WriteLine($"4) Следующий день: {nextDay:dd.MM.yyyy}");
            Complete();
        }

        private bool TryParseDate(string input, out int day, out int month, out int year)
        {
            day = month = year = 0;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            string[] parts = input.Split('.');

            if (parts.Length != 3)
                return false;

            return int.TryParse(parts[0], out day)
                && int.TryParse(parts[1], out month)
                && int.TryParse(parts[2], out year);
        }

        private bool IsValidDate(int day, int month, int year)
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
                return false;

            try
            {
                DateTime date = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
