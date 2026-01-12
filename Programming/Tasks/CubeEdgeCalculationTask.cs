using System;

namespace Programming.Tasks
{
    public class CubeEdgeCalculationTask : AbstractTask
    {
        public override string Title => "Cube Edge Calculation";
        public override string Description =>
            "Написать программу, которая подсчитывает: ребро куба, объем которого равен v;";

        public override void Run()
        {
            Console.Write("Введите объем куба (V): ");

            if (double.TryParse(Console.ReadLine(), out double volume))
            {
                if (volume > 0)
                {
                    double edge = Math.Pow(volume, 1.0 / 3.0);
                    Console.WriteLine($"Ребро куба: {edge:F2}");
                    Complete();
                }
                else
                {
                    Console.WriteLine("Объем должен быть положительным числом!");
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
