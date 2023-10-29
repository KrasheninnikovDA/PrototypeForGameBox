
using UnityEngine;

[CreateAssetMenu(fileName = "Resources", menuName = "ScriptableObjects/MarcetInfo", order = 1)]
public class MarketInfo : ScriptableObject
{
    [SerializeField] int costTree;
    [SerializeField] int costRock;

    public int ConsTree => costTree;
    public int ConsRock => costRock;
}
