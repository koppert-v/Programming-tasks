using System;

namespace Programming.Tasks
{
    public class Task : AbstractTask
    {
        public override string Title => "Task";
        public override string Description => "Run Task";

        public override void Run()
        {
            Console.WriteLine("Running Task");

            Complete();
        }
    }
}
