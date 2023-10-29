using GameConstants;
using System.Net.Security;
using UnityEngine;

public class InstallerTile
{
    private PointPurchase topPoint;
    private PointPurchase downPoint;
    private PointPurchase leftPoint;
    private PointPurchase rightPoint;
    private TilePurchaseMenu marcetTileMenu;
    private TileGround tile;

    public InstallerTile(ref PointPurchase topPoint, ref PointPurchase downPoint,
                         ref PointPurchase leftPoint, ref PointPurchase rightPoint,
                         TilePurchaseMenu marcetTileMenu, TileGround tile)
    {
        this.topPoint = topPoint;
        this.downPoint = downPoint;
        this.leftPoint = leftPoint;
        this.rightPoint = rightPoint;
        this.marcetTileMenu = marcetTileMenu;
        this.tile = tile;
        InstallPointPurchase();
    }

    private void InstallPointPurchase()
    {
        topPoint.Install(marcetTileMenu, ref tile, MountingLocation.top);
        downPoint.Install(marcetTileMenu, ref tile, MountingLocation.down);
        leftPoint.Install(marcetTileMenu, ref tile, MountingLocation.left);
        rightPoint.Install(marcetTileMenu, ref tile, MountingLocation.right);
    }

    


}
