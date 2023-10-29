using GameConstants;
using UnityEngine;

public class PointPurchase : MonoBehaviour
{
    private TilePurchaseMenu tilePurchaseMenu;
    private Vector3 newTilePosition;
    private TileGround tile;
    private MountingLocation location;
    public Vector3 NewTilePosition { get => newTilePosition; }

    public void Install(TilePurchaseMenu tilePurchaseMenu, ref TileGround tile, MountingLocation location)
    {
        this.tilePurchaseMenu = tilePurchaseMenu;
        this.tile = tile;
        this.location = location;
        DeterminPositionForNewTiles(location);
    }

    private void DeterminPositionForNewTiles(MountingLocation location)
    {
        switch (location)
        {
            case MountingLocation.top:
                newTilePosition = tile.transform.position + new Vector3(0, 0, 10);
                break;
            case MountingLocation.down:
                newTilePosition = tile.transform.position + new Vector3(0, 0, -10);
                break;
            case MountingLocation.left:
                newTilePosition = tile.transform.position + new Vector3(-10, 0, 0);
                break;
            case MountingLocation.right:
                newTilePosition = tile.transform.position + new Vector3(10, 0, 0);
                break;
            default: 
                newTilePosition = tile.transform.position;
                break;
        }
    }

    public void disablePoint()
    { 
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Inventory inventoryPlayer;
        if (other.gameObject.TryGetComponent<Inventory>(out inventoryPlayer))
        {
            tilePurchaseMenu.ShowMenu(this, ref tile, location);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tilePurchaseMenu.CloseMenu();
    }
}
