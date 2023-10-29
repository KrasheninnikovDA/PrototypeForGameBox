using GameConstants;
using UnityEngine;

public class TilePurchaseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private PurchaseTileInfo price;
    private CreaterTileGround createrTileGround;
    private PointPurchase point;
    private TileGround tileCreater;
    private TileMap map;
    private MountingLocation location;
    private Inventory inventoryPlayer;

    public void Install(CreaterTileGround createrTileGround, TileMap map, ref Inventory inventoryPlayer)
    {
        this.createrTileGround = createrTileGround;
        this.map = map;
        this.inventoryPlayer = inventoryPlayer;
    }

    public void ShowMenu(PointPurchase point, ref TileGround tile, MountingLocation location)
    {
        menu.SetActive(true);
        this.point = point;
        this.tileCreater = tile;
        this.location = location;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
    }

    private bool CheckCoinsForTreeTile()
    {
        if (inventoryPlayer.Payment(price.PriceTreeTile))
        {
            return true;
        }
        return false;
    }

    private bool CheckCoinsForRockTile()
    {
        if (inventoryPlayer.Payment(price.PriceRockTile))
        {
            return true;
        }
        return false;
    }

    public void PurchaseNewTreeTile()
    {
        if (CheckCoinsForTreeTile())
        {
            TileGround newTile = createrTileGround.Create(NameTile.TreeTileGround, point.NewTilePosition, this);
            map.RegisterNewTile(ref tileCreater, location, ref newTile);
            CloseMenu();
        }
    }

    public void PurchaseNewRockTile()
    {
        if (CheckCoinsForRockTile())
        {
            TileGround newTile = createrTileGround.Create(NameTile.RockTileGround, point.NewTilePosition, this);
            map.RegisterNewTile(ref tileCreater, location, ref newTile);
            CloseMenu();
        }
    }
}
