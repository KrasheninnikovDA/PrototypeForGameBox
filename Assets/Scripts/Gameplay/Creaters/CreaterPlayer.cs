
using UnityEngine;

public class CreaterPlayer : MonoBehaviour
{
    [SerializeField] GameObject prefabPlayer;
    private Inventory inventory;
    public Inventory Inventory => inventory;
    public void Create()
    {
        GameObject player= Instantiate(prefabPlayer);
        inventory = player.GetComponent<Inventory>();
    }
}
