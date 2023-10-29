using GameConstants;
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "ScriptableObjects/ResourcesInfo", order = 1)]
public class ResourcesInfo : ScriptableObject
{

    [SerializeField] TypeResources typeThisResource;
    [SerializeField] int countResource;
    [SerializeField] int costInCoins;

    public TypeResources Type => typeThisResource;
    public int Count => countResource;  
    public int Cost => costInCoins;
}
