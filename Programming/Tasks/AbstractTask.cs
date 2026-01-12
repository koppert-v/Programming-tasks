using System;

namespace Programming.Tasks
{
    public abstract class AbstractTask : ITask, IRunnable
    {
        public event Action OnComplete;
        public event Action OnFail;
        public abstract string Title { get; }
        public abstract string Description { get; }
        public abstract void Run();

        protected void Complete()
        {
            OnComplete?.Invoke();
        }

        protected void Fail()
        {
            OnFail?.Invoke();
        }
    }
}
