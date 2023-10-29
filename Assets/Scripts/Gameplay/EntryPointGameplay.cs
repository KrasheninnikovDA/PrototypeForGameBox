using UnityEngine;

public class EntryPointGameplay : MonoBehaviour
{
    [SerializeField] TileMap tileMap;
    [SerializeField] CreaterPlayer createrPlayer;
    [SerializeField] CreaterTileGround createrTileGround;
    [SerializeField] CreaterUI createrUI;
    private Inventory inventory;
    private void Awake()
    {
        CreatePlayer();
        CreateUI();
        CreateStartTile();
        CreateMap();
    }

    private void CreateStartTile()
    {
        createrTileGround.Create(createrUI.MenuPurchase);
    }

    private void CreateUI()
    {
        createrUI.Create(createrTileGround, tileMap, inventory);
        inventory.Install(createrUI.Viewer);
    }

    private void CreatePlayer()
    {
        createrPlayer.Create();
        inventory = createrPlayer.Inventory;
    }

    private void CreateMap()
    {
        tileMap.Create();
        tileMap.RegisterStartTail(ref createrTileGround.GetStartTile());
    }
}

