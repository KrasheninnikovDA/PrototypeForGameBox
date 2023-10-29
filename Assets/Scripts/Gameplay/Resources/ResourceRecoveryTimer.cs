
using System;

public class ResourceRecoveryTimer : Timer
{
    public Action signal;

    protected override void ExecuteAction()
    {
        signal?.Invoke();
    }
}
