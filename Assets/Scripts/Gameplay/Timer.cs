
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Image imageTimer;
    [SerializeField] private bool singleness;
    
    private float time;
    private bool isPause = true;

    public bool GetStartedTimer()
    {
        return isPause;
    }

    public void StartTimer()
    {
        ResetTimer();
        isPause = false;
    }

    public void StopTimer() 
    {
        ResetTimer();
        isPause = true;
    }

    private void ResetTimer()
    {
        time = duration;
        imageTimer.fillAmount = 0;
    }

    private void CheckEndTimerCycle()
    {
        if (time <= 0)
        {
            ResetTimer();
            CheckSinglness();
            ExecuteAction();
        }
    }

    private void CheckSinglness()
    {
        if (singleness)
        {
            isPause = true;
            imageTimer.fillAmount = 0;
        }
    }

    private void Update()
    {
        if (!isPause)
        {
            time -= Time.deltaTime;
            imageTimer.fillAmount = 1 - time / duration;
            CheckEndTimerCycle();
        }
    }

    protected virtual void ExecuteAction()
    { }
}
