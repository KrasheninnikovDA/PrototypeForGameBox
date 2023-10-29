
using System;

public class ResourceCollectionTimer : Timer
{
    public Action signal;

    protected override void ExecuteAction()
    {
        signal?.Invoke();
    }
}
