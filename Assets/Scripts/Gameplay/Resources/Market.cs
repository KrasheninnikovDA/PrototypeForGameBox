using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField] MarketInfo marcetInfo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.gameObject.GetComponent<Inventory>();
            int revenue = inventory.Trees * marcetInfo.ConsTree + inventory.Rocks * marcetInfo.ConsRock;
            inventory.Deposit(revenue);
            inventory.UnloadResources();
        }
    }
}
