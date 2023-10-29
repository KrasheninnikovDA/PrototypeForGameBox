using GameConstants;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    private ResourcesViewer viewer;
    private int countTrees;
    private int countRocks;
    private int countCoins;

    public int Trees => countTrees;
    public int Rocks => countRocks;
    public int Coins => countCoins;

    public void Install(ResourcesViewer viewer)
    {
        this.viewer = viewer;
    }

    public void Deposit(int coins)
    {
        if (coins > 0)
            countCoins += coins;
        Display();
    }

    public bool Payment(int cost)
    {
        if (countCoins >= cost)
        {
            countCoins -= cost;
            Display();
            return true;
        }
        return false;
    }

    public void UpdateInventory(ResourcesInfo resource)
    {
        switch (resource.Type)
        {
            case TypeResources.Tree: 
                countTrees+= resource.Count; 
                break;
            case TypeResources.Rock:
                countRocks+= resource.Count;
                break;
        }
        Display();
    }

    public void UnloadResources()
    {
        countTrees = 0;
        countRocks = 0;
        Display();
    }

    private void Display()
    {
        viewer.UpdateUI();
    }
}
