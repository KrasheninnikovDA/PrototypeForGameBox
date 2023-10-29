using UnityEngine;

public class Mining : MonoBehaviour
{
    [SerializeField] ResourcesInfo resourcesInfo;
    public ResourcesInfo GetResource()
    {
        return resourcesInfo;
    }
}
