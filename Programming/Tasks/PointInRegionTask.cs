using System;

namespace Programming.Tasks
{
    public class PointInRegionTask : AbstractTask
    {
        public override string Title => "Point in Region Check";
        public override string Description =>
            "Дана точка на плоскости с координатами (х, у). Составить программу, которая выдает одно из\n"
            + "сообщений «Да», «Нет», «На границе» в зависимости от того, лежит ли точка внутри\n"
            + "заштрихованной области, вне заштрихованной области, или на ее границе. Области задаются\n"
            + "графически следующим образом: задание №10";

        public override void Run()
        {
            Console.Write("Введите координату X: ");
            if (!double.TryParse(Console.ReadLine(), out double x))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            Console.Write("Введите координату Y: ");
            if (!double.TryParse(Console.ReadLine(), out double y))
            {
                Console.WriteLine("Некорректный ввод!");
                Fail();
                return;
            }

            string result = CheckPoint(x, y);
            Console.WriteLine(result);
            Complete();
        }

        private string CheckPoint(double x, double y)
        {
            const double epsilon = 1e-9;

            bool onBottomBorder = Math.Abs(y + 100) < epsilon && x >= -100 && x <= 100;
            bool onRightBorder = Math.Abs(y + x) < epsilon && x >= 0 && x <= 100;
            bool onLeftBorder = Math.Abs(y - x) < epsilon && x >= -100 && x <= 0;

            if (onBottomBorder || onRightBorder || onLeftBorder)
            {
                return "На границе";
            }

            bool insideRegion = y > -100 && y < 0 && ((x >= 0 && y < -x) || (x < 0 && y < x));

            return insideRegion ? "Да" : "Нет";
        }
    }
}
