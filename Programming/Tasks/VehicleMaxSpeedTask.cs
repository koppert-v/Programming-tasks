using System;

namespace Programming.Tasks
{
    public class VehicleMaxSpeedTask : AbstractTask
    {
        public override string Title => "Vehicle Max Speed";
        public override string Description =>
            "Дан признак транспортного средства: a – автомобиль, в – велосипед, м – мотоцикл, с –\n"
            + "самолет, п – поезд. Вывести на экран максимальную скорость транспортного средства в\n"
            + "зависимости от введенного признака (максимальные значения скорости задать\n"
            + "самостоятельно в теле программы).";

        public override void Run()
        {
            Console.WriteLine("Введите признак транспортного средства:");
            Console.WriteLine("а - автомобиль");
            Console.WriteLine("в - велосипед");
            Console.WriteLine("м - мотоцикл");
            Console.WriteLine("с - самолет");
            Console.WriteLine("п - поезд");
            Console.Write("Ваш выбор: ");

            string input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            char vehicle = input[0];
            string result = GetMaxSpeed(vehicle);
            Console.WriteLine(result);
            Complete();
        }

        private string GetMaxSpeed(char vehicleType)
        {
            switch (vehicleType)
            {
                case 'а':
                    return "Автомобиль: максимальная скорость 250 км/ч";

                case 'в':
                    return "Велосипед: максимальная скорость 50 км/ч";

                case 'м':
                    return "Мотоцикл: максимальная скорость 150 км/ч";

                case 'с':
                    return "Самолет: максимальная скорость 900 км/ч";

                case 'п':
                    return "Поезд: максимальная скорость 600 км/ч";

                default:
                    return "Неизвестный тип транспортного средства!";
            }
        }
    }
}
