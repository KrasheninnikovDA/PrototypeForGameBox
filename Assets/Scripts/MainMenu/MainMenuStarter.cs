
using UnityEngine;

public class MainMenuStarter : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    private void Awake()
    {
        Instantiate(mainMenu);
    }
}
