using System;

namespace Programming.Tasks
{
    public class BirthYearTask : AbstractTask
    {
        public override string Title => "Birth year";
        public override string Description =>
            "Написать программу, которая запрашивает с клавиатуры имя человека и его возраст, и\nвыводит на экран следующее сообщение (в примере текущим годом считается 2009):";

        public override void Run()
        {
            Console.Write("Введите ваш возраст: ");
            int age = 0;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Error value not valid");
                Console.Write("Введите ваш возраст: ");
            }

            var birthYear = DateTime.Now.Year - age;
            Console.WriteLine($"Ваш возраст: {birthYear}");

            Complete();
        }
    }
}
