using UnityEngine;

public class CreaterUI : MonoBehaviour
{
    [SerializeField] GameObject uiPrefab;
    private ResourcesViewer viewer;
    private TilePurchaseMenu menuPurchase;
    public ResourcesViewer Viewer => viewer;
    public TilePurchaseMenu MenuPurchase => menuPurchase;

    public void Create(CreaterTileGround createrTileGround, TileMap map, Inventory inventory)
    {
        GameObject UI = Instantiate(uiPrefab);
        UIGamePlay uIGamePlay = UI.GetComponent<UIGamePlay>();
        uIGamePlay.Insatall( createrTileGround, map, inventory);
        viewer = uIGamePlay.ResourcesViewer;
        menuPurchase = uIGamePlay.TileMarcetMenu;
    }
}
