
using UnityEngine;

public class StatesResource : MonoBehaviour
{
    [SerializeField] GameObject recovering;
    [SerializeField] GameObject readyForMining;
    [SerializeField] ResourceRecoveryTimer recoveryTimer;
    [SerializeField] ResourceCollectionTimer collectionTimer;
    private bool isMining = true;
    public bool IsMining => isMining;

    private void Awake()
    {
        recoveryTimer.signal += SwitchReadyForMining;
        collectionTimer.signal += SwitchToRecovery;
    }

    private void SwitchToRecovery()
    {
        readyForMining.SetActive(false);
        recovering.SetActive(true);
        recoveryTimer.StartTimer();
        isMining = false;
    }

    private void SwitchReadyForMining()
    {
        readyForMining.SetActive(true);
        recovering.SetActive(false);
        isMining = true;
    }
}
