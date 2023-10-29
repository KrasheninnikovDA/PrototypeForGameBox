
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    public delegate ResourcesInfo CollectingResources();
    public event CollectingResources onCollectingResources;
    
    public void ExecuteAction()
    {
        inventory.UpdateInventory(onCollectingResources?.Invoke());
    }

    private void OnTriggerEnter(Collider other)
    {
        Mining resource;
        ResourceCollectionTimer timer;
        if (CheckPossibilityOfMining(other, out resource, out timer))
        {
            onCollectingResources += resource.GetResource;
            timer.signal += ExecuteAction;
            timer.StartTimer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Mining resource;
        ResourceCollectionTimer timer;
        if (TryGetResource(other, out resource) && TryGetTimer(other, out timer))
        {
            onCollectingResources -= resource.GetResource;
            timer.signal -= ExecuteAction;
            timer.StopTimer();
        }
    }

    private bool CheckPossibilityOfMining(Collider other, out Mining resource, out ResourceCollectionTimer timer)
    {
        bool state;
        bool existenceResuorse;
        bool existenceTimer;

        state = GetStateResurce(other);
        existenceResuorse = TryGetResource(other, out resource);
        existenceTimer = TryGetTimer(other, out timer);

        return state && existenceResuorse && existenceTimer;
    }

    private bool GetStateResurce(Collider other)
    {
        StatesResource statesResource;
        if (other.gameObject.TryGetComponent<StatesResource>(out statesResource))
        {
            if (statesResource.IsMining)
            {
                return true;
            }
        }
        return false;
    }

    private bool TryGetResource(Collider other, out Mining resource)
    {
        if (other.gameObject.TryGetComponent<Mining>(out resource))
        {
            return true;
        }
        resource = null;
        return false;
    }

    private bool TryGetTimer(Collider other, out ResourceCollectionTimer timer)
    {
        if (other.gameObject.TryGetComponent<ResourceCollectionTimer>(out timer))
        {
            return true;
        }
        timer = null;
        return false;
    }
}
