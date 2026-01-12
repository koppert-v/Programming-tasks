using System;

namespace Programming.Tasks
{
    public class NumberPatternTask : AbstractTask
    {
        public override string Title => "Number Pattern Display";
        public override string Description => "Вывести на экран числа следующим образом";

        public override void Run()
        {
            for (int number = 8; number >= 4; number--)
            {
                int repetitions = number - 3;

                for (int j = 0; j < repetitions; j++)
                {
                    Console.Write(number + "\t");
                }

                Console.WriteLine();
            }
            Complete();
        }
    }
}
