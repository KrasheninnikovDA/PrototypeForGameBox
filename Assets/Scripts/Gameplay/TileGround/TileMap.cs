using GameConstants;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private int rows;
    [SerializeField, Range(1, 10)] private int columns;
    private TileGround[,] map;

    public void Create()
    {
        map = new TileGround[rows, columns];
    }

    public void RegisterStartTail(ref TileGround tile)
    {
        tile.Coordinates = DetermineStartCoordinate();
        int startRow = tile.Coordinates.row;
        int startColunm = tile.Coordinates.column;
        map[startRow, startColunm] = tile;
    }

    private Coordinates DetermineStartCoordinate()
    {
        Coordinates coordinates = new Coordinates();
        coordinates.row = rows / 2;
        coordinates.column = columns / 2;
        return coordinates;
    }

    public TileGround RegisterNewTile(ref TileGround tileCreater, MountingLocation location, 
                                      ref TileGround newTile)
    {
        Coordinates newTileCoordinate = new Coordinates();
        newTileCoordinate.row = tileCreater.Coordinates.row;
        newTileCoordinate.column = tileCreater.Coordinates.column;
        switch (location)
        {
            case MountingLocation.top:
                newTileCoordinate.row += 1;
                break;
            case MountingLocation.down:
                newTileCoordinate.row -= 1;
                break;
            case MountingLocation.left:
                newTileCoordinate.column -= 1;
                break;
            case MountingLocation.right:
                newTileCoordinate.column += 1;
                break;
        }
        LocateNewTile(newTileCoordinate, ref newTile);
        return newTile;
    }

    private void LocateNewTile(Coordinates newTileCoordinate, ref TileGround newTile)
    {
        newTile.Coordinates = newTileCoordinate;
        map[newTileCoordinate.row, newTileCoordinate.column] = newTile;
        ChackPointPurchase(ref newTile);
    }

    private void ChackPointPurchase(ref TileGround newTile)
    {
        Coordinates coordinates = newTile.Coordinates;
        DisableIfNecessaryTopPoint(coordinates.row+1, coordinates.column, ref newTile);
        DisableIfNecessaryDownPoint(coordinates.row-1, coordinates.column, ref newTile);
        DisableIfNecessaryRightPoint(coordinates.row, coordinates.column+1, ref newTile);
        DisableIfNecessaryLeftPoint(coordinates.row, coordinates.column-1, ref newTile);
    }

    private void DisableIfNecessaryTopPoint(int row, int column, ref TileGround newTile)
    {
        TileGround adjacentTile;
        if (CheckOutOfRange(row, column))
        {
            newTile.TopPoint.disablePoint();
        }
        else 
        {
            if (CheckConnection(row, column, out adjacentTile))
            {
                newTile.TopPoint.disablePoint();
                adjacentTile.DownPoint.disablePoint();
            }
        }
    }

    private void DisableIfNecessaryDownPoint(int row, int column, ref TileGround newTile)
    {
        TileGround adjacentTile;
        if (CheckOutOfRange(row, column))
        {
            newTile.DownPoint.disablePoint();
        }
        else
        {
            if (CheckConnection(row, column, out adjacentTile))
            {
                newTile.DownPoint.disablePoint();
                adjacentTile.TopPoint.disablePoint();
            }
        }
    }

    private void DisableIfNecessaryRightPoint(int row, int column, ref TileGround newTile)
    {
        TileGround adjacentTile;
        if (CheckOutOfRange(row, column))
        {
            newTile.RightPoint.disablePoint();
        }
        else
        {
            if (CheckConnection(row, column, out adjacentTile))
            {
                newTile.RightPoint.disablePoint();
                adjacentTile.LeftPoint.disablePoint();
            }
        }
    }

    private void DisableIfNecessaryLeftPoint(int row, int column, ref TileGround newTile)
    {
        TileGround adjacentTile;
        if (CheckOutOfRange(row, column))
        {
            newTile.LeftPoint.disablePoint();
        }
        else
        {
            if (CheckConnection(row, column, out adjacentTile))
            {
                newTile.LeftPoint.disablePoint();
                adjacentTile.RightPoint.disablePoint();
            }
        }
    }

    private bool CheckOutOfRange(int row, int column)
    {
        if (row >= rows || column >= columns || row < 0 || column < 0)
            return true;
        return false;
    }

    private bool CheckConnection(int row, int column, out TileGround adjacentTile)
    {

        if (map[row, column] != null)
        {
            adjacentTile = map[row, column];
            return true;
        }
        adjacentTile = null;
        return false;
    }
}
