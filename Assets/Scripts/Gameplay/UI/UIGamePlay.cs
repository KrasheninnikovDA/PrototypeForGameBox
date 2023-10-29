
using TMPro;
using UnityEngine;

public class UIGamePlay : MonoBehaviour
{
    [SerializeField] private TilePurchaseMenu tileMarcetMenu;
    [SerializeField] private ResourcesViewer viewer;
    [SerializeField] private PurchaseTileInfo purchaseInfo;
    [SerializeField] private TextMeshProUGUI textPriceTree;
    [SerializeField] private TextMeshProUGUI textPriceRock;
    public TilePurchaseMenu TileMarcetMenu { get { return tileMarcetMenu; } }
    public ResourcesViewer ResourcesViewer { get {  return viewer; } }

    public void Insatall(CreaterTileGround createrTileGround, TileMap map, Inventory inventory)
    {
        tileMarcetMenu.Install(createrTileGround, map, ref inventory);
        viewer.Install(inventory);
        textPriceTree.text = purchaseInfo.PriceTreeTile.ToString();
        textPriceRock.text = purchaseInfo.PriceRockTile.ToString();
    }
}
