using System;

namespace Programming.Tasks
{
    public interface ITask
    {
        event Action OnComplete;
        event Action OnFail;
        string Title { get; }
        string Description { get; }
    }
}
