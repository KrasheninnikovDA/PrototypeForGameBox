
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "ScriptableObjects/PurchaseTileInfo", order = 1)]
public class PurchaseTileInfo : ScriptableObject
{
    [SerializeField] int priceTreeTile;
    [SerializeField] int priceRockTile;

    public int PriceTreeTile => priceTreeTile;
    public int PriceRockTile => priceRockTile;
}
