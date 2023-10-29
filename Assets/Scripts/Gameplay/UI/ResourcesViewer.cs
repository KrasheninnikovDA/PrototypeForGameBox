using TMPro;
using UnityEngine;

public class ResourcesViewer: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCountTree;
    [SerializeField] TextMeshProUGUI textCountRock;
    [SerializeField] TextMeshProUGUI textCountCoins;
    private Inventory inventory;
    public void Install(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void UpdateUI()
    {
        textCountTree.text = inventory.Trees.ToString();
        textCountRock.text = inventory.Rocks.ToString();
        textCountCoins.text = inventory.Coins.ToString();
    }
}
