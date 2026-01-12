using System.Collections.Generic;
using Programming.Tasks;

namespace Programming
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TaskService taskService = new TaskService();
            taskService.Initialize(
                new List<AbstractTask>()
                {
                    new ArrayOperationsTask(),
                    new BirthYearTask(),
                    new CubeEdgeCalculationTask(),
                    new SumDivisibilityTask(),
                    new PointInRegionTask(),
                    new VehicleMaxSpeedTask(),
                    new NumbersEndingWithDigitTask(),
                    new NumberPatternTask(),
                    new FunctionTableTask(),
                    new AdjacentNumberPairsTask(),
                    new DateCalculationTask(),
                    new ArithmeticProgressionTask(),
                }
            );

            taskService.Run();
        }
    }
}
