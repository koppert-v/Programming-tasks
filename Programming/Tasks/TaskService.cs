using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming.Tasks
{
    public class TaskService
    {
        private List<AbstractTask> _tasks = new List<AbstractTask>();
        private int _currentTaskIndex;

        public void Initialize(IEnumerable<AbstractTask> tasks)
        {
            if (tasks is null)
            {
                Console.Error.WriteLine("Task list is null");
                return;
            }

            _tasks = tasks.ToList();
        }

        public void Run()
        {
            RunTask(_currentTaskIndex);
        }

        private void ToNextTask()
        {
            int nextTaskIndex = _currentTaskIndex + 1;
            DisableTask(_currentTaskIndex);
            if (nextTaskIndex >= _tasks.Count || nextTaskIndex < 0)
            {
                Console.WriteLine("Task end");
                return;
            }

            _currentTaskIndex = nextTaskIndex;
            Console.WriteLine("================================================================");
            RunTask(_currentTaskIndex);
        }

        public void ToPreviousTask() { }

        private void RunTask(int taskIndex, bool showInfo = true)
        {
            if (taskIndex < 0 || _currentTaskIndex >= _tasks.Count)
            {
                Console.Error.WriteLine("Task is out of range");
                return;
            }
            AbstractTask task = _tasks[taskIndex];
            if (showInfo)
            {
                Console.WriteLine("Title: " + task.Title);
                Console.WriteLine("Description: " + task.Description);
            }

            task.OnComplete += ToNextTask;
            task.OnFail += RestartCurrentTask;
            task.Run();
        }

        private void DisableTask(int taskIndex)
        {
            if (taskIndex < 0 && _currentTaskIndex >= _tasks.Count)
            {
                Console.Error.WriteLine("Task is out of range");
                return;
            }
            AbstractTask task = _tasks[_currentTaskIndex];
            task.OnComplete -= ToNextTask;
            task.OnFail -= RestartCurrentTask;
        }

        private void RestartCurrentTask()
        {
            DisableTask(_currentTaskIndex);
            RunTask(_currentTaskIndex, false);
        }
    }
}
