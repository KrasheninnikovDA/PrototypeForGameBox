
using UnityEngine;

public class TileGround : MonoBehaviour
{
    [SerializeField] private PointPurchase topPoint;
    [SerializeField] private PointPurchase downPoint;
    [SerializeField] private PointPurchase leftPoint;
    [SerializeField] private PointPurchase rightPoint;
    private TilePurchaseMenu marcetTileMenu;
    private InstallerTile installer;
    public Coordinates Coordinates { get; set; }
    public PointPurchase TopPoint { get => topPoint;}
    public PointPurchase DownPoint { get => downPoint;}
    public PointPurchase LeftPoint { get => leftPoint;}
    public PointPurchase RightPoint { get => rightPoint;}

    public void Install(TilePurchaseMenu marcetTileMenu)
    {
        this.marcetTileMenu = marcetTileMenu;
        installer = new InstallerTile(ref topPoint, ref downPoint, ref leftPoint, 
                                      ref rightPoint, marcetTileMenu, this);
    }
}
