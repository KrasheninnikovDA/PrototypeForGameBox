
using GameConstants;
using UnityEngine;

public class CreaterTileGround : MonoBehaviour
{
    [SerializeField] GameObject prefabStartTile;
    [SerializeField] GameObject prefabRockTile;
    [SerializeField] GameObject prefabTreeTile;

    private TileGround startTileGround;
    public void Create(TilePurchaseMenu tilePurchaseMenu)
    {
        GameObject tileObject = Instantiate(prefabStartTile);
        startTileGround = tileObject.GetComponent<TileGround>();
        startTileGround.Install(tilePurchaseMenu);
    }

    public TileGround Create(NameTile nameTile, Vector3 positionNewTile, TilePurchaseMenu marcetTileMenu)
    {
        switch (nameTile)
        {
            case NameTile.TreeTileGround:
                TileGround newTreeTile = InstantiateTile(prefabTreeTile, positionNewTile);
                newTreeTile.Install(marcetTileMenu);
                return newTreeTile;
            case NameTile.RockTileGround:
                TileGround newRockTile = InstantiateTile(prefabRockTile, positionNewTile);
                newRockTile.Install(marcetTileMenu);
                return newRockTile;
            default:
                return null;
        }
    }

    private TileGround InstantiateTile(GameObject prefab, Vector3 positionNewTile)
    {
        GameObject tileObject = Instantiate(prefab, positionNewTile, new Quaternion(0, 0, 0, 0));

        return tileObject.GetComponent<TileGround>();
    }

    public ref TileGround GetStartTile()
    { 
        return ref startTileGround;
    }
}
